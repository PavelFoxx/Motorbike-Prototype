using System;
using Code.Gameplay.Distance.Interfaces;
using UnityEngine;

namespace Code.Gameplay.Distance
{
    public class DistanceTraveled : MonoBehaviour, IDistanceTraveled
    {
        [SerializeField] private Transform bodyLookup;

        private Vector3 _initPosition;
        private Vector3 CurrentPosition => bodyLookup.position;
        private int CurrentDistance => Mathf.CeilToInt(Vector3.Distance(_initPosition, CurrentPosition));
        private int _maxDistance;
        public int Distance => _maxDistance;
        public event Action<int> OnDistanceChanged = delegate(int distance) { };
        
        private void Start()
        {
            _initPosition = bodyLookup.position;
        }

        private void Update()
        {
            if (CurrentDistance > _maxDistance)
            {
                _maxDistance = CurrentDistance;
                OnDistanceChanged?.Invoke(Distance);
            }
        }
    }
}
