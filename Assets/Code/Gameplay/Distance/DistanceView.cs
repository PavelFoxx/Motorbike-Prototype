using TMPro;
using UnityEngine;

namespace Code.Gameplay.Distance
{
    public class DistanceView : MonoBehaviour
    {
        private DistanceTraveled _distanceTraveled;
        [SerializeField] private TMP_Text distanceText;
        
        public void Construct(DistanceTraveled distanceTraveled)
        {
            _distanceTraveled = distanceTraveled;
        }
        private void Update()
        {
            distanceText.text = $"{_distanceTraveled.Distance.ToString("0")}";
        }
    }
}
