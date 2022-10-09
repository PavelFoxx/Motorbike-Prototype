using System.Collections.ObjectModel;
using Code.Environment;
using Code.Vehicle;
using Code.Vehicle.Input;
using UnityEngine;

namespace Code.Common.Interfaces
{
    public interface IGameTypeSetup
    {
        public ReadOnlyCollection<MotorbikeTypeSo> MotorbikeVariants { get; }
        public ReadOnlyCollection<GroundGenerationTypeSo> GroundGenerationVariants { get; }
        public ReadOnlyCollection<InputTypeSo> InputVariants { get; }
        public GameObject CameraFollow { get; }
        public MotorbikeTypeSo CurrentMotorbike { get; }
        public GroundGenerationTypeSo CurrentGroundGeneration { get; }
        public InputTypeSo CurrentInput { get; }
        public bool IsGameLoadAvailable { get; }
        public void PickMotorbike(MotorbikeTypeSo motorbikeTypeSo);
        public void PickInput(InputTypeSo input);
        public void PickGroundGeneration(GroundGenerationTypeSo groundGeneration);
    }
}