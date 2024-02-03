using _Project._Scripts.Core;
using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Network;
using _Project._Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.UI
{
    public class MenuUI : MonoBehaviour
    {
        private NetworkManager _networkManager;
        private Game _game;

        [Inject]
        private void Construct(NetworkManager networkManager, Game game)
        {
            _networkManager = networkManager;
            _game = game;
        }
        
        public void StartHost()
        {
            _networkManager.StartHost();
            _game.EnterState<LobbyState>();
        }

        public void StartClient()
        {
            _networkManager.StartClient();
            _game.EnterState<LobbyState>();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}