using ResourceSystem.Data;
using UnityEngine;

namespace ResourceSystem.Services
{
    public class ResourceDataService
    {
        private const string RESOURCES_DATA_PATH = "Data/ResourcesDataSO";
        private static ResourceDataService _instance;
        private readonly ResourcesDataSO _resourcesData = Resources.Load<ResourcesDataSO>(RESOURCES_DATA_PATH);

        public static ResourceDataService Instance => _instance ??= new ResourceDataService();

        public ResourceDataItem GetResource(ResourceType resourceType) =>
            _resourcesData.Resources.Find(item => item.ResourceType == resourceType);
    }
}