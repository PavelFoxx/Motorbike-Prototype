using Code.Common.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Common
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        private IGameTypeSetup _gameTypeSetup;
        
        [SerializeField] private string gameSceneName = "Game";
        [SerializeField] private string menuSceneName = "Menu";

        [Inject]
        private void Construct(IGameTypeSetup gameTypeSetup)
        {
            _gameTypeSetup = gameTypeSetup;
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            LoadMenu();
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene(menuSceneName);
        }

        public void LoadGame()
        {
            if (_gameTypeSetup.IsGameLoadAvailable)
                SceneManager.LoadScene(gameSceneName);
        }
    }
}