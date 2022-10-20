using System;
using System.Runtime.InteropServices;
using UniRx;

namespace Code.Gameplay.Wheelie.Interfaces
{
    public interface IWheelieCounter
    {
        public ReactiveProperty<bool> IsWheelie { get; }
        public ReactiveProperty<float> WheelieTimer { get; }
    }
}