using Code.Camera;
using Code.Gameplay.Distance.Interfaces;
using Code.Gameplay.GameOver.Interfaces;
using Code.Gameplay.Wheelie.Interfaces;
using Code.Vehicle.Interfaces;
using UnityEngine;

namespace Code.Vehicle
{
    public class MotorbikeInstaller : MonoBehaviour
    {
        [SerializeField] private Object wheelieCounter;
        [SerializeField] private Object distanceTraveled;
        [SerializeField] private Object engineControl;
        [SerializeField] private Object endLevelTrigger;
        [SerializeField] private Object cameraTarget;

        public IWheelieCounter WheelieCounter => wheelieCounter as IWheelieCounter;
        public IDistanceTraveled DistanceTraveled => distanceTraveled as IDistanceTraveled;
        public IEngineControl EngineControl => engineControl as IEngineControl;
        public IEndLevelTrigger EndLevelTrigger => endLevelTrigger as IEndLevelTrigger;
        public ITarget CameraTarget => cameraTarget as ITarget;
    }
}
