using UnityEngine;

namespace Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform player;
        [SerializeField] private float smoothTime;
        
        private Vector3 _velocity;
        
        private void Update()
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref _velocity, smoothTime);
        }

        private void LateUpdate()
        {
            transform.LookAt(player);
        }
    }
}
