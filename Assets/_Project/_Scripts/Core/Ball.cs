using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(NetworkRigidbodyReliable))]
    public class Ball : NetworkBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        public Rigidbody Rigidbody => _rigidbody;
    }
}