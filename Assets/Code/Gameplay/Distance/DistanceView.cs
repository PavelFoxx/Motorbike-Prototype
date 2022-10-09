using Code.Gameplay.Distance.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Distance
{
    public class DistanceView : MonoBehaviour
    {
        private IDistanceTraveled _distanceTraveled;
        [SerializeField] private TMP_Text distanceText;
        
        [Inject]
        private void Construct(IDistanceTraveled distanceTraveled)
        {
            _distanceTraveled = distanceTraveled;
            _distanceTraveled.OnDistanceChanged += DistanceChanged;
        }

        private void DistanceChanged(int distance)
        {
            distanceText.text = distance.ToString();
        }
    }
}
