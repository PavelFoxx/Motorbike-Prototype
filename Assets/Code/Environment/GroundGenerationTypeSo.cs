using UnityEngine;

namespace Code.Environment
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Create Ground Generation Type", fileName = "Ground Generation So", order = 2)]
    public class GroundGenerationTypeSo : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private GameObject groundGenerationObject;

        public string Title => title;
        public GameObject GroundGenerationObject => groundGenerationObject;
    }
}
