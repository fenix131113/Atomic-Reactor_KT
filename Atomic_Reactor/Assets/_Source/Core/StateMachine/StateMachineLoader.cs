using Core.StateMachine.GameStates;
using Zenject;

namespace Core.StateMachine
{
    public class StateMachineLoader
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly GameInfo _gameInfo;
        private readonly GameStatesContainer _gameStatesContainer;

        [Inject]
        public StateMachineLoader(GameStateMachine gameStateMachine, GameInfo gameInfo,
            GameStatesContainer gameStatesContainer)
        {
            _gameStateMachine = gameStateMachine;
            _gameInfo = gameInfo;
            _gameStatesContainer = gameStatesContainer;

            Load();
        }

        private void Load()
        {
            _gameStateMachine.Init(_gameStatesContainer);

            _gameStatesContainer.RegisterState(new GameLoopState(_gameInfo));
            _gameStatesContainer.RegisterState(new GameEndState(_gameInfo));

            _gameStateMachine.SetState(typeof(GameLoopState));
        }
    }
}