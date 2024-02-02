using _Project._Scripts.Configs;
using _Project._Scripts.Core;
using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private SceneProvider _sceneProvider;
        
        public override void InstallBindings()
        {
            InstallCore();
            InstallConfigs();
            InstallServices();
        }

        private void InstallConfigs()
        {
            Container.Bind<SceneProvider>().FromScriptableObject(_sceneProvider).AsSingle();
        }

        private void InstallServices()
        {
            Container.Bind<SceneLoadService>().AsSingle();
        }

        private void InstallCore()
        {
            Container.Bind<Game>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LobbyState>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpawnState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
        }
    }
}