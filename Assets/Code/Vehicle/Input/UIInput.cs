using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Vehicle.Input
{
    public class UIInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private EventTrigger leftInput;
        [SerializeField] private EventTrigger rightInput;
        
        public event Action OnMovePressed;
        public event Action OnMoveReleased;
        public event Action OnBreakPressed;
        public event Action OnBreakReleased;

        private void Awake()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            EventTrigger.Entry rightDown = new EventTrigger.Entry();
            rightDown.eventID = EventTriggerType.PointerDown;
            rightDown.callback.AddListener( (eventData) => { OnMovePressed?.Invoke(); } );
            rightInput.triggers.Add(rightDown);
            
            EventTrigger.Entry rightUp = new EventTrigger.Entry();
            rightUp.eventID = EventTriggerType.PointerUp;
            rightUp.callback.AddListener( (eventData) => { OnMoveReleased?.Invoke(); } );
            rightInput.triggers.Add(rightUp);
            
            EventTrigger.Entry leftDown = new EventTrigger.Entry();
            leftDown.eventID = EventTriggerType.PointerDown;
            leftDown.callback.AddListener( (eventData) => { OnBreakPressed?.Invoke(); } );
            leftInput.triggers.Add(leftDown);
            
            EventTrigger.Entry leftUp = new EventTrigger.Entry();
            leftUp.eventID = EventTriggerType.PointerUp;
            leftUp.callback.AddListener( (eventData) => { OnBreakReleased?.Invoke(); } );
            leftInput.triggers.Add(leftUp);
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
