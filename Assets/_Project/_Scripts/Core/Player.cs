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

        public void SetId(int id)
        {
            _id = id;
        }

        public void AddPoints(int points)
        {
            _points += points;
            _pointsView.SetPoints(_points);
        }
    }
}