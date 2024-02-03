using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Services;
using Zenject;

namespace _Project._Scripts.Core
{
    public class GameplayFlow : IInitializable
    {
        private Game _game;
        
        public GameplayFlow(GameplayFlowProvider gameplayFlowProvider, Game game)
        {
            gameplayFlowProvider.SetFlow(this);
            _game = game;
        }
        
        public void Initialize()
        {
            _game.EnterState<LobbyState>();
        }
    }
}