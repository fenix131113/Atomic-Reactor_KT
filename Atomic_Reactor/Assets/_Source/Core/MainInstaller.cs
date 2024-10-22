using Core.StateMachine;
using Core.StateMachine.GameStates;
using ResourceSystem.Services;
using ResourceSystem.View;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private MonoTimerHandler timerHandler;
        [SerializeField] private RecordView recordView;
        
        private readonly GameStatesContainer _gameStatesContainer = new();
        private readonly GameStateMachine _gameStateMachine = new();
        private readonly GameInfo _gameInfo = new();
        
        public override void InstallBindings()
        {
            InitTimer();
            BindCore();
            BindStateMachine();
            BindStates();
        }

        private void BindStates()
        {
            _gameStateMachine.Init(_gameStatesContainer);
            
            _gameStatesContainer.RegisterState(new GameLoopState(_gameInfo));
            _gameStatesContainer.RegisterState(new GameEndState(_gameInfo));
            
            _gameStateMachine.SetState(typeof(GameLoopState));

            Container.Bind<GameStatesContainer>()
                .FromInstance(_gameStatesContainer)
                .AsSingle()
                .NonLazy();
        }

        private void BindCore()
        {
            Container.Bind<GameInfo>()
                .FromInstance(_gameInfo)
                .AsSingle()
                .NonLazy();
        }

        private void InitTimer()
        {
            ResourceTimerService.Instance.Init(timerHandler);
        }

        private void BindStateMachine()
        {
            Container.Bind<GameStateMachine>()
                .FromInstance(_gameStateMachine)
                .AsSingle()
                .NonLazy();
        }
    }
}
