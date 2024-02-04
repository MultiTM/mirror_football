using UnityEngine;
using UnityEngine.Serialization;

namespace _Project._Scripts.Configs
{
    [CreateAssetMenu(menuName = "Settings/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private int _initialPoints = 10;
        [SerializeField] private Color[] _playerColors;
        
        public int InitialPoints => _initialPoints;
        public Color[] PlayerColors => _playerColors;
    }
}