using UnityEngine;

namespace Core.Services
{
    public static class ResourceLoader
    {
        public static T LoadResource<T>(string path) where T : class => Resources.Load(path) as T;

        public static void UnloadResource(Object obj) => Resources.UnloadAsset(obj);
    }
}