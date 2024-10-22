using System;
using UnityEngine;

namespace ResourceSystem.Data
{
    [Serializable]
    public class ResourceDataItem
    {
        [field: SerializeField] public ResourceType ResourceType { get; private set; }
        [field: SerializeField] public float DecayTime { get; private set; }
        [field: SerializeField] public float EnrichmentTime { get; private set; }
    }
}