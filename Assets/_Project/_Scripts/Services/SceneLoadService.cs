using _Project._Scripts.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace _Project._Scripts.Services
{
    public class SceneLoadService
    {
        private SceneProvider _sceneProvider;
        
        public SceneLoadService(SceneProvider sceneProvider)
        {
            _sceneProvider = sceneProvider;
        }

        public async void LoadMenuScene()
        {
            await LoadSceneAsync(_sceneProvider.MenuScene);
        }

        public async void LoadGameplayScene()
        {
            await LoadSceneAsync(_sceneProvider.GameplayScene);
        }
        
        public async void UnloadMenuScene()
        {
            await UnloadSceneAsync(_sceneProvider.MenuScene);
        }

        public async void UnloadGameplayScene()
        {
            await UnloadSceneAsync(_sceneProvider.GameplayScene);
        }
        
        private async UniTask LoadSceneAsync(string sceneName)
        {
            await SceneManager.LoadSceneAsync(sceneName);
        }

        private async UniTask UnloadSceneAsync(string sceneName)
        {
            await SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}