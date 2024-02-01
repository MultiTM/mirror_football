using _Project._Scripts.StateMachine;

namespace _Project._Scripts.Core.GameStates
{
    public interface IGameState : IState
    {
        public void Init(Game game);
    }
}