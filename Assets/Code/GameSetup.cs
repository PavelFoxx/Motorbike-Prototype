using System.Collections.Generic;
using System.Collections.ObjectModel;
using Code.Environment;
using Code.Gameplay.Distance;
using Code.Gameplay.GameOver;
using Code.Gameplay.Wheelie;
using Code.Vehicle;
using Code.Vehicle.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class GameSetup : MonoBehaviour
    {
        private static GameSetup _instance;
        
        [SerializeField] private string menuSceneName;
        [SerializeField] private string gameSceneName;

        [SerializeField] private List<MotorbikeTypeSo> motorbikeVariants = new List<MotorbikeTypeSo>();
        [SerializeField] private List<GroundGenerationTypeSo> groundGenerationVariants = new List<GroundGenerationTypeSo>();
        [SerializeField] private List<InputTypeSo> inputVariants = new List<InputTypeSo>();
        [SerializeField] private CameraFollow cameraFollow;
        
        public ReadOnlyCollection<MotorbikeTypeSo> MotorbikeVariants => motorbikeVariants.AsReadOnly();
        public ReadOnlyCollection<GroundGenerationTypeSo> GroundGenerationVariants => groundGenerationVariants.AsReadOnly();
        public ReadOnlyCollection<InputTypeSo> InputVariants => inputVariants.AsReadOnly();
        public CameraFollow CameraFollow => cameraFollow;

        private MotorbikeTypeSo _currentMotorbike;
        private GroundGenerationTypeSo _currentGroundGeneration;
        private InputTypeSo _currentInput;

        public bool IsGameLoadAvailable =>
            (_currentMotorbike != null && _currentInput != null && _currentGroundGeneration != null);
        
        private void Awake()
        {
            if(_instance != null)
                Destroy(gameObject);
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        
        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void TryLoadGame()
        {
            if (IsGameLoadAvailable)
                SceneManager.LoadScene(gameSceneName);
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
        
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == gameSceneName)
            {
                InitializeGame();
            }

            if (scene.name == menuSceneName)
            {
                _currentInput = null;
                _currentMotorbike = null;
                _currentGroundGeneration = null;
            }
        }

        private void InitializeGame()
        {
            Instantiate(_currentGroundGeneration.GroundGenerationObject);

            var uiBridge = FindObjectOfType<SetupUIBridge>();
            var input = Instantiate(_currentInput.InputObject, uiBridge.UIParent).GetComponent<IPlayerInput>();

            var motorbikeInstaller = Instantiate(_currentMotorbike.BaseMotorbike);
            motorbikeInstaller.EngineControl.Construct(_currentMotorbike.EngineData, input);

            var cameraFollowInstance = Instantiate(CameraFollow);
            cameraFollowInstance.SetupTarget(motorbikeInstaller.BaseBody);

            var wheelieView = FindObjectOfType<WheelieView>();
            wheelieView.Construct(motorbikeInstaller.WheelieCounter);

            var distanceView = FindObjectOfType<DistanceView>();
            distanceView.Construct(motorbikeInstaller.DistanceTraveled);

            var endLevelView = FindObjectOfType<EndLevelView>();
            endLevelView.Construct(motorbikeInstaller.EndLevelTrigger);
        }
    }
}
