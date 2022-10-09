using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Camera
{
    public class CameraFollow : MonoBehaviour, ICameraFollow
    {
        private Transform _transform;
        private ITarget _target;
        
        [SerializeField] private Vector3 offset;

        [Inject]
        private void Construct(ITarget target)
        {
            _target = target;
        }
        
        private void Awake()
        {
            _transform = transform;
        }

        private void FixedUpdate()
        {
            var position = transform.position;
            var position1 = _target.Position;
            _transform.position = new Vector3(position1.x, position1.y, position.z) + offset;
        }
    }
}
