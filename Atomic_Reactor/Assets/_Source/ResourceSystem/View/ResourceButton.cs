using Core.StateMachine;
using Core.StateMachine.GameStates;
using ResourceSystem.Data;
using ResourceSystem.Services;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ResourceSystem.View
{
    public class ResourceButton : MonoBehaviour
    {
        [field: SerializeField] private Button targetButton;

        [field: SerializeField] public ResourceType ResourceType { get; private set; }
        [field: SerializeField] public Image TargetImage { get; private set; }

        private GameStateMachine _gameStateMachine;
        private GUID _timerId;
        private bool _isActive = true;
        private float _decayTime;
        private float _enrichmentTime;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine) => _gameStateMachine = gameStateMachine;

        private void Awake() => Init();

        private void OnDestroy() => Expose();

        private void CheckButtonState()
        {
            ResourceViewService.Instance.SetSprite(TargetImage, ResourceType, _isActive);
            targetButton.interactable = _isActive;
        }

        #region Timers

        private void StartDecayTimer()
        {
            _isActive = true;
            CheckButtonState();
            ResourceTimerService.Instance.StartTimer(_decayTime, () => _gameStateMachine.SetState(typeof(GameEndState)), _timerId);
        }

        private void StartEnrichmentTimer()
        {
            _isActive = false;
            CheckButtonState();
            ResourceTimerService.Instance.StartTimer(_enrichmentTime, StartDecayTimer, _timerId);
        }

        #endregion

        #region Init

        private void Init()
        {
            _timerId = GUID.Generate();
            CheckButtonState();
            LoadData();
            StartDecayTimer();
            Bind();
        }

        private void LoadData()
        {
            var item = ResourceDataService.Instance.GetResource(ResourceType);

            _decayTime = item.DecayTime;
            _enrichmentTime = item.EnrichmentTime;
        }

        #endregion

        private void Bind() => targetButton.onClick.AddListener(StartEnrichmentTimer);

        private void Expose() => targetButton.onClick.RemoveAllListeners();
    }
}