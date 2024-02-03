using UnityEngine;

namespace _Project._Scripts.Core
{
    public class LobbyCamera : MonoBehaviour
    {
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