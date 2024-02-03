using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class Player : NetworkBehaviour
    {
        [SerializeField] private Cannon _cannon;
        
        [SyncVar] private int _points;
        [SyncVar] private Color _color;
    }
}