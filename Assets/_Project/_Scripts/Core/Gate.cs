using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class Gate : NetworkBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private MeshRenderer _meshRenderer;
        
        private Player _player;
        private const int PointsPerGoal = 1;
        private Transform[] _targetPositions;
        private int _targetPositionIndex = 0;
        
        [SyncVar] private Color _color;

        public override void OnStartClient()
        {
            ApplyColor();
        }

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public void SetTargetPositions(Transform[] positions)
        {
            _targetPositions = positions;
        }

        [ClientRpc]
        public void RpcSetColor(Color color)
        {
            _color = color;
            ApplyColor();
        }

        private void ApplyColor()
        {
            var mpb = new MaterialPropertyBlock();
            mpb.SetColor("_BaseColor", _color);
            _meshRenderer.SetPropertyBlock(mpb);
        }

        [ServerCallback]
        private void Update()
        {
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            if (_targetPositions.Length == 0)
            {
                return;
            }

            var currentTarget = _targetPositions[_targetPositionIndex];
            var direction = currentTarget.position - transform.position;
            if (direction.magnitude < 0.1f)
            {
                _targetPositionIndex = GetNextTargetPositionIndex(_targetPositionIndex);
                return;
            }

            direction.Normalize();
            transform.position += direction * (_speed * Time.deltaTime);
        }

        private int GetNextTargetPositionIndex(int index)
        {
            index++;
            index %= _targetPositions.Length;

            return index;
        }

        [ServerCallback]
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Ball>(out var ball))
            {
                if (ball.Player.Id != _player.Id)
                {
                    ball.Player.RpcAddPoints(PointsPerGoal);
                    _player.RpcAddPoints(-PointsPerGoal);
                }
                
                NetworkServer.Destroy(ball.gameObject);
            }
        }
    }
}