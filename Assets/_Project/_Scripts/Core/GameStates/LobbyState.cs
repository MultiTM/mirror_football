using _Project._Scripts.Services;

namespace _Project._Scripts.Core.GameStates
{
    public class LobbyState : GameStateBase
    {
        private SceneLoadService _sceneLoadService;

        public LobbyState(SceneLoadService sceneLoadService)
        {
            _sceneLoadService = sceneLoadService;
        }
        
        public override void Enter()
        {
            _sceneLoadService.LoadGameplayScene();
        }
    }
}