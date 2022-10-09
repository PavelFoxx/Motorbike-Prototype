using System;
using Code.Vehicle.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Code.Vehicle.Input
{
    public class UIInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private EventTrigger leftInput;
        [SerializeField] private EventTrigger rightInput;
        private IEngineControl _engineControl;

        [Inject]
        private void Construct(IEngineControl engineControl)
        {
            _engineControl = engineControl;
        }
        private void Awake()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            EventTrigger.Entry rightDown = new EventTrigger.Entry();
            rightDown.eventID = EventTriggerType.PointerDown;
            rightDown.callback.AddListener( (eventData) => { OnMovePressed(); } );
            rightInput.triggers.Add(rightDown);
            
            EventTrigger.Entry rightUp = new EventTrigger.Entry();
            rightUp.eventID = EventTriggerType.PointerUp;
            rightUp.callback.AddListener( (eventData) => { OnMoveReleased(); } );
            rightInput.triggers.Add(rightUp);
            
            EventTrigger.Entry leftDown = new EventTrigger.Entry();
            leftDown.eventID = EventTriggerType.PointerDown;
            leftDown.callback.AddListener( (eventData) => { OnBreakPressed(); } );
            leftInput.triggers.Add(leftDown);
            
            EventTrigger.Entry leftUp = new EventTrigger.Entry();
            leftUp.eventID = EventTriggerType.PointerUp;
            leftUp.callback.AddListener( (eventData) => { OnBreakReleased(); } );
            leftInput.triggers.Add(leftUp);
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
        
        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            foreach (var trigger in leftInput.triggers)
                trigger.callback.RemoveAllListeners();
            
            foreach (var trigger in rightInput.triggers)
                trigger.callback.RemoveAllListeners();
        }
    }
}
