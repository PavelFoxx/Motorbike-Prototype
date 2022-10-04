using UnityEngine;

namespace Code.Vehicle
{
    [CreateAssetMenu(menuName = "Create Motorbike Type", fileName = "Motorbike", order = 0)]
    [System.Serializable]
    public class MotorbikeTypeSo : ScriptableObject
    {
        [SerializeField] private string title;
        [SerializeField] private MotorbikeInstaller baseMotorbike;
        [SerializeField] private EngineDataStruct engineData;

        public string Title => title;
        public MotorbikeInstaller BaseMotorbike => baseMotorbike;
        public EngineDataStruct EngineData => engineData;
    }
}
