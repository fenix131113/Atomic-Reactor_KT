using Core;
using UnityEngine;
using Zenject;
// ReSharper disable ClassNeverInstantiated.Global

namespace ResourceSystem
{
    public class RecordLogic : ITickable
    {
        public float RecordTime { get; private set; }
        
        private GameInfo _gameInfo;

        [Inject]
        private void Construct(GameInfo gameInfo) => _gameInfo = gameInfo;

        public void Tick()
        {
            if (_gameInfo.IsPlaying)
                RecordTime += Time.deltaTime;
        }
    }
}