using System;
using Core.StateMachine;
using Core.StateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace Core.LooseGameView
{
    public class LooseView : MonoBehaviour
    {
        [SerializeField] private GameObject loosePanel;

        private GameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine) => _gameStateMachine = gameStateMachine;

        private void Start() => Bind();

        private void OnDestroy() => Expose();

        private void Loose(Type stateType)
        {
            if (stateType == typeof(GameEndState))
                loosePanel.SetActive(true);
        }

        private void Bind() => _gameStateMachine.OnStateChanged += Loose;

        private void Expose() => _gameStateMachine.OnStateChanged -= Loose;
    }
}