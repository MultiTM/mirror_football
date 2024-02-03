using _Project._Scripts.Services;

namespace _Project._Scripts.Core.GameStates
{
    public class LobbyState : GameStateBase
    {
        private LobbyCameraProvider _lobbyCameraProvider;
        
        public LobbyState(LobbyCameraProvider lobbyCameraProvider)
        {
            _lobbyCameraProvider = lobbyCameraProvider;
        }
        
        public override void Enter()
        {
            _lobbyCameraProvider.LobbyCamera.Enable();
        }

        public override void Exit()
        {
            _lobbyCameraProvider.LobbyCamera.Disable();
        }
    }
}