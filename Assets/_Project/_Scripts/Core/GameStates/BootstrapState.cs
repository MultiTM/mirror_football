using _Project._Scripts.Configs;
using _Project._Scripts.Network;
using _Project._Scripts.Services;

namespace _Project._Scripts.Core.GameStates
{
    public class BootstrapState : GameStateBase
    {
        private NetworkManager _networkManager;
        private SceneProvider _sceneProvider;
        private SceneLoadService _sceneLoadService;

        public BootstrapState(NetworkManager networkManager, SceneProvider sceneProvider, SceneLoadService sceneLoadService)
        {
            _networkManager = networkManager;
            _sceneProvider = sceneProvider;
            _sceneLoadService = sceneLoadService;
        }
        
        public override async void Enter()
        {
            InitGame();
            await _sceneLoadService.LoadMenuScene();
        }

        private void InitGame()
        {
            _networkManager.offlineScene = _sceneProvider.MenuScene;
            _networkManager.onlineScene = _sceneProvider.GameplayScene;
        }
    }
}