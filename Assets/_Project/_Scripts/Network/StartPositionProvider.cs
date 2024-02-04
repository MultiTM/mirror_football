using Mirror;
using UnityEngine;

namespace _Project._Scripts.Network
{
    public class StartPositionProvider : MonoBehaviour
    {
        [SerializeField] private NetworkPlayerStartPosition[] _positions;
        
        private int _index = 0;

        [Server]
        public NetworkPlayerStartPosition GetPosition()
        {
            _index++;
            _index %= _positions.Length;
            return _positions[_index];
        }
    }
}