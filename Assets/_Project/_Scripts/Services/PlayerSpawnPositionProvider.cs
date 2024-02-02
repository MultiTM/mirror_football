using Mirror;
using UnityEngine;

namespace _Project._Scripts.Services
{
    public class PlayerSpawnPositionProvider : NetworkBehaviour
    {
        [SerializeField] private Transform[] _positions;
        private int _usedPositionsCount = 0;

        public Transform GetSpawnPosition()
        {
            return _positions[_usedPositionsCount++];
        }
    }
}