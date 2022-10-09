namespace Code.Vehicle.Interfaces
{
    public interface IEngineControl
    {
        public void OnMovePressed();
        public void OnMoveReleased();
        
        public void OnBreakPressed();
        public void OnBreakReleased(); 
    }
}