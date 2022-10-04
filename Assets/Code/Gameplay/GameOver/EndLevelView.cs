using System;
using UnityEngine;

namespace Code.Gameplay.GameOver
{
    public class EndLevelView : MonoBehaviour
    {
        private EndLevelTrigger _endLevelTrigger;
        
        [SerializeField] private Animator fadeAnimator;
        [SerializeField] private string animatorTriggerName = "Fade";
        
        public void Construct(EndLevelTrigger endLevelTrigger)
        {
            _endLevelTrigger = endLevelTrigger;
            Subscribe();
        }

        private void Subscribe()
        {
            _endLevelTrigger.OnEndLevelTriggered += OnEndLevelTriggered;
        }

        private void OnEndLevelTriggered()
        {
            if (fadeAnimator != null)
                fadeAnimator.SetTrigger(animatorTriggerName);
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            _endLevelTrigger.OnEndLevelTriggered -= OnEndLevelTriggered;
        }
    }
}
