using UnityEngine;

namespace _Project._Scripts.Services
{
    public class LobbyCameraProvider
    {
        private Camera _camera;

        public Camera LobbyCamera => _camera;

        public void SetCamera(Camera camera)
        {
            _camera = camera;
        }
    }
}