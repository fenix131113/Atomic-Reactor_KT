using System;
using System.Collections;
using System.Collections.Generic;
using ResourceSystem.Services.Data;
using UnityEditor;
using UnityEngine;

namespace ResourceSystem.Services
{
    // Only for repeatable timers
    public class MonoTimerHandler : MonoBehaviour
    {
        private readonly Dictionary<int, Coroutine> _coroutines = new();

        public void StartTimer(float time, Action callback, int timerId)
        {
            _coroutines.TryAdd(timerId, null);
            
            if (_coroutines[timerId] != null)
                StopCoroutine(_coroutines[timerId]);

            _coroutines[timerId] = StartCoroutine(TimerCoroutine(new TimerData(time, callback)));
        }

        public void StopAllTimers()
        {
            StopAllCoroutines();
            _coroutines.Clear();
        }

        private static IEnumerator TimerCoroutine(TimerData timer)
        {
            yield return new WaitForSeconds(timer.Time);

            timer.Callback?.Invoke();
        }
    }
}