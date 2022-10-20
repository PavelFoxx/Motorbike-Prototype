using System;
using Code.Gameplay.Distance.Interfaces;
using UniRx;
using UnityEngine;

namespace Code.Gameplay.Distance
{
    public class DistanceTraveled : MonoBehaviour, IDistanceTraveled
    {
        [SerializeField] private Transform bodyLookup;

        private Vector3 _initPosition;
        private Vector3 CurrentPosition => bodyLookup.position;
        private int CurrentDistance => Mathf.CeilToInt(Vector3.Distance(_initPosition, CurrentPosition));
        public ReactiveProperty<int> Distance { get; private set; }

        private void Awake()
        {
            Distance = new ReactiveProperty<int>();
        }

        private void Start()
        {
            _initPosition = bodyLookup.position;
        }

        private void Update()
        {
            if (CurrentDistance > Distance.Value)
                Distance.Value = CurrentDistance;
        }
    }
}
