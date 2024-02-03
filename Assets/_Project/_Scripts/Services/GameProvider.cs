using _Project._Scripts.Core;

namespace _Project._Scripts.Services
{
    public class GameProvider
    {
        private Game _game;        
        public Game Game => _game;

        public void SetGame(Game game)
        {
            _game = game;
        }
    }
}