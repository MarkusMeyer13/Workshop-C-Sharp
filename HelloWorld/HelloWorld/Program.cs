using System.Globalization;
using System.Transactions;

namespace HelloWorld
{
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            #region divide simple 
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
            #endregion

            // Convert string to double
            string number = "12.5";
            
            
            double doubleFromString1 = Convert.ToDouble(number, new CultureInfo("en-US"));
            Console.WriteLine("doubleFromString1: " + doubleFromString1);
           
            // Parse
            double doubleFromString2 = double.Parse(number, new CultureInfo("en-US"));
            Console.WriteLine("doubleFromString2: " + doubleFromString2);

            // Cast
            var castResult = (double)integerFirst;
            Console.WriteLine($"castResult: {castResult + 3}");

            #region char

            char charFirst = 'a';
            Console.WriteLine(string.Format("charFirst: {0}", charFirst));

            Console.WriteLine($"charFirst: {(int)charFirst + 3}");

            #endregion
        }
    }
}
