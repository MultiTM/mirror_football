using System.Collections.Generic;
using System.Linq;
using _Project._Scripts.Core;
using Mirror;
using UnityEngine;

namespace _Project._Scripts.Network
{
    public class PlayerManager
    {
        private readonly Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public void AddPlayer(Player player)
        {
            var id = _players.Count;
            player.SetId(id);
            _players.Add(id, player);
        }

        public void RemovePlayer(Player player)
        {
            _players.Remove(player.Id);
        }

        public Player GetPlayer(int id)
        {
            return _players[id];
        }

        public Player[] GetPlayers()
        {
            return _players.Values.ToArray();
        }
    }
}