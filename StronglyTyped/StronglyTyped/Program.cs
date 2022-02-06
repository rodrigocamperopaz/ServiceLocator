namespace Client
{
    public interface IService
    {
        void ExecuteService();
    }
    public class LoggingService : IService
    {
        public void ExecuteService()
        {
            Console.WriteLine("Executing Log Service");
        }
    }
    public interface IServiceLocator
    {
        IService LoggingService { get; set; }
        IService LoggingService2 { get; set; }
    }

    public class ServiceLocator : IServiceLocator
    {
        private IService? ObjService;

        //Service locator function returning strong type   
        public IService LoggingService
        {
            get
            {
                if (ObjService == null) return new LoggingService();
                return ObjService;
            }
            set { ObjService = value; }
        }

        //Service locator function returning strong type   
        public IService LoggingService2
        {
            get
            {
                if (ObjService == null) return new LoggingService();
                return ObjService;
            }
            set { ObjService = value; }
        }
    }

    public class ClassA
    {
        private IService? ObjService;

        public ClassA(IServiceLocator serviceLocator)
        {
            ObjService = serviceLocator.LoggingService;
        }

        //Execute service  
        public void ExecuteService()
        {
            ObjService?.ExecuteService();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceLocator serviceLocator = new ServiceLocator();
            serviceLocator.LoggingService = new LoggingService();

            ClassA classA = new ClassA(serviceLocator);

            classA.ExecuteService();
            Console.ReadKey();
        }
    }
}
