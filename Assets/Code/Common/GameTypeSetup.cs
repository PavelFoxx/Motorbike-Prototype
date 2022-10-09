using System.Collections.Generic;
using System.Collections.ObjectModel;
using Code.Common.Interfaces;
using Code.Environment;
using Code.Vehicle;
using Code.Vehicle.Input;
using UnityEngine;

namespace Code.Common
{
    public class GameTypeSetup : MonoBehaviour, IGameTypeSetup
    {
        [SerializeField] private List<MotorbikeTypeSo> motorbikeVariants = new List<MotorbikeTypeSo>();
        [SerializeField] private List<GroundGenerationTypeSo> groundGenerationVariants = new List<GroundGenerationTypeSo>();
        [SerializeField] private List<InputTypeSo> inputVariants = new List<InputTypeSo>();
        [SerializeField] private GameObject cameraFollow;
        
        public ReadOnlyCollection<MotorbikeTypeSo> MotorbikeVariants => motorbikeVariants.AsReadOnly();
        public ReadOnlyCollection<GroundGenerationTypeSo> GroundGenerationVariants => groundGenerationVariants.AsReadOnly();
        public ReadOnlyCollection<InputTypeSo> InputVariants => inputVariants.AsReadOnly();
        public GameObject CameraFollow => cameraFollow;

        private MotorbikeTypeSo _currentMotorbike;
        private GroundGenerationTypeSo _currentGroundGeneration;
        private InputTypeSo _currentInput;
        
        public MotorbikeTypeSo CurrentMotorbike => _currentMotorbike;
        public GroundGenerationTypeSo CurrentGroundGeneration => _currentGroundGeneration;
        public InputTypeSo CurrentInput => _currentInput;

        public bool IsGameLoadAvailable =>
            (_currentMotorbike != null && _currentInput != null && _currentGroundGeneration != null);
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        public void PickMotorbike(MotorbikeTypeSo motorbikeTypeSo)
        {
            _currentMotorbike = motorbikeTypeSo;
        }
        public void PickInput(InputTypeSo input)
        {
            _currentInput = input;
        }
        public void PickGroundGeneration(GroundGenerationTypeSo groundGeneration)
        {
            _currentGroundGeneration = groundGeneration;
        }
    }
}
