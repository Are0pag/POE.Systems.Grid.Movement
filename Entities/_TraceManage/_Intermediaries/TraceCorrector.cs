using System.Collections.Generic;
using System.Linq;
using Scripts.Systems.GridGeneration;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    internal class TraceCorrector
    {
        protected readonly Dictionary<DirectionsOfGrid, Vector3> _directions;
        protected MoveTrace _moveTrace;

        public TraceCorrector(DirectionCalculator directionCalculator) {
            _directions = directionCalculator.GetGridDirections();
        }

        internal void InitRuntime(MoveTrace moveTrace) {
            _moveTrace = moveTrace;
        }

        internal virtual bool CanContinue() {
            return _moveTrace.Commands.Count + 1 <= _moveTrace.CurrentlyMoving.GridMovementStats.StepCount;
        }

        internal virtual bool IsItUndoInput(Vector3 desiredStep) {
            if (_moveTrace.Commands.Count == 0)
                return false;
            return desiredStep == _moveTrace.LastCommand.MoveCommand.StartPosition;
        }

        internal bool IsItReturnToStartInput(Vector3 desiredStep) {
            return _moveTrace.Commands.Count == 1 && desiredStep == _moveTrace.CurrentlyMoving.MovingObject.transform.position;
        }

        internal bool IsItAlreadyPassedPoint(Vector3 desiredStep) {
            return _moveTrace.Commands.Any(command => command.MoveCommand.TargetPosition == desiredStep);
        }

        /// <summary>
        ///     It works with already selected hero, that is useful
        /// </summary>
        internal bool IsItPositionTakenByAnotherHero(Vector3 desiredStep, Dictionary<IGridMovable, Vector3> heroesPositions) {
            return heroesPositions.Any(item => item.Value == desiredStep);
        }

        internal virtual bool IsDesiredStepDirectedOnNeighboringCell(Vector3 desiredStep, Vector3 lastStep) {
            return _directions.Select(direction => lastStep + direction.Value)
                .Any(neighboringCellPosition => desiredStep == neighboringCellPosition);
        }
    }
}