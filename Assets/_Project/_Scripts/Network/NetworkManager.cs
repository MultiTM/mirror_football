using _Project._Scripts.Core;
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
        // private PlayerManager _playerManager;

        [Inject]
        // private void Construct(ConnectingState connectingState, PlayerManager playerManager)
        private void Construct(ConnectingState connectingState)
        {
            _connectingState = connectingState;
            // _playerManager = playerManager;
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
            NetworkServer.RegisterHandler<PlayerReadyMessage>(OnPlayerReady);
        }

        private void OnPlayerReady(NetworkConnectionToClient conn, PlayerReadyMessage message)
        {
            var spawnTransform = GetStartPosition();
            var playerGO = Instantiate(playerPrefab, spawnTransform.position, spawnTransform.rotation);
            NetworkServer.AddPlayerForConnection(conn, playerGO);
            var player = playerGO.GetComponent<Player>();
            // _playerManager.AddPlayer(player);
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            var player = conn.identity.GetComponent<Player>();
            // _playerManager.RemovePlayer(player);
            base.OnServerDisconnect(conn);
        }
    }
}