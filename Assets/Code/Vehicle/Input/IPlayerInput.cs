using System;

namespace Code.Vehicle.Input
{
    public interface IPlayerInput
    {
        public event Action OnMovePressed;
        public event Action OnMoveReleased;
        
        public event Action OnBreakPressed;
        public event Action OnBreakReleased;
    }
}
