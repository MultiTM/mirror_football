using _Project._Scripts.Core;
using _Project._Scripts.Network;
using _Project._Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private LobbyCamera _lobbyCamera;
        [SerializeField] private LobbyUI _lobbyUI;
        [SerializeField] private StartPositionProvider _startPositionProvider;
        
        public override void InstallBindings()
        {
            Container.Bind<StartPositionProvider>().FromInstance(_startPositionProvider).AsSingle();
            Container.Bind<LobbyCamera>().FromInstance(_lobbyCamera).AsSingle();
            Container.Bind<LobbyUI>().FromInstance(_lobbyUI).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayServices>().AsSingle().NonLazy();
        }
    }
}