using System;
using _Project._Scripts.Core;
using _Project._Scripts.Core.GameStates;
using _Project._Scripts.Services;
using _Project._Scripts.UI;
using Zenject;

namespace _Project._Scripts.Infrastructure
{
    public class MenuServices : IInitializable, IDisposable
    {
        private MenuServicesProvider _provider;
        private Game _game;
        private MenuUI _menuUI;
        
        public MenuUI MenuUI => _menuUI;

        public MenuServices(Game game, MenuServicesProvider provider, MenuUI menuUI)
        {
            _game = game;
            _provider = provider;
            _menuUI = menuUI;
        }

        public void Initialize()
        {
            _provider.SetServices(this);
            _game.EnterState<MenuState>();
        }

        public void Dispose()
        {
            _provider.SetServices(null);
        }
    }
}