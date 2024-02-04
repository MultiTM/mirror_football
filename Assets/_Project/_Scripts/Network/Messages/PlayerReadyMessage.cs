using Mirror;
using UnityEngine;

namespace _Project._Scripts.Network.Messages
{
    public struct PlayerReadyMessage : NetworkMessage
    {
        public Color Color;
    }
}