using ResourceSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace ResourceSystem.Services
{
    public class ResourceViewService
    {
        private const string RESOURCE_VIEW_DATA_PATH =
            "Data/ResourcesViewData";

        private static ResourceViewService _instance;

        private readonly ResourcesViewDataSO _resourcesViewData =
            Resources.Load<ResourcesViewDataSO>(RESOURCE_VIEW_DATA_PATH);

        public static ResourceViewService Instance => _instance ??= new ResourceViewService();

        public void SetSprite(Image target, ResourceType resourceType, bool state)
        {
            target.sprite = state
                ? _resourcesViewData.Resources.Find(item => item.ResourceType == resourceType).ActiveSprite
                : _resourcesViewData.Resources.Find(item => item.ResourceType == resourceType).InactiveSprite;
        }
    }
}