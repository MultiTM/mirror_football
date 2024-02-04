using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class Player : NetworkBehaviour
    {
        [SerializeField] private PlayerPointsView _pointsView;
        
        [SyncVar] private int _points;
        [SyncVar] private Color _color;
        [SyncVar] private int _id;

        public int Id => _id;
        public int Points => _points;

        [ClientRpc]
        public void RpcSetId(int id)
        {
            _id = id;
        }

        [ClientRpc]
        public void RpcAddPoints(int points)
        {
            _points += points;
            _pointsView.SetPoints(_points);
        }
    }
}