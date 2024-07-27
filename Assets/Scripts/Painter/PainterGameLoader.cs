using System;
using System.Collections.Generic;
using Core;
using PainterTest.Services;
using UnityEngine;
using Zenject;
using ITickable = Core.ITickable;

namespace PainterTest
{
    public class PainterGameLoader : MonoBehaviour
    {
        private PainterTestGameStateMachine _gameStateMachine;
        private List<GameState> _gameStates;

        private List<ITickable> _rootTickables = new List<ITickable>();
        
        // States
        private PaintingState _paintingState;

        [Inject]
        public void Constructor(PaintingState paintingState)
        {
            _paintingState = paintingState;
        }
        
        // Stating point of application
        private void Start()
        {
            
            InitStateMachine();
            InitTickables();
            StartInitialState();
        }

        private void InitStateMachine()
        {
            _gameStateMachine = new PainterTestGameStateMachine();
            _gameStates = CreateGameStates();
            _gameStateMachine.RegisterStates(_gameStates);
        }

        private List<GameState> CreateGameStates()
        {
            List<GameState> gameStates = new List<GameState>();
            
            gameStates.Add(_paintingState);
            
            return gameStates;
        }

        private void InitTickables()
        {
            _rootTickables.Add(_gameStateMachine);
        }

        private void StartInitialState()
        {
            _gameStateMachine.SetState<PaintingState>();
        }

        private void Update()
        {
            foreach (ITickable rootTickable in _rootTickables)
            {
                rootTickable.Tick();
            }
        }
    }
}