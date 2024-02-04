using _Project._Scripts.Services;

namespace _Project._Scripts.Core.GameStates
{
    public class GameplayInitState : GameStateBase
    {
        private GameplayServicesProvider _provider;

        public GameplayInitState(GameplayServicesProvider provider)
        {
            _provider = provider;
        }

        public override void Enter()
        {
            if (_provider.Services != null) // possible race condition between services initialization and network manager callback
            {
                _game.EnterState<LobbyState>();
            }
        }
    }
}