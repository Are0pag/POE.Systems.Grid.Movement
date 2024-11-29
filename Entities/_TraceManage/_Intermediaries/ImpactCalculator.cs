using System.Linq;
using Scripts.Systems.GridGeneration;

namespace Scripts.Systems.GridMovement
{
    internal class ImpactCalculator
    {
        protected readonly ImpactCellType _impactCellType;
        
        internal ImpactCalculator(Config config) {
            _impactCellType = config.ImpactCellType;
        }

        internal int GetNecessaryStepCount(IGridCellData gridCellData) {
            return _impactCellType.ImpactItems.First(g => g.CellData.Value == gridCellData).StepCountDecrease;
        }

        internal float CalculateSpeed(IMovableGridCell cell, IGridMovable gridMovable) {
            var factor = _impactCellType.ImpactItems.First(g => g.CellData.Value  == cell.GridCellData).SpeedDecrease;
            return gridMovable.GridMovementStats.Speed * factor;
        }
    }
}