using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Systems.GridMovement
{
    // клавиши для клинта
    public class GridContent // : KeyWord
    {
        public Dictionary<IGridMovable, Vector3> HeroesPositions { get; set; } = new();
        public virtual IGridMovable SelectedHero { get; set; }
        public bool IsMouseOnGrid => MovableCell.IsMouseOnGrid;
    }
}