using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Gameplay.GameOver
{
    public class EndLevelTrigger : MonoBehaviour
    {
        [SerializeField] private float timeToReload = 0.5f;
        
        public event Action OnEndLevelTriggered = delegate { }; 
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
            SceneManager.LoadScene("Prototype");
        }
    }
}
