using System.Collections.Generic;
using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Infrastructure;
using _Project._Scripts.StateMachine;

namespace _Project._Scripts.Core
{
    public class Game : StateMachine<IGameState>
    {
        public Game(List<IGameState> states) : base(states)
        {
            InitStates();
            EnterState<BootstrapState>();
        }
        
        private void InitStates()
        {
            foreach (var state in _states)
            {
                state.Init(this);
            }
        }
    }
}