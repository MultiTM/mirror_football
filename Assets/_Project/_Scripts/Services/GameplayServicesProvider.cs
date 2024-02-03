using _Project._Scripts.Infrastructure;

namespace _Project._Scripts.Services
{
    public class GameplayServicesProvider
    {
        private GameplayServices _services;    

        public GameplayServices Services => _services;

        public void SetServices(GameplayServices services)
        {
            _services = services;
        }
    }
}