using System;
using Code.Vehicle.Input;
using UnityEngine;

namespace Code.Vehicle
{
    public class EngineControl : MonoBehaviour
    {
        private EngineDataStruct _engineData;
        private IPlayerInput _input;
        
        [SerializeField] private Rigidbody2D rearWheelRb;
        [SerializeField] private Rigidbody2D frontWheelRb;
        [SerializeField] private HingeJoint2D motorJoint;
        [SerializeField] private Rigidbody2D bodyRb;

        private bool _isMovePressed;
        private bool _isBreakPressed;

        private bool _isSubscribed = false;
        
        public void Construct(EngineDataStruct engineData, IPlayerInput input)
        {
            _engineData = engineData;
            rearWheelRb.sharedMaterial = engineData.wheelMaterial;
            frontWheelRb.sharedMaterial = engineData.wheelMaterial;
            _input = input;

            Subscribe();
        }

        private void Subscribe()
        {
            _input.OnMovePressed += OnMovePressed;
            _input.OnMoveReleased += OnMoveReleased;
            _input.OnBreakPressed += OnBreakPressed;
            _input.OnBreakReleased += OnBreakReleased;

            _isSubscribed = true;
        }

        private void OnMovePressed()
        {
            if (!_isBreakPressed)
                RunMotor();
            else
                RunBreaks();
            
            _isMovePressed = true;
        }

        private void OnMoveReleased()
        {
            if(_isBreakPressed)
                RunBreaks();
            else
                RunIdle();
            
            _isMovePressed = false;
        }

        private void OnBreakPressed()
        {
            RunBreaks();
            _isBreakPressed = true;
        }

        private void OnBreakReleased()
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

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            if (_isSubscribed)
            {
                _input.OnMovePressed -= OnMovePressed;
                _input.OnMoveReleased -= OnMoveReleased;
                _input.OnBreakPressed -= OnBreakPressed;
                _input.OnBreakReleased -= OnBreakReleased;
            }
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
