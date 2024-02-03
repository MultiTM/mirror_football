using _Project._Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Core
{
    public class LobbyCamera : MonoBehaviour
    {
        [Inject]
        private void Construct(LobbyCameraProvider provider)
        {
            provider.SetCamera(this);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}