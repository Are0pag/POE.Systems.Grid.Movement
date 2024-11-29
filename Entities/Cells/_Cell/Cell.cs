using Scripts.Systems.GridGeneration;
using Scripts.Tools;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    public abstract class Cell : MonoBehaviour
    {
        [SerializeField] protected InterfaceRef<IGridCellData> _сellType;
        public IGridCellData GridCellData { get => _сellType.Value; }
    }
}