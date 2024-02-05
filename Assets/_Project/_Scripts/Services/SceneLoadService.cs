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

        public UniTask LoadMenuScene()
        {
            return LoadSceneAsync(_sceneProvider.MenuScene);
        }
        
        private async UniTask LoadSceneAsync(string sceneName)
        {
            await SceneManager.LoadSceneAsync(sceneName);
        }
    }
}