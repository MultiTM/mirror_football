using _Project._Scripts.Core;
using _Project._Scripts.Network.Messages;
using _Project._Scripts.Services;
using Mirror;
using UnityEngine;

namespace _Project._Scripts.Network
{
    public class NetworkManager : Mirror.NetworkManager
    {
        [SerializeField] private PlayerSpawnPositionProvider _spawnPositionProvider;
        
        private PlayerConnectionState _playerConnectionState = PlayerConnectionState.Disconnected;
        
        public override void OnStartServer()
        {
            NetworkServer.RegisterHandler<SpawnPlayerMessage>(OnSpawnPlayer);
        }

        [Server]
        private void OnSpawnPlayer(NetworkConnectionToClient connection, SpawnPlayerMessage message)
        {
            var spawnPosition = _spawnPositionProvider.GetSpawnPosition();
            var player = Instantiate(playerPrefab, spawnPosition.position, spawnPosition.rotation);
            NetworkServer.AddPlayerForConnection(connection, player);
            var con = player.GetComponent<NetworkIdentity>().connectionToClient;
            player.GetComponent<Cannon>().RpcDisableMainCamera(con);
        }
        
        public override void OnClientConnect()
        {
            base.OnClientConnect();
            _playerConnectionState = PlayerConnectionState.Connected;
        }

        public override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.Space) && _playerConnectionState == PlayerConnectionState.Connected)
            {
                NetworkClient.Send(new SpawnPlayerMessage());
                _playerConnectionState = PlayerConnectionState.Spawned;
            }
        }
    }
}