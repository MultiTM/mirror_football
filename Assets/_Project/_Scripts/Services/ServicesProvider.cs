namespace _Project._Scripts.Services
{
    public class ServicesProvider<T>
    {
        public T Services { get; private set; }

        public void SetServices(T services)
        {
            Services = services;
        }
    }
}