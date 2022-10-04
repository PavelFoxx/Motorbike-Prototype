using UnityEngine;

namespace Code.Vehicle.Input
{
    public class SetupUIBridge : MonoBehaviour
    {
        [SerializeField] private Transform uiParent;
        public Transform UIParent => uiParent;
    }
}
