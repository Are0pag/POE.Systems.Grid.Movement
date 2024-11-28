using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    public class GridContent
    {
        public Dictionary<IGridMovable, Vector3> HeroesPositions { get; set; } = new();
    }
}