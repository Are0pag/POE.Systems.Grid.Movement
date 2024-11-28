using Scripts.Systems.GridMovement.Display;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    internal interface IMovableGridCell
    {
        internal Vector3 Position { get; }
        public CellDisplay Display { get; }
    }
}