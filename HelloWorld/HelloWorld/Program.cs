namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber;
            firstNumber = 1;
            int secondNumber = 3;
            int sum = firstNumber + secondNumber;
            string result = sum.ToString();
            Console.WriteLine("Result add: " + result);

            // Divide double by integer
            double doubleFirst = 1;
            var divideDouble = doubleFirst / 5;
            Console.WriteLine("Result divide double by integer: " + divideDouble);

            // Divide integer by integer
            var integerFirst = 1;
            Console.WriteLine(integerFirst.GetType().FullName);

            double divideThird = integerFirst / 5;

            Console.WriteLine("Result divide integer by integer: " + divideThird);
        }
    }
}
