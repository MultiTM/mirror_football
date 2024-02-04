using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class Gate : NetworkBehaviour
    {
        [SerializeField] private Player _player;

        [ServerCallback]
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Ball>(out var ball))
            {
                if (ball.Player.Id != _player.Id)
                {
                    ball.Player.AddPoints(1);
                    _player.AddPoints(-1);
                }
            }
        }
    }
}