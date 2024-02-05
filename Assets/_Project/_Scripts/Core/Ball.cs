using System.Threading;
using Cysharp.Threading.Tasks;
using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class Ball : NetworkBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _lifetimeSeconds = 30f;
        private Player _player;
        private CancellationTokenSource _cancellationTokenSource = new(); // cancel network destroy after exit play mode
        
        public Rigidbody Rigidbody => _rigidbody;
        public Player Player => _player;

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public override void OnStartServer()
        {
            UniTask.Create(() => DestroySelfAfterTime(_cancellationTokenSource.Token));
        }

        [ServerCallback]
        public void OnDestroy()
        {
            _cancellationTokenSource.Cancel();
        }

        private async UniTask DestroySelfAfterTime(CancellationToken token)
        {
            await UniTask.Delay(Mathf.RoundToInt(_lifetimeSeconds * 1000));
            if (token.IsCancellationRequested)
            {
                return;
            }
            
            NetworkServer.Destroy(gameObject);
        }
    }
}