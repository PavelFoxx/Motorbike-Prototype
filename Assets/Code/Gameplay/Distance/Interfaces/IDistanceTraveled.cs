using System;

namespace Code.Gameplay.Distance.Interfaces
{
    public interface IDistanceTraveled
    {
        public int Distance { get; }
        public event Action<int> OnDistanceChanged;
    }
}