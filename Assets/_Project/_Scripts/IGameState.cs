using _Project._Scripts.Infrastructure.StateMachine;

namespace _Project._Scripts.Infrastructure
{
    public interface IGameState : IState
    {
        public void Init(Game game);
    }
}