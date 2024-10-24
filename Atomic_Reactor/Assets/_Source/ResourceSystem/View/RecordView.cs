using TMPro;
using UnityEngine;
using Zenject;

namespace ResourceSystem.View
{
    public class RecordView : MonoBehaviour
    {
        [SerializeField] private TMP_Text recordLabel;

        private RecordLogic _recordLogic;

        [Inject]
        private void Construct(RecordLogic recordLogic) => _recordLogic = recordLogic;

        private void FixedUpdate() => RedrawTime();

        private void RedrawTime() =>
            recordLabel.text = $"{(int)(_recordLogic.RecordTime / 60)}:{(int)_recordLogic.RecordTime}";
    }
}