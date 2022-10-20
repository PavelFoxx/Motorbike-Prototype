using System;
using UniRx;

namespace Code.Gameplay.Distance.Interfaces
{
    public interface IDistanceTraveled
    {
        public ReactiveProperty<int> Distance { get; }
    }
}