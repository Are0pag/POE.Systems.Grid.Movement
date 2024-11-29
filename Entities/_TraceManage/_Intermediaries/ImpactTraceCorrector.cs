using Scripts.Systems.GridGeneration;

namespace Scripts.Systems.GridMovement
{
    internal class ImpactTraceCorrector : TraceCorrector 
    {
        protected readonly ImpactCalculator _impactCalculator;
        protected IMovableGridCell _cell;

        internal ImpactTraceCorrector(DirectionCalculator directionCalculator, ImpactCalculator impactCalculator) 
            : base(directionCalculator) 
        {
            _impactCalculator = impactCalculator;
        }

        internal override bool CanContinue() {
            var impactMoveTrace = _moveTrace as ImpactMoveTrace;
            return impactMoveTrace.PassedStepsCount + NecessarySteps() <= _moveTrace.CurrentlyMoving.GridMovementStats.StepCount;
        }

        internal void SetGridCellData(IMovableGridCell movableGridCell) => _cell = movableGridCell;

        private int NecessarySteps() => _impactCalculator.GetNecessaryStepCount(_cell.GridCellData);
    }
}