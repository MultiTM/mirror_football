namespace _Project._Scripts.Core.GameStates
{
    public class ConnectingState : GameStateBase
    {
        public void OnConnectionFailed()
        {
            _game.EnterState<MenuState>();
        }

        public void OnConnected()
        {
            _game.EnterState<GameplayInitState>();
        }
    }
}