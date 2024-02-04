using Mirror;

namespace _Project._Scripts.Core.GameStates
{
    public class ConnectingState : GameStateBase
    {
        public void OnConnectionFailed()
        {
            NetworkClient.Shutdown();
            _game.EnterState<MenuState>();
        }

        public void OnConnected()
        {
            _game.EnterState<GameplayInitState>();
        }

        public void OnDisconnected()
        {
            NetworkClient.Shutdown();
            _game.EnterState<MenuState>();
        }
    }
}