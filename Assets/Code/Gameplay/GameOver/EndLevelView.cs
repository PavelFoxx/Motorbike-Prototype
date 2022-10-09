using System;
using Code.Gameplay.GameOver.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.GameOver
{
    public class EndLevelView : MonoBehaviour
    {
        private IEndLevelTrigger _endLevelTrigger;
        
        [SerializeField] private Animator fadeAnimator;
        [SerializeField] private string animatorTriggerName = "Fade";
        
        [Inject]
        private void Construct(IEndLevelTrigger endLevelTrigger)
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
