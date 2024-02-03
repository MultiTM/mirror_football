using _Project._Scripts.Core;

namespace _Project._Scripts.Services
{
    public class GameplayFlowProvider
    {
        private GameplayFlow _flow;
        
        public GameplayFlow Flow => _flow;

        public void SetFlow(GameplayFlow flow)
        {
            _flow = flow;
        }
    }
}