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
        private int _playerCount;

        [Inject]
        private void Construct(ConnectingState connectingState)
        {
            _connectingState = connectingState;
        }

        #region Client
        
        public override void OnClientError(TransportError error, string reason)
        {
            Debug.LogError(reason);
            StopClient();
            _connectingState.OnConnectionFailed();
        }

        public override void OnClientDisconnect()
        {
            _connectingState.OnDisconnected();
        }

        public override void OnClientConnect()
        {
            base.OnClientConnect();
            _connectingState.OnConnected();
        }

        #endregion

        #region Server
        
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
            player.RpcSetId(_playerCount++);
            player.RpcSetColor(message.Color);
        }

        public override void OnStopServer()
        {
            _playerCount = 0;
        }
        
        #endregion
    }
}