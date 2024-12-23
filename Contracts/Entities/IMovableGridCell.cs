using Scripts.Systems.GridGeneration;
using Scripts.Systems.GridMovement.Display;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    internal interface IMovableGridCell
    {
        public IGridCellData GridCellData { get; }
        
        public CellDisplay Display { get; }
        
        internal Vector3 Position { get; }
    }
}