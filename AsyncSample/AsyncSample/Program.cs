namespace AsyncSample
{
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Method1();
    //        Method2();
    //        Console.ReadKey();
    //    }

    //    public static async Task Method1()
    //    {
    //        await Task.Run(() =>
    //        {
    //            for (int i = 0; i < 100; i++)
    //            {
    //                Console.WriteLine(" Method 1");
    //                // Do something
    //                Task.Delay(100).Wait();
    //            }
    //        });
    //    }


    //    public static void Method2()
    //    {
    //        for (int i = 0; i < 25; i++)
    //        {
    //            Console.WriteLine(" Method 2");
    //            // Do something
    //            Task.Delay(100).Wait();
    //        }
    //    }
    //}

    internal class Program
    {
        static void Main(string[] args)
        {
            var task = SaySomethingAsync("hallo");
            Method1();

            while (!task.IsCompleted)
            {

            }
            //Console.WriteLine("Hello, World!");

            //Task.Delay(20000).Wait();

            //Console.WriteLine("Finish");

        }

        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    // Do something
                    Task.Delay(100).Wait();
                }
            });
        }

        private static void SaySomething(string message)
        {
            Console.WriteLine(message);
        }

        private static async Task SaySomethingAsync(string message)
        {
            await Task.Delay(10000);
            Console.WriteLine(message);
        }
    }
}