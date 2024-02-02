namespace _Project._Scripts.Core.GameStates
{
    public class BootstrapState : GameStateBase
    {
        public override void Enter()
        {
            _game.EnterState<MenuState>();
        }
    }
}