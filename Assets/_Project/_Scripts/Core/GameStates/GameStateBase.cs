namespace _Project._Scripts.Core.GameStates
{
    public class GameStateBase : IGameState
    {
        public Game _game { get; set; }
        
        public virtual void Init(Game game)
        {
            _game = game;
        }
        
        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }
    }
}