using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Network.Messages;
using Mirror;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Network
{
    public class NetworkManager : Mirror.NetworkManager
    {
        private ConnectingState _connectingState;

        [Inject]
        private void Construct(ConnectingState connectingState)
        {
            _connectingState = connectingState;
        }

        public override void OnClientError(TransportError error, string reason)
        {
            Debug.LogError(reason);
            StopClient();
            _connectingState.OnConnectionFailed();
        }

        public override void OnClientConnect()
        {
            base.OnClientConnect();
            _connectingState.OnConnected();
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