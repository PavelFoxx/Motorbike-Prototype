using Code.Common.Interfaces;
using Code.Vehicle.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Vehicle
{
    public class EngineControl : MonoBehaviour, IEngineControl
    {
        private EngineDataStruct _engineData;
        
        [SerializeField] private Rigidbody2D rearWheelRb;
        [SerializeField] private Rigidbody2D frontWheelRb;
        [SerializeField] private HingeJoint2D motorJoint;
        [SerializeField] private Rigidbody2D bodyRb;

        private bool _isMovePressed;
        private bool _isBreakPressed;
        
        [Inject]
        public void Construct(IGameTypeSetup gameTypeSetup)
        {
            _engineData = gameTypeSetup.CurrentMotorbike.EngineData;
            rearWheelRb.sharedMaterial = _engineData.wheelMaterial;
            frontWheelRb.sharedMaterial = _engineData.wheelMaterial;
        }


        public void OnMovePressed()
        {
            if (!_isBreakPressed)
                RunMotor();
            else
                RunBreaks();
            
            _isMovePressed = true;
        }

        public void OnMoveReleased()
        {
            if(_isBreakPressed)
                RunBreaks();
            else
                RunIdle();
            
            _isMovePressed = false;
        }

        public void OnBreakPressed()
        {
            RunBreaks();
            _isBreakPressed = true;
        }

        public void OnBreakReleased()
        {
            if(_isMovePressed)
                RunMotor();
            else
                RunIdle();

            _isBreakPressed = false;
        }

        private void RunMotor()
        {
            motorJoint.useMotor = true;
            
            var motorMove = motorJoint.motor;
            motorMove.motorSpeed = _engineData.engineSpeed;
            motorMove.maxMotorTorque = _engineData.engineMaxTorque;
            motorJoint.motor = motorMove;
            
            frontWheelRb.freezeRotation = false;
        }
        private void RunBreaks()
        {
            motorJoint.useMotor = true;
            
            var motorMove = motorJoint.motor;
            motorMove.motorSpeed = 0;
            motorJoint.motor = motorMove;
            
            frontWheelRb.freezeRotation = true;
        }
        private void RunIdle()
        {
            motorJoint.useMotor = false;
            frontWheelRb.freezeRotation = false;
        }

        private void Update()
        {
            if (_isBreakPressed)
                bodyRb.AddTorque(-_engineData.rotateTorque);
            else if (_isMovePressed)
                bodyRb.AddTorque(_engineData.rotateTorque);
        }
    }

    [System.Serializable]
    public struct EngineDataStruct
    {
        public float engineSpeed;
        public float engineMaxTorque;
        public float rotateTorque;
        public PhysicsMaterial2D wheelMaterial;
    }
}
