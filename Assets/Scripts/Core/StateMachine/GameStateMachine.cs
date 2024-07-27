using System;
using System.Collections.Generic;

namespace Core
{
    public class GameStateMachine : ITickable
    {
        protected Dictionary<Type, GameState> _gameStates = new Dictionary<Type, GameState>();
        protected GameState _currentState;

        public void RegisterState(GameState gameState)
        {
            Type stateType = gameState.GetType();
            if (_gameStates.ContainsKey(stateType))
            {
                throw new Exception($"State machine already contains state of type: '{stateType}'");
            }
            _gameStates[stateType] = gameState;
        }

        public void RegisterStates(IEnumerable<GameState> gameStates)
        {
            foreach (GameState gameState in gameStates)
            {
                RegisterState(gameState);
            }
        }

        public void ClearStates()
        {
            _gameStates.Clear();
        }

        public void SetState<TType>() where TType : GameState
        {
            Type stateType = typeof(TType);
            
            if(_gameStates.ContainsKey(stateType))
            {
                SetStateInternal(_gameStates[stateType]);
            }
            else
            {
                throw new Exception($"State machine doesn't contain state with '{stateType}' type");
            }
        }

        private void SetStateInternal(GameState gameState)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }
            
            _currentState = gameState;
            
            _currentState.Enter();
        }

        public void Tick()
        {
            _currentState?.Tick();
        }
    }
}