using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "New ResourcesDataSO", menuName = "SOs/ResourcesDataSO")]
    public class ResourcesDataSO : ScriptableObject
    {
        [field: SerializeField] public List<ResourceDataItem> Resources { get; private set; }
    }
}