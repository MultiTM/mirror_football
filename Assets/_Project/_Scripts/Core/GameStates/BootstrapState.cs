using _Project._Scripts.Configs;
using _Project._Scripts.Network;

namespace _Project._Scripts.Core.GameStates
{
    public class BootstrapState : GameStateBase
    {
        private NetworkManager _networkManager;
        private SceneProvider _sceneProvider;

        public BootstrapState(NetworkManager networkManager, SceneProvider sceneProvider)
        {
            _networkManager = networkManager;
            _sceneProvider = sceneProvider;
        }
        
        public override void Enter()
        {
            InitGame();
            _game.EnterState<MenuState>();
        }

        private void InitGame()
        {
            _networkManager.offlineScene = _sceneProvider.MenuScene;
            _networkManager.onlineScene = _sceneProvider.GameplayScene;
        }
    }
}