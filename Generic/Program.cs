namespace Client
{
    public interface IServiceA
    {
        void Execute();
    }

    public class ServiceA : IServiceA
    {
        public void Execute()
        {
            Console.WriteLine("A service called.");
        }
    }

    public interface IServiceB
    {
        void Execute();
    }

    public class ServiceB : IServiceB
    {
        public void Execute()
        {
            Console.WriteLine("B service called.");
        }
    }

    public interface IService
    {
        T GetService<T>();
    }
    public class ServiceLocator : IService
    {
        public Dictionary<object, object> serviceContainer = null;
        public ServiceLocator()
        {
            serviceContainer = new Dictionary<object, object>();
            serviceContainer.Add(typeof(IServiceA), new ServiceA());
            serviceContainer.Add(typeof(IServiceB), new ServiceB());
        }
        public T GetService<T>()
        {
            try
            {
                return (T)serviceContainer[typeof(T)];
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Service not available.");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceLocator loc = new ServiceLocator();
            IServiceA Aservice = loc.GetService<IServiceA>();
            Aservice.Execute();

            IServiceB Bservice = loc.GetService<IServiceB>();
            Bservice.Execute();

            Console.ReadKey();
        }
    }
}
