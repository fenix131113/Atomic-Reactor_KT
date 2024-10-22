using System;
using System.Collections.Generic;

namespace Core.StateMachine.GameStates
{
    public class GameStatesContainer
    {
        private readonly Dictionary<Type, State> _states = new();

        public void RegisterState(State state)
        {
            if (_states.ContainsKey(state.GetType()))
                throw new ArgumentException("State" + state.GetType() + " already registered");
            
            _states.Add(state.GetType(), state);
        }
        
        public State GetState(Type type)
        {
            if (_states.ContainsKey(type))
                return _states.GetValueOrDefault(type);

            throw new ArgumentException("The type " + type + " is not registered.");
        }
    }
}