
using UnityEngine;
#if UNITY_EDITOR
using Scripts.Tools.CustomEdit;
#endif

namespace Scripts.Systems.GridMovement
{
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = nameof(GridMovementStats), menuName = DirectoryNames.STATS_DATA_PATH + nameof(GridMovementStats))]
#endif
    public class GridMovementStats : ScriptableObject
    {
        /// <summary>
        ///     Count of cells that can passing per one turn
        /// </summary>
        [field: Tooltip("Count of cells that can passing per one turn")]
        [field: Range(1, 10)]
        [field: SerializeField]
        internal protected int StepCount { get; protected set; }

        [field: Range(0.1f, 20f)]
        [field: SerializeField]
        internal protected float Speed { get; protected set; }
    }
}