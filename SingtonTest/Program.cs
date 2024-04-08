using System.Threading;

namespace SingtonTest
{
    internal class Program
    {

        static ThreadLocal<int> threadLocal = new ThreadLocal<int>();
        static AsyncLocal<int> asyncLocal = new AsyncLocal<int>();
        static int local = 0;
        static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(100, 100);
            var configs = new Config[100];
            Parallel.For(0, configs.Length, i =>
            {
                var index = i;
                threadLocal.Value = index;
                Task.Delay(10).Wait();
                Console.WriteLine($"{index}   {threadLocal.Value}");
                //configs[i] = Config.GetIns3();
            });
            Console.WriteLine("-------------------------");
            Parallel.For(0, configs.Length, i =>
            {
                var index = i;
                local = index;
                Task.Delay(10).Wait();
                Console.WriteLine($"{index}   {local}");
                //configs[i] = Config.GetIns3();
            });
            Console.WriteLine("++++++++++++++++++++++++++");
            Parallel.For(0, configs.Length, i =>
            {
                var index = i;
                asyncLocal.Value = index;
                Task.Delay(10).Wait();
                Console.WriteLine($"{index}   {asyncLocal.Value}");
                //configs[i] = Config.GetIns3();
            });


            Task.Run(() =>
            {
                asyncLocal.Value = 2;
                Console.WriteLine($"1Thread:{Thread.CurrentThread.ManagedThreadId}   {asyncLocal.Value}");
                Task.Run(() =>
                {
                    Console.WriteLine($"2Thread:{Thread.CurrentThread.ManagedThreadId}   {asyncLocal.Value}");
                    asyncLocal.Value = 3;
                    Console.WriteLine($"3Thread:{Thread.CurrentThread.ManagedThreadId}   {asyncLocal.Value}");
                });
                Console.WriteLine($"4Thread:{Thread.CurrentThread.ManagedThreadId}   {asyncLocal.Value}");
            });

            Thread thread = new Thread(() => { 
                Thread.Sleep(2000);
                Console.WriteLine($"5"); 
            });
            thread.Start();
            thread.Join();
            Console.WriteLine("over");
            //Console.WriteLine($"{configs.Select(p => p.Id).Distinct().Count()}");
            Console.ReadLine();
        }
    }

    public class Config
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public static Lazy<Config> Lazy = new Lazy<Config>(() => new Config());
        private static Config Ins { get; set; }
        public static object _lock = new object();
        public static Config GetIns()
        {
            if (Ins == null)
            {
                lock (_lock)
                {
                    if (Ins == null)
                    {
                        Ins = new Config();
                    }
                }
            }
            return Ins;
        }

        public static Config GetIns2()
        {
            return Lazy.Value;
        }

        public static Config GetIns3()
        {
            if (Ins == null)
            {
                Ins = new Config() { };
            }
            return Ins;
        }
    }
}