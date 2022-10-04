using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Menu
{
    public class ExitToMenuButton : MonoBehaviour
    {
        [SerializeField] private Button backBtn;
        [SerializeField] private string menuSceneName = "Menu";
 
        private void Awake()
        {
            backBtn.onClick.AddListener(OpenMenu);
        }

        private void OpenMenu()
        {
            SceneManager.LoadScene(menuSceneName);
        }

        private void OnDestroy()
        {
            if(backBtn != null)
                backBtn.onClick.RemoveAllListeners();
        }
    }
}
