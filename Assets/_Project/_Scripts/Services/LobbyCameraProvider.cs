using _Project._Scripts.Core;
using _Project._Scripts.Core.GameStates;

namespace _Project._Scripts.Services
{
    public class LobbyCameraProvider
    {
        private LobbyCamera _camera;

        public LobbyCamera LobbyCamera => _camera;

        public void SetCamera(LobbyCamera camera)
        {
            _camera = camera;
        }
    }
}