using _Project._Scripts.Configs;
using _Project._Scripts.Core;
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
        [SerializeField] private Gate _gatePrefab;

        private GameConfig _gameConfig;
        private GameplayServicesProvider _servicesProvider;
        private ConnectingState _connectingState;
        private int _playerCount;

        [Inject]
        private void Construct(ConnectingState connectingState, GameplayServicesProvider servicesProvider, GameConfig gameConfig)
        {
            _connectingState = connectingState;
            _servicesProvider = servicesProvider;
            _gameConfig = gameConfig;
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
            var startPosition = _servicesProvider.Services.StartPositionProvider.GetPosition();
            var playerGO = Instantiate(playerPrefab, startPosition.CannonStartPosition.position, startPosition.CannonStartPosition.rotation);
            var player = playerGO.GetComponent<Player>();
            NetworkServer.AddPlayerForConnection(conn, player.gameObject);
            player.RpcSetId(_playerCount++);
            player.RpcSetColor(message.Color);
            player.RpcSetPoints(_gameConfig.InitialPoints);
            
            var gate = Instantiate(_gatePrefab, startPosition.GateStartPosition.position, startPosition.GateStartPosition.rotation);
            NetworkServer.Spawn(gate.gameObject);
            gate.SetPlayer(player);
            gate.SetTargetPositions(startPosition.GateTargetPositions);
            gate.RpcSetColor(message.Color);
        }

        public override void OnStopServer()
        {
            _playerCount = 0;
        }
        
        #endregion
    }
}