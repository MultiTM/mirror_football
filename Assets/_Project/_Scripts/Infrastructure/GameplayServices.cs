using _Project._Scripts.Core;
using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Services;
using _Project._Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure
{
    public class GameplayServices : IInitializable
    {
        private GameplayServicesProvider _provider;
        private Game _game;
        private LobbyCamera _lobbyCamera;
        private LobbyUI _lobbyUI;
        
        public LobbyCamera LobbyCamera => _lobbyCamera;
        public LobbyUI LobbyUI => _lobbyUI;

        public GameplayServices(
            GameplayServicesProvider provider,
            Game game,
            LobbyCamera lobbyCamera,
            LobbyUI lobbyUI)
        {
            _provider = provider;
            _game = game;
            _lobbyCamera = lobbyCamera;
            _lobbyUI = lobbyUI;
        }
        
        public void Initialize()
        {
            Debug.Log("EnterLobby");
            _provider.SetServices(this);
            _game.EnterState<LobbyState>();
        }
    }
}