using Zenject;

namespace ResourceSystem.Services
{
    public class ResourceTimerLoader
    {
        [Inject]
        public ResourceTimerLoader(MonoTimerHandler timerHandler) => ResourceTimerService.Instance.Init(timerHandler);
    }
}