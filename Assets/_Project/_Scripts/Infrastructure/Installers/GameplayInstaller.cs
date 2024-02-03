using _Project._Scripts.Core;
using _Project._Scripts.Services;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameplayFlow>().AsSingle().NonLazy();
            Container.Bind<LobbyCameraProvider>().AsSingle();
        }
    }
}