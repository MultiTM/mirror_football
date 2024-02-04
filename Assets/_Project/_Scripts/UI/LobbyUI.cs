using _Project._Scripts.Core;
using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Network.Messages;
using Mirror;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.UI
{
    public class LobbyUI : MonoBehaviour
    {
        private Game _game;

        [Inject]
        private void Construct(Game game)
        {
            _game = game;
        }
        
        public void Join()
        {
            if (NetworkClient.isConnected)
            {
                NetworkClient.Send(new PlayerReadyMessage());
                _game.EnterState<GameplayState>();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}