
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using Scripts.Tools.CustomEdit;
#endif

namespace Scripts.Systems.GridMovement
{
#if UNITY_EDITOR
    [CreateAssetMenu(
        fileName = nameof(ImpactCellType), 
        menuName = DirectoryNames.GRID_SYSTEM_DATA_PATH + nameof(GridMovement) + DirectoryNames.SLASH + nameof(ImpactCellType))]
#endif
    
    internal class ImpactCellType : ScriptableObject
    {
        [field: SerializeField] internal protected List<ImpactItem> ImpactItems { get; protected set; }
    }
}