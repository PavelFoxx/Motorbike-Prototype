using Code.Gameplay.Wheelie.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Wheelie
{
    public class WheelieView : MonoBehaviour
    {
        private IWheelieCounter _wheelieCounter;

        [SerializeField] private GameObject wheelieSignObject;
        [SerializeField] private TMP_Text wheelieTimerText;

        [SerializeField] private float timeToDisplayResults = 0.5f;
        
        private bool _displayTimer;
        
        [Inject]
        private void Construct(IWheelieCounter wheelieCounter)
        {
            _wheelieCounter = wheelieCounter;
        }
        private void Update()
        {
            if (!_displayTimer)
            {
                wheelieSignObject.SetActive(false);
                
                if (_wheelieCounter.WheelieTimer >= timeToDisplayResults)
                {
                    _displayTimer = true;
                }
            }
            else
            {
                wheelieSignObject.SetActive(true);
                wheelieTimerText.text = _wheelieCounter.WheelieTimer.ToString("0.0") + " sec.";
                
                if (_wheelieCounter.WheelieTimer < timeToDisplayResults)
                {
                    _displayTimer = false;
                }
            }
        }

        
    }
}