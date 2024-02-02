using _Project._Scripts.Services;

namespace _Project._Scripts.Core.GameStates
{
    public class GameplayState : GameStateBase
    {
        private SceneLoadService _sceneLoadService;

        public GameplayState(SceneLoadService sceneLoadService)
        {
            _sceneLoadService = sceneLoadService;
        }
        
        public override void Enter()
        {
            _sceneLoadService.LoadGameplayScene();
        }

        public override void Exit()
        {
            _sceneLoadService.UnloadGameplayScene();
        }
    }
}