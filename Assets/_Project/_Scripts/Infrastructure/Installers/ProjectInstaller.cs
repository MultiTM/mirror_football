using _Project._Scripts.Configs;
using _Project._Scripts.Core;
using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Network;
using _Project._Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private SceneProvider _sceneProvider;
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private NetworkManager _networkManagerPrefab;
        
        public override void InstallBindings()
        {
            InstallCore();
            InstallConfigs();
            InstallServices();
            InstallNetworkManagement();
        }

        private void InstallNetworkManagement()
        {
            Container.Bind<NetworkManager>().FromInstance(_networkManagerPrefab).AsSingle();
        }

        private void InstallConfigs()
        {
            Container.Bind<SceneProvider>().FromScriptableObject(_sceneProvider).AsSingle();
            Container.Bind<GameConfig>().FromScriptableObject(_gameConfig).AsSingle();
        }

        private void InstallServices()
        {
            Container.Bind<SceneLoadService>().AsSingle();
            Container.Bind<GameProvider>().AsSingle();
            Container.Bind<GameplayServicesProvider>().AsSingle();
        }

        private void InstallCore()
        {
            Container.Bind<Game>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConnectingState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayInitState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LobbyState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
        }
    }
}