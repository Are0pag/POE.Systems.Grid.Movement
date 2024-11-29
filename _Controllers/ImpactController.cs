using Zenject;

namespace Scripts.Systems.GridMovement
{
    internal class ImpactController : Controller
    {
        protected ImpactCalculator _impactCalculator;
        
        [Inject]
        internal void Construct(ImpactCalculator impactCalculator) {
            _impactCalculator = impactCalculator;
        }

        public override void OnPlayerContinueMovableItemPass(IMovableGridCell cell) {
            (_traceCorrector as ImpactTraceCorrector)?.SetGridCellData(cell);
            base.OnPlayerContinueMovableItemPass(cell);
        }
        
        protected override bool IsWayComplete() {
            return ((ImpactMoveTrace)_trace).PassedStepsCount == _trace.CurrentlyMoving.GridMovementStats.StepCount;
        }

        protected override MoveTrace GetMoveTrace(IGridMovable heroOnCell) {
            return new ImpactMoveTrace(heroOnCell, _impactCalculator);
        }
    }
}