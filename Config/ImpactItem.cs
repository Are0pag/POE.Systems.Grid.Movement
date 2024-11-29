using Scripts.Systems.GridGeneration;
using Scripts.Tools;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    [System.Serializable]
    internal class ImpactItem {
        
        [field: SerializeField] internal protected InterfaceRef<IGridCellData> CellData { get; protected set; }
        
        /// <summary>
        /// The coefficient by which the unit's movement speed will decrease when moving through this type of cell.\n
        /// The bigger the value, the slower the movement
        /// </summary>
        [field: Tooltip("The coefficient by which the unit's movement speed will decrease when moving through this type of cell.\n " +
                        "The higher the value, the slower the movement")]
        [field: Range(1f, 10f)]
        [field: SerializeField] internal protected float SpeedDecrease { get; protected set; }
        
        /// <summary>
        /// The number of steps required when passing on a given cell type
        /// </summary>
        [field: Tooltip("The number of steps required when passing on a given cell type")]
        [field: Range(1, 10)]
        [field: SerializeField] internal protected  int  StepCountDecrease { get; protected set; }
    }
}