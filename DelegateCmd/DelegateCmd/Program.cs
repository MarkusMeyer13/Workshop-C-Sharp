namespace DelegateCmd
{
    internal class Program
    {

        static void Main(string[] args)
        {
            SaySomething("Hello, World!");
        }

        public static void SaySomething(string message)
        {
            Console.WriteLine(message);
        }
    }
}