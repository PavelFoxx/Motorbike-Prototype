using UnityEngine;

namespace Code.Camera
{
    public class CameraTarget : MonoBehaviour, ITarget
    {
        private Transform _transform;
        
        public Vector3 Position => _transform.position;
        private void Awake()
        {
            _transform = transform;
        }
    }
}