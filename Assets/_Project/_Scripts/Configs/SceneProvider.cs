#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace _Project._Scripts.Configs
{
    [CreateAssetMenu(menuName = "Settings/SceneProvider")]
    public class SceneProvider : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset _menuScene;
        [SerializeField] private SceneAsset _gameplayScene;
#endif
        
        [SerializeField][HideInInspector] private string _menuSceneName;
        [SerializeField][HideInInspector] private string _gameplaySceneName;
        
        public string MenuScene => _menuSceneName;
        public string GameplayScene => _gameplaySceneName;

#if UNITY_EDITOR
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
#endif
    }
}