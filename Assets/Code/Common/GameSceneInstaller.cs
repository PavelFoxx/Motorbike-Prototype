using Code.Camera;
using Code.Common.Interfaces;
using Code.Gameplay.Distance.Interfaces;
using Code.Gameplay.GameOver.Interfaces;
using Code.Gameplay.Wheelie.Interfaces;
using Code.Vehicle;
using Code.Vehicle.Input;
using Code.Vehicle.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Common
{
    public class GameSceneInstaller : MonoInstaller
    {
        private IGameTypeSetup _gameTypeSetup;

        [Inject]
        private void Construct(IGameTypeSetup gameTypeSetup)
        {
            _gameTypeSetup = gameTypeSetup;
        }
        
        public override void InstallBindings()
        {
            
            var baseMoto = Container.InstantiatePrefabForComponent<MotorbikeInstaller>(_gameTypeSetup.CurrentMotorbike.BaseMotorbike, new Vector3(0, 3, 0), Quaternion.identity, null);
            Container.Bind<IEngineControl>().FromInstance(baseMoto.EngineControl).AsCached();
            Container.Bind<ITarget>().FromInstance(baseMoto.CameraTarget).AsCached();
            Container.Bind<IWheelieCounter>().FromInstance(baseMoto.WheelieCounter).AsCached();
            Container.Bind<IDistanceTraveled>().FromInstance(baseMoto.DistanceTraveled).AsCached();
            Container.Bind<IEndLevelTrigger>().FromInstance(baseMoto.EndLevelTrigger).AsCached();
            
            
            Instantiate(_gameTypeSetup.CurrentGroundGeneration.GroundGenerationObject);

            var uiBridge = FindObjectOfType<SetupUIBridge>();
            var input = Container.InstantiatePrefabForComponent<IPlayerInput>(_gameTypeSetup.CurrentInput.InputObject, uiBridge.UIParent);
            Container.Bind<IPlayerInput>().FromInstance(input).AsCached();

            Container.InstantiatePrefabForComponent<ICameraFollow>(_gameTypeSetup.CameraFollow);



        }
    }
}
