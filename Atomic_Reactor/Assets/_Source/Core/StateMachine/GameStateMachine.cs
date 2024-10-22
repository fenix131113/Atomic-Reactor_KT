using System;
using Core.StateMachine.GameStates;

namespace Core.StateMachine
{
    public class GameStateMachine
    {
        private State _currentState;
        private GameStatesContainer _statesContainer;

        public event Action<Type> OnStateChanged;
        
        public void Init(GameStatesContainer gameStatesContainer) => _statesContainer = gameStatesContainer;

        public void SetState(Type stateType)
        {
            _currentState?.Exit();
            _currentState = _statesContainer.GetState(stateType);
            _currentState?.Enter();
            
            OnStateChanged?.Invoke(stateType);
        }
    }
}