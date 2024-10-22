using System;

namespace ResourceSystem.Services.Data
{
    public class TimerData
    {
        public float Time { get; private set; }
        public Action Callback { get; private set; }

        public TimerData(float time, Action callback)
        {
            Time = time;
            Callback = callback;
        }

        public void DecreaseTime(float amount) => Time -= amount;
    }
}