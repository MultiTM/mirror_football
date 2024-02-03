using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Network.Messages;
using _Project._Scripts.Services;
using Mirror;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Network
{
    public class NetworkManager : Mirror.NetworkManager
    {
        private GameProvider _gameProvider;

        [Inject]
        private void Construct(GameProvider gameProvider)
        {
            _gameProvider = gameProvider;
        }

        public override void OnClientError(TransportError error, string reason)
        {
            Debug.LogError(reason);
            StopClient();
            _gameProvider.Game.EnterState<MenuState>();
        }

        public override void OnStartServer()
        {
            NetworkServer.RegisterHandler<PlayerSpawnMessage>(OnPlayerReady);
        }

        private void OnPlayerReady(NetworkConnectionToClient conn, PlayerSpawnMessage message)
        {
            var spawnTransform = GetStartPosition();
            var player = Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
}