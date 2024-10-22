using System;
using UnityEngine;

namespace ResourceSystem.Data
{
    [Serializable]
    public class ResourceViewItem
    {
        [field: SerializeField] public ResourceType ResourceType { get; private set; }
        [field: SerializeField] public Sprite ActiveSprite { get; private set; }
        [field: SerializeField] public Sprite InactiveSprite { get; private set; }
    }
}