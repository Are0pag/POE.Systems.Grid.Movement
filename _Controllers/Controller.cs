using System.Linq;
using Scripts.Services.EventBus;
using UnityEngine;
using Zenject;

namespace Scripts.Systems.GridMovement
{
    internal class Controller : MonoBehaviour, ITraceHandle, IInputHandle
    {
        protected GridContent _gridContent;
        protected MoveTrace _trace;
        protected TraceCorrector _traceCorrector;

        [Inject]
        internal void Construct(TraceCorrector traceCorrector, GridContent gridContent) {
            _traceCorrector = traceCorrector;
            _gridContent = gridContent;
        }
        
        protected virtual void OnEnable() => EventBus.Subscribe(this);
        protected virtual void OnDisable() => EventBus.Unsubscribe(this);

        void IInputHandle.OnMouseButtonDown() {
            if (_trace == null)
                EventBus.RaiseEvent<IGridHandle>(h => h.OnInput());
        }

        void IInputHandle.OnMouseButtonUp() {
            if (_trace is not { Executing: false })
                return;

            EventBus.RaiseEvent<IGridHandle>(h => h.OnStopTracing());
            if (_trace.Commands.Count == _trace.CurrentlyMoving.GridMovementStats.StepCount) {
                _trace.IsComplete = true;
                StartMoving();
            }
            else {
                _trace.UndoOperation();
                _trace = null;
            }
        }

        void ITraceHandle.OnPlayerSelectCell(IMovableGridCell cell) {
            var heroOnCell = _gridContent.HeroesPositions.FirstOrDefault(h => h.Value.Equals(cell.Position)).Key;
            if (heroOnCell == null)
                return;

            _trace = new MoveTrace(heroOnCell);
            _traceCorrector.InitRuntime(_trace);
            EventBus.RaiseEvent<IGridHandle>(h => h.OnMovableItemDefine());
        }

        void ITraceHandle.OnPlayerContinueMovableItemPass(IMovableGridCell cell) {
            var desiredStep = cell.Position;

            if (_traceCorrector.IsItReturnToStartInput(desiredStep)) {
                _trace.UndoStep();
                return;
            }

            if (_traceCorrector.IsItUndoInput(desiredStep)) {
                _trace.UndoStep();
                return;
            }

            if (!_traceCorrector.CanContinue())
                return;

            if (_traceCorrector.IsItAlreadyPassedPoint(desiredStep))
                return;

            if (_traceCorrector.IsItPositionTakenByAnotherHero(desiredStep, _gridContent.HeroesPositions))
                return;

            var lastStep = _trace.Commands.Count > 0
                ? _trace.LastCommand.MoveCommand.TargetPosition
                : _trace.CurrentlyMoving.MovingObject.transform.position;

            if (!_traceCorrector.IsDesiredStepDirectedOnNeighboringCell(desiredStep, lastStep))
                return;

            _trace.AddStep(cell);
        }

        protected virtual async void StartMoving() {
            _trace.Executing = true;
            await _trace.PassWay();
            _gridContent.HeroesPositions[_trace.CurrentlyMoving] = _trace.LastCommand.MoveCommand.TargetPosition;
            _trace = null;
        }
    }
}