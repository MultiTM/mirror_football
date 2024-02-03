using _Project._Scripts.Services;

namespace _Project._Scripts.Core.GameStates
{
    public class LobbyState : GameStateBase
    {
        private GameplayServicesProvider _provider;
        
        public LobbyState(GameplayServicesProvider provider)
        {
            _provider = provider;
        }
        
        public override void Enter()
        {
            _provider.Services.LobbyUI.Show();
            _provider.Services.LobbyCamera.Enable();
        }

        public override void Exit()
        {
            _provider.Services.LobbyUI.Hide();
            _provider.Services.LobbyCamera.Disable();
        }
    }
}