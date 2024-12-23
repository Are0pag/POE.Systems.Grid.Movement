using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Scripts.Behavioral;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    public interface IGridMovable : IMovable
    {
        GridMovementStats GridMovementStats { get; }
        UniTask PassWayAsync(List<Vector3> points, float timeToPassingOneGrid);
    }
}