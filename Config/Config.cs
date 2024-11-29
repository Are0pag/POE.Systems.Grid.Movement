
using UnityEngine;
#if UNITY_EDITOR
using Scripts.Tools.CustomEdit;
#endif

namespace Scripts.Systems.GridMovement
{
#if UNITY_EDITOR
    [CreateAssetMenu(
        fileName = nameof(Config), 
        menuName = DirectoryNames.GRID_SYSTEM_DATA_PATH + nameof(GridMovement) + DirectoryNames.SLASH + nameof(Config))]
#endif
    
    internal class Config : ScriptableObject
    {
        [SerializeField] internal ImpactCellType ImpactCellType;
    }
}