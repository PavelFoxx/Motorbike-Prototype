using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Menu
{
    public class InteractableElementWithTitle : MonoBehaviour
    {
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        
        public event Action<string, int> OnButtonPressed = delegate { };
        
        private int _elementIndex;
        private string _pickType;

        public void Construct(string title, int index, string pickT)
        {
            titleText.text = title;
            _elementIndex = index;
            _pickType = pickT;

            Subscribe();
        }

        public void ChangeIsPicked(bool isPicked)
        {
            image.color = isPicked ? Color.green : Color.white;
        }
        
        private void Subscribe()
        {
            button.onClick.AddListener(Click);
        }

        private void Click()
        {
            OnButtonPressed?.Invoke(_pickType, _elementIndex);   
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
