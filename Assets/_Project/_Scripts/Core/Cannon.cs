using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class Cannon : NetworkBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _cannonHolder;
        [SerializeField] private Transform _cannon;
        [SerializeField] private float _sensitivity = 1f;

        public override void OnStartLocalPlayer()
        {
            _camera.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (!isOwned)
            {
                return;
            }

            ProcessRotation();
        }

        private void ProcessRotation()
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");

            _cannonHolder.Rotate(Vector3.up * (mouseX * _sensitivity));
            _cannon.transform.Rotate(-Vector3.right * (mouseY * _sensitivity));
        }
    }
}