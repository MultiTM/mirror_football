using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class Gate : NetworkBehaviour
    {
        [SerializeField] private Player _player;

        private const int PointsPerGoal = 1;

        [ServerCallback]
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Ball>(out var ball))
            {
                if (ball.Player.Id != _player.Id)
                {
                    ball.Player.RpcAddPoints(PointsPerGoal);
                    _player.RpcAddPoints(-PointsPerGoal);
                    NetworkServer.Destroy(ball.gameObject);
                }
            }
        }
    }
}