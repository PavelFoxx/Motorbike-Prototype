using System;
using UnityEngine;

namespace Code
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _transform;
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offest;

        private void Awake()
        {
            _transform = transform;
        }

        private void FixedUpdate()
        {
            var position = transform.position;
            var position1 = target.position;
            _transform.position = new Vector3(position1.x, position1.y, position.z) + offest;
        }

        public void SetupTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}
