using Code.Gameplay.Distance.Interfaces;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Distance
{
    public class DistanceView : MonoBehaviour
    {
        private IDistanceTraveled _distanceTraveled;
        private CompositeDisposable _disposable = new CompositeDisposable();
        
        [SerializeField] private TMP_Text distanceText;
        
        [Inject]
        private void Construct(IDistanceTraveled distanceTraveled)
        {
            _distanceTraveled = distanceTraveled;

            _distanceTraveled.Distance
                .Subscribe(DistanceChanged)
                .AddTo(_disposable);
        }

        private void DistanceChanged(int distance)
        {
            distanceText.text = distance.ToString();
        }
    }
}
