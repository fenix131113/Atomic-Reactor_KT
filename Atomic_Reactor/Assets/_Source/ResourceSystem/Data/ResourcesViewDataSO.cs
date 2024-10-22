using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "New ResourcesViewDataSO", menuName = "SOs/ResourcesViewDataSO")]
    public class ResourcesViewDataSO : ScriptableObject
    {
        [field: SerializeField] public List<ResourceViewItem> Resources { get; private set; }
    }
}