using Code.Gameplay.Wheelie.Interfaces;
using Code.Vehicle;
using UniRx;
using UnityEngine;

namespace Code.Gameplay.Wheelie
{
    public class WheelieCounter : MonoBehaviour, IWheelieCounter
    {
        [SerializeField] private WheelGroundCheck frontWheel;
        [SerializeField] private WheelGroundCheck rearWheel;
        
        public ReactiveProperty<bool> IsWheelie { get; private set; }
        public ReactiveProperty<float> WheelieTimer { get; private set; }

        private void Awake()
        {
            Construct();
        }

        private void Construct()
        {
            WheelieTimer = new ReactiveProperty<float>();
            IsWheelie = new ReactiveProperty<bool>();
        }

        private void Update()
        {
            if (!frontWheel.IsGrounded && rearWheel.IsGrounded)
            {
                WheelieTimer.Value += Time.deltaTime;
                if (!IsWheelie.Value && WheelieTimer.Value > 0.5f)
                {
                    IsWheelie.Value = true;
                }
            }
            else
            {
                WheelieTimer.Value = 0;
                if (IsWheelie.Value)
                {
                    IsWheelie.Value = false;
                }
            }
        }
    }
}
