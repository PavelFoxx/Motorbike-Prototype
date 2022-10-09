using System;
using Code.Common.Interfaces;
using Code.Gameplay.GameOver.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Gameplay.GameOver
{
    public class EndLevelTrigger : MonoBehaviour, IEndLevelTrigger
    {
        private ISceneLoader _sceneLoader;
        
        [SerializeField] private float timeToReload = 0.5f;
        
        public event Action OnEndLevelTriggered = delegate { };

        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"Ground"))
            {
                OnEndLevelTriggered?.Invoke();
                Invoke(nameof(EndLevel), timeToReload);
            }
        }

        private void EndLevel()
        {
            _sceneLoader.LoadGame();
        }
    }
}
