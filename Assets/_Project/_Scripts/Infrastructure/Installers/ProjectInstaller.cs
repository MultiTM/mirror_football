using _Project._Scripts.Core;
using _Project._Scripts.Core.GameStates;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallCore();
        }

        private void InstallCore()
        {
            Container.Bind<Game>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
        }
    }
}