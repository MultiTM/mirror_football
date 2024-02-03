using UnityEngine;

namespace _Project._Scripts.Configs
{
    [CreateAssetMenu(menuName = "Settings/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private int _initialScore = 10;
        [SerializeField] private Color[] _playerColors;
        
        public int InitialScore => _initialScore;
        public Color[] PlayerColors => _playerColors;
    }
}