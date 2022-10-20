using Code.Gameplay.Wheelie.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Wheelie
{
    public class WheelieView : MonoBehaviour
    {
        private IWheelieCounter _wheelieCounter;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        [SerializeField] private GameObject wheelieSignObject;
        [SerializeField] private TMP_Text wheelieTimerText;

        [Inject]
        private void Construct(IWheelieCounter wheelieCounter)
        {
            _wheelieCounter = wheelieCounter;
            _wheelieCounter.IsWheelie
                .Subscribe(DisplayTimer)
                .AddTo(_disposable);
            _wheelieCounter.WheelieTimer
                .Subscribe(UpdateValue)
                .AddTo(_disposable);
        }

        private void DisplayTimer(bool isOn)
        {
            wheelieSignObject.SetActive(isOn);
        }
        private void UpdateValue(float value)
        {
            wheelieTimerText.text = _wheelieCounter.WheelieTimer.Value.ToString("0.0") + " sec.";
        }
    }
}