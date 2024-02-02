using UnityEditor;
using UnityEngine;

namespace _Project._Scripts.Configs
{
    [CreateAssetMenu(menuName = "Settings/SceneProvider")]
    public class SceneProvider : ScriptableObject
    {
        [SerializeField] private SceneAsset _menuScene;
        [SerializeField] private SceneAsset _gameplayScene;
        
        private string _menuSceneName;
        private string _gameplaySceneName;
        
        public string MenuScene => _menuSceneName;
        public string GameplayScene => _gameplaySceneName;

        private void OnValidate()
        {
            if (_menuScene != null)
            {
                _menuSceneName = _menuScene.name;
            }

            if (_gameplayScene != null)
            {
                _gameplaySceneName = _gameplayScene.name;
            }
        }
    }
}