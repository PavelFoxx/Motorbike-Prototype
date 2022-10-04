using System;
using UnityEngine;

namespace Code.Vehicle.Input
{
    public class KeysInput : MonoBehaviour, IPlayerInput
    {
        public event Action OnMovePressed;
        public event Action OnMoveReleased;
        public event Action OnBreakPressed;
        public event Action OnBreakReleased;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
                OnMovePressed?.Invoke();

            if (UnityEngine.Input.GetKeyUp(KeyCode.RightArrow))
                OnMoveReleased?.Invoke();
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
                OnBreakPressed?.Invoke();

            if (UnityEngine.Input.GetKeyUp(KeyCode.LeftArrow))
                OnBreakReleased?.Invoke();
        }
    }
}
