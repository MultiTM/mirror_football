using Mirror;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class Cannon : NetworkBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Camera _camera;
        [Header("Rotation")]
        [SerializeField] private Transform _cannon;
        [SerializeField] private Transform _cannonHolder;
        [SerializeField] private float _sensitivity = 1f;
        [Header("Shooting")]
        [SerializeField] private Transform _ballSpawnPoint;
        [SerializeField] private Vector3 _shootingForce;
        [SerializeField] private Ball _ballPrefab;
        [Header("Visuals")]
        [SerializeField] private MeshRenderer _cannonMesh;
        
        private float _shootingStrength = 0f;

        public override void OnStartLocalPlayer()
        {
            _camera.gameObject.SetActive(true);
        }

        [ClientCallback]
        private void Update()
        {
            if (!isOwned)
            {
                return;
            }
            
            ProcessRotation();
            ProcessShooting();
        }

        private void ProcessRotation()
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");

            _cannonHolder.Rotate(Vector3.up * (mouseX * _sensitivity));
            _cannon.transform.Rotate(-Vector3.right * (mouseY * _sensitivity));
        }

        private void ProcessShooting()
        {
            if (Input.GetMouseButton(0))
            {
                _shootingStrength = Mathf.Clamp(_shootingStrength + Time.deltaTime, 0f, 1f);
            }

            if (Input.GetMouseButtonUp(0) && _shootingStrength > 0f)
            {
                CmdShoot(_shootingStrength);
                _shootingStrength = 0;
            }
        }

        [Command]
        private void CmdShoot(float strength)
        {
            var ball = Instantiate(_ballPrefab, _ballSpawnPoint.position, _ballSpawnPoint.rotation);
            NetworkServer.Spawn(ball.gameObject);
            ball.SetPlayer(_player);
            
            var force = _ballSpawnPoint.rotation * (_shootingForce * strength);
            ball.Rigidbody.AddForce(force, ForceMode.Impulse);
        }

        [Client]
        public void SetColor(Color color)
        {
            var mpb = new MaterialPropertyBlock();
            mpb.SetColor("_BaseColor", color);
            _cannonMesh.SetPropertyBlock(mpb);
        }
    }
}