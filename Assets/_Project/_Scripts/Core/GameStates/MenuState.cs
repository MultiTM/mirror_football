using _Project._Scripts.Services;

namespace _Project._Scripts.Core.GameStates
{
    public class MenuState : GameStateBase
    {
        private SceneLoadService _sceneLoadService;

        public MenuState(SceneLoadService sceneLoadService)
        {
            _sceneLoadService = sceneLoadService;
        }
        
        public override void Enter()
        {
            _sceneLoadService.LoadMenuScene();
        }
    }
}