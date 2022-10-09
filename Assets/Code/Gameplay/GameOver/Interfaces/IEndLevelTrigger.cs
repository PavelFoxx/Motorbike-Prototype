using System;

namespace Code.Gameplay.GameOver.Interfaces
{
    public interface IEndLevelTrigger
    {
        public event Action OnEndLevelTriggered;
    }
}