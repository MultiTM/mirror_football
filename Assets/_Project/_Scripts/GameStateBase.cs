namespace _Project._Scripts.Infrastructure
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
            throw new System.NotImplementedException();
        }

        public virtual void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}