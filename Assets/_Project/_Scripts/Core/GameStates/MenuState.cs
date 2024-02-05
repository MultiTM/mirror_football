using _Project._Scripts.Services;

namespace _Project._Scripts.Core.GameStates
{
    public class MenuState : GameStateBase
    {
        private MenuServicesProvider _provider;
        
        public MenuState(MenuServicesProvider provider)
        {
            _provider = provider;
        }
        
        public override void Enter()
        {
            _provider.Services.MenuUI.Show();
        }

        public override void Exit()
        {
            _provider.Services.MenuUI.Hide();
        }
    }
}