namespace DelegateCmd
{
    internal class Program
    {
        private delegate void GreetingsDelegate(string message);

        static void Main(string[] args)
        {
            GreetingsDelegate handler = SaySomething;
            handler("Hello World");


            GreetingsDelegate handlerGreetings = new GreetingsDelegate(SaySomething);
            handlerGreetings("Huhu");

            GreetingsDelegate greetingsDelegate = delegate (string val)
            {
                Console.WriteLine("Inside Anonymous method. Value: {0}", val);
            };
            greetingsDelegate("Sample");

            //Console.WriteLine(string.Format("Hallo, {0}", "Markus"));

            Action<string> greet = name =>
            {
                string greeting = $"Hallo {name}!";
                Console.WriteLine(greeting);
            };
            greet("World");

            Func<int, double> half = x => x / (double)2;
            double result = half(5);
            Console.WriteLine(result);
        }

        public static void SaySomething(string message)
        {
            Console.WriteLine(message);
        }
    }
}