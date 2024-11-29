
namespace Scripts.Systems.GridMovement
{
    internal class ImpactMoveTrace : MoveTrace
    {
        protected readonly ImpactCalculator _impactCalculator;
        
        internal protected int PassedStepsCount { get; protected set; }

        internal ImpactMoveTrace(IGridMovable currentlyMoving, ImpactCalculator impactCalculator)
            : base(currentlyMoving) 
        {
            _impactCalculator = impactCalculator;
        }

        internal override void AddStep(IMovableGridCell cell) {
            base.AddStep(cell);
            PassedStepsCount += _impactCalculator.GetNecessaryStepCount(cell.GridCellData);
        }

        internal override void UndoStep() {
            PassedStepsCount -= ((ImpactMoveCommand)LastCommand.MoveCommand).NecessarySteps;
            base.UndoStep();
        }

        protected override MoveCommand GetMoveCommand(IMovableGridCell cell) {
            var speed = _impactCalculator.CalculateSpeed(cell, CurrentlyMoving);
            return new ImpactMoveCommand(CurrentlyMoving, cell.Position, GetStartPositionForCommand(), 
                speed, _impactCalculator.GetNecessaryStepCount(cell.GridCellData));
        }
        
        protected override DisplayCommand GetDisplayCommand(IMovableGridCell cell) {
            return new DisplayCommand(cell, CurrentlyMoving.GridMovementStats.StepCount - PassedStepsCount);
        }
    }
}