using _Project._Scripts.Configs;
using _Project._Scripts.Core;
using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Network.Messages;
using Mirror;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project._Scripts.UI
{
    public class LobbyUI : MonoBehaviour
    {
        [SerializeField] private Image _colorPreview;
        
        private Game _game;
        private Color _color;
        private GameConfig _gameConfig;
        private int _colorIndex = 0;

        [Inject]
        private void Construct(Game game, GameConfig gameConfig)
        {
            _game = game;
            _gameConfig = gameConfig;
        }

        private void Start()
        {
            SetPreviewColor(_colorIndex);
        }

        private void SetPreviewColor(int index)
        {
            _colorPreview.color = _gameConfig.PlayerColors[index];
        }

        public void NextColor()
        {
            _colorIndex++;
            _colorIndex %= _gameConfig.PlayerColors.Length;
            SetPreviewColor(_colorIndex);
        }

        public void PreviousColor()
        {
            _colorIndex--;
            if (_colorIndex < 0)
            {
                _colorIndex = _gameConfig.PlayerColors.Length - 1;
            }
            
            _colorIndex %= _gameConfig.PlayerColors.Length;
            
            SetPreviewColor(_colorIndex);
        }

        public void Join()
        {
            if (NetworkClient.isConnected)
            {
                var message = new PlayerReadyMessage();
                message.Color = _gameConfig.PlayerColors[_colorIndex];
                NetworkClient.Send(message);
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