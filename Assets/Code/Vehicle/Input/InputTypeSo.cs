using UnityEngine;

namespace Code.Vehicle.Input
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Create Input Type", fileName = "Input Type", order = 1)]
    public class InputTypeSo : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private GameObject inputObject;

        public string Title => title;
        public GameObject InputObject => inputObject;
    }
}
