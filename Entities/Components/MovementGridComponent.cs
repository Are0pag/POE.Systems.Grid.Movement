using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Scripts.Behavioral;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    public class MovementGridComponent : MovementComponent, IGridMovable
    {
        [field: SerializeField] public GridMovementStats GridMovementStats { get; protected set; }

        public virtual async UniTask PassWayAsync(List<Vector3> points, float timeToPassingOneGrid) {
            foreach (var point in points) await MoveAsync(point, timeToPassingOneGrid);
        }
    }
}