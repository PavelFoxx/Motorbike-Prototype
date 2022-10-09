using System;

namespace Code.Vehicle.Input
{
    public interface IPlayerInput
    {
        void OnMovePressed();

        void OnMoveReleased();

        void OnBreakPressed();

        void OnBreakReleased();
    }
}
