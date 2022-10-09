using Code.Common.Interfaces;
using Zenject;

namespace Code.Camera
{
    public class InstallCamera : MonoInstaller
    {
        private IGameTypeSetup _gameTypeSetup;

        [Inject]
        private void Construct(IGameTypeSetup gameTypeSetup)
        {
            _gameTypeSetup = gameTypeSetup;
        }
        
        public override void InstallBindings()
        {
            var gameCamera = Container.InstantiatePrefabForComponent<ICameraFollow>(_gameTypeSetup.CameraFollow);
            
            Container
                .Bind<ICameraFollow>()
                .FromInstance(gameCamera)
                .AsCached();
        }
    }
}