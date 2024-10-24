using System;
using UnityEditor;

namespace ResourceSystem.Services
{
    public class ResourceTimerService
    {
        private static ResourceTimerService _instance;
        public static ResourceTimerService Instance => _instance ??= new ResourceTimerService();

        private MonoTimerHandler _timerHandler;

        public void Init(MonoTimerHandler timerHandler) => _timerHandler = timerHandler;
        
        public void StartTimer(float time, Action callback, int timerId) => _timerHandler.StartTimer(time, callback, timerId);
        
        public void StopAllTimers() => _timerHandler.StopAllTimers();
    }
}