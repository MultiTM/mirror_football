using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Network.Messages;
using _Project._Scripts.Services;
using Mirror;
using Zenject;

namespace _Project._Scripts.Network
{
    public class NetworkManager : Mirror.NetworkManager
    {
        private GameProvider _gameProvider;
        private PlayerConnectionState _playerConnectionState = PlayerConnectionState.Disconnected;

        [Inject]
        private void Construct(GameProvider gameProvider)
        {
            _gameProvider = gameProvider;
        }
        
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

        public override void OnClientError(TransportError error, string reason)
        {
            _playerConnectionState = PlayerConnectionState.Disconnected;
            StopClient();
            _gameProvider.Game.EnterState<MenuState>();
        }
    }
}