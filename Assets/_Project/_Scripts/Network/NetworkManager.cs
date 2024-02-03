using _Project._Scripts.Network.Messages;
using Mirror;

namespace _Project._Scripts.Network
{
    public class NetworkManager : Mirror.NetworkManager
    {
        private PlayerConnectionState _playerConnectionState = PlayerConnectionState.Disconnected;
        
        public override void OnStartServer()
        {
            NetworkServer.RegisterHandler<SpawnPlayerMessage>(OnSpawnPlayer);
        }

        [Server]
        private void OnSpawnPlayer(NetworkConnectionToClient connection, SpawnPlayerMessage message)
        {
            _playerConnectionState = PlayerConnectionState.Spawned;
        }
        
        public override void OnClientConnect()
        {
            base.OnClientConnect();
            _playerConnectionState = PlayerConnectionState.Connected;
        }
    }
}