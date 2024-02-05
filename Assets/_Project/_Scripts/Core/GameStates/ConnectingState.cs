using _Project._Scripts.Services;
using Mirror;

namespace _Project._Scripts.Core.GameStates
{
    public class ConnectingState : GameStateBase
    {
        private SceneLoadService _sceneLoadService;
        
        public ConnectingState(SceneLoadService sceneLoadService)
        {
            _sceneLoadService = sceneLoadService;
        }
        
        public async void OnConnectionFailed()
        {
            NetworkClient.Shutdown();
            await _sceneLoadService.LoadMenuScene();
        }

        public void OnConnected()
        {
            _game.EnterState<GameplayInitState>();
        }

        public async void OnDisconnected()
        {
            NetworkClient.Shutdown();
            await _sceneLoadService.LoadMenuScene();
        }
    }
}