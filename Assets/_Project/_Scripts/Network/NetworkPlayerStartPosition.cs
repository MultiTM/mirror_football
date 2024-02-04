using UnityEngine;

namespace _Project._Scripts.Network
{
    public class NetworkPlayerStartPosition : MonoBehaviour
    {
        [SerializeField] private Transform _cannonStartPosition;
        [SerializeField] private Transform _gateStartPosition;
        [SerializeField] private Transform[] _gateTargetPositions;
        
        public Transform CannonStartPosition => _cannonStartPosition;
        public Transform GateStartPosition => _gateStartPosition;
        public Transform[] GateTargetPositions => _gateTargetPositions;
    }
}