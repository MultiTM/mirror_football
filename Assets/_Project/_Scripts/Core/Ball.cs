using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(NetworkRigidbodyReliable))]
    [RequireComponent(typeof(NetworkIdentity))]
    public class Ball : NetworkBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        private Player _player;
        
        public Rigidbody Rigidbody => _rigidbody;
        public Player Player => _player;

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        [ServerCallback]
        private void Update()
        {
            if (transform.position.y < -5f)
            {
                NetworkServer.Destroy(gameObject);
            }
        }
    }
}