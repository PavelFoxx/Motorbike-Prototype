using Code.Common.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Common
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private Object gameTypeSetup;
        [SerializeField] private Object sceneLoader;
        public override void InstallBindings()
        {
            Container.Bind<IGameTypeSetup>().FromInstance(gameTypeSetup as IGameTypeSetup).AsSingle();
            Container.Bind<ISceneLoader>().FromInstance(sceneLoader as ISceneLoader).AsSingle();
        }
    }
}
