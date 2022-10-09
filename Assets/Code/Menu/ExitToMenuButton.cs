using Code.Common.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Code.Menu
{
    public class ExitToMenuButton : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        
        [SerializeField] private Button backBtn;

        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            backBtn.onClick.AddListener(OpenMenu);
        }

        private void OpenMenu()
        {
            _sceneLoader.LoadMenu();
        }

        private void OnDestroy()
        {
            if(backBtn != null)
                backBtn.onClick.RemoveAllListeners();
        }
    }
}
