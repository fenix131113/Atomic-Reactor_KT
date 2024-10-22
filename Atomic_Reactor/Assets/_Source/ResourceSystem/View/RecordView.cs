using Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace ResourceSystem.View
{
    public class RecordView : MonoBehaviour
    {
        [SerializeField] private TMP_Text recordLabel;

        private float _recordTime;
        private GameInfo _gameInfo;

        [Inject]
        private void Construct(GameInfo gameInfo)
        {
            _gameInfo = gameInfo;
        }

        private void Update()
        {
            if (_gameInfo.IsPlaying)
                _recordTime += Time.deltaTime;
        }

        private void FixedUpdate() => RedrawTime();

        private void RedrawTime() => recordLabel.text = $"{(int)(_recordTime / 60)}:{(int)_recordTime}";
    }
}