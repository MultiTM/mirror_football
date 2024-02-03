using _Project._Scripts.Core;
using _Project._Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private LobbyCamera _lobbyCamera;
        
        public override void InstallBindings()
        {
            Container.Bind<GameplayFlow>().AsSingle().NonLazy();
            Container.Bind<LobbyCameraProvider>().AsSingle();
            Container.Bind<LobbyCamera>().FromInstance(_lobbyCamera).AsSingle();
        }
    }
}