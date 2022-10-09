using Code.Vehicle.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Vehicle.Input
{
    public class KeysInput : MonoBehaviour, IPlayerInput
    {
        private IEngineControl _engineControl;

        [Inject]
        private void Construct(IEngineControl engineControl)
        {
            _engineControl = engineControl;
        }
        
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
                OnMovePressed();

            if (UnityEngine.Input.GetKeyUp(KeyCode.RightArrow))
                OnMoveReleased();
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
                OnBreakPressed();

            if (UnityEngine.Input.GetKeyUp(KeyCode.LeftArrow))
                OnBreakReleased();
        }

        public void OnMovePressed()
        {
            _engineControl.OnMovePressed();
        }

        public void OnMoveReleased()
        {
            _engineControl.OnMoveReleased();
        }

        public void OnBreakPressed()
        {
            _engineControl.OnBreakPressed();
        }

        public void OnBreakReleased()
        {
            _engineControl.OnBreakReleased();
        }
    }
}
