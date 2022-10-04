using System;
using UnityEngine;

namespace Code.Gameplay.Distance
{
    public class DistanceTraveled : MonoBehaviour
    {
        [SerializeField] private Transform bodyLookup;

        private Vector3 _initPosition;
        private Vector3 CurrentPosition => bodyLookup.position;
        private float CurrentDistance => Vector3.Distance(_initPosition, CurrentPosition);
        private float _maxDistance;
        public float Distance => _maxDistance;
        
        private void Start()
        {
            _initPosition = bodyLookup.position;
        }

        private void Update()
        {
            if (CurrentDistance > _maxDistance)
                _maxDistance = CurrentDistance;
        }
    }
}
