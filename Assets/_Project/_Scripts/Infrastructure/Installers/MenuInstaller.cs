using _Project._Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project._Scripts.Infrastructure.Installers
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private MenuUI _menuUI;
        
        public override void InstallBindings()
        {
            Container.Bind<MenuUI>().FromInstance(_menuUI).AsSingle();
            Container.BindInterfacesAndSelfTo<MenuServices>().AsSingle().NonLazy();
        }
    }
}