using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class Player : NetworkBehaviour
    {
        [SerializeField] private PlayerPointsView _pointsView;
        [SerializeField] private Cannon _cannon;
        
        [SyncVar] private int _points;
        [SyncVar] private int _id;
        [SyncVar] private Color _color;

        public int Id => _id;
        public Color Color => _color;

        public override void OnStartClient()
        {
            _cannon.SetColor(_color);
        }

        [ClientRpc]
        public void RpcSetId(int id)
        {
            _id = id;
        }

        [ClientRpc]
        public void RpcSetPoints(int points)
        {
            _points = points;
        }

        [ClientRpc]
        public void RpcAddPoints(int points)
        {
            _points += points;
            _pointsView.SetPoints(_points);
        }

        [ClientRpc]
        public void RpcSetColor(Color color)
        {
            _color = color;
            _cannon.SetColor(_color);
        }
    }
}