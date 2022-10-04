using Code.Gameplay.Distance;
using Code.Gameplay.GameOver;
using Code.Gameplay.Wheelie;
using UnityEngine;

namespace Code.Vehicle
{
    public class MotorbikeInstaller : MonoBehaviour
    {
        [SerializeField] private WheelieCounter wheelieCounter;
        [SerializeField] private DistanceTraveled distanceTraveled;
        [SerializeField] private EngineControl engineControl;
        [SerializeField] private EndLevelTrigger endLevelTrigger;
        [SerializeField] private Transform baseBody;
        
        public WheelieCounter WheelieCounter => wheelieCounter;
        public DistanceTraveled DistanceTraveled => distanceTraveled;
        public EngineControl EngineControl => engineControl;
        public EndLevelTrigger EndLevelTrigger => endLevelTrigger;
        public Transform BaseBody => baseBody;
    }
}
