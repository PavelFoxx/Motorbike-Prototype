using System;
using System.Runtime.InteropServices;

namespace Code.Gameplay.Wheelie.Interfaces
{
    public interface IWheelieCounter
    {
        public bool IsWheelie { get; }
        public float WheelieTimer { get; }

        public event Action OnBeginWheelie;
        public event Action OnEndWheelie;
    }
}