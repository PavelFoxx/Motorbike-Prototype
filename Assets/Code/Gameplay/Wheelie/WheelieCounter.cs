using System;
using Code.Gameplay.Wheelie.Interfaces;
using Code.Vehicle;
using UnityEngine;

namespace Code.Gameplay.Wheelie
{
    public class WheelieCounter : MonoBehaviour, IWheelieCounter
    {
        [SerializeField] private WheelGroundCheck frontWheel;
        [SerializeField] private WheelGroundCheck rearWheel;
        
        public bool IsWheelie { get; private set; }
        public float WheelieTimer => _wheelieTimer;
        private float _wheelieTimer;
        
        public event Action OnBeginWheelie = delegate { };
        public event Action OnEndWheelie = delegate { };
        
        private void Update()
        {
            if (!frontWheel.IsGrounded && rearWheel.IsGrounded)
            {
                _wheelieTimer += Time.deltaTime;
                if (!IsWheelie)
                {
                    IsWheelie = true;
                    OnBeginWheelie?.Invoke();
                }
            }
            else
            {
                _wheelieTimer = 0;
                if (IsWheelie)
                {
                    IsWheelie = false;
                    OnEndWheelie?.Invoke();
                }
            }
        }
    }
}
