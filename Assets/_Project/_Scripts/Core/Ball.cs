using Cysharp.Threading.Tasks;
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
        [SerializeField] private float _lifetimeSeconds = 30f;
        private Player _player;
        
        public Rigidbody Rigidbody => _rigidbody;
        public Player Player => _player;

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public override async void OnStartServer()
        {
            await DestroySelfAfterTime();
        }

        private async UniTask DestroySelfAfterTime()
        {
            await UniTask.Delay(Mathf.RoundToInt(_lifetimeSeconds * 1000));
            NetworkServer.Destroy(gameObject);
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