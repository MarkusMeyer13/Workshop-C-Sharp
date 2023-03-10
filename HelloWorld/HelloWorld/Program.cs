using System.Collections;
using System.Globalization;
using System.Text;
using VehicleFactory;

namespace HelloWorld;

internal class Program
{
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    static void Main(string[] args)
    {
        // Casting();
        //ControlMyFlow(true);
        //CheckInt(1);
        //CheckInt(0);
        //CheckInt(2);
        //CheckInt2(1);
        //CheckInt2(2);
        //CheckInt2(3);
        //CheckInt2(4);
        //Loop(9);

        int[] numbers = new int[2] { 4, 3 };
        LoopArrayWithWhile(numbers);

        var findResult = FindElement(numbers, 4);
        if (findResult.HasValue)
        {
            Console.WriteLine("Find result: " + findResult.Value);
        }

        Console.WriteLine(findResult);

        var elements = new string[3] { "lorem", "ipsum", "hello" };
        elements[2] = "world";
        Console.WriteLine(string.Join('_', elements));

        ArrayList arrayList = new ArrayList();
        arrayList.Add("hallo");
        arrayList.Add("welt");
        arrayList.Add(1);
        Console.WriteLine(string.Join('_', arrayList.ToArray()));

        Console.WriteLine("Please enter something to end:  ");
        //var input = Console.ReadLine();
        //Console.WriteLine(input);

        Console.WriteLine(ReverseString("Hello, World!"));
        Console.WriteLine(string.Concat("Hallo".Reverse()));
        PlayTicTacToe();
    }

    static void PlayTicTacToe()
    {
        string[,] ticTacToe = new string[3, 3];
        ticTacToe[2, 2] = "x";

        for(int i = ticTacToe.GetLowerBound(0); i <= ticTacToe.GetUpperBound(0); i++)
        {
            for (int j = ticTacToe.GetLowerBound(1); j <= ticTacToe.GetUpperBound(1); j++)
            {
                var item = ticTacToe[i, j];
                Console.WriteLine ($"i: {i}; j: {j}; " + item);
            }
        }
    }

    static string ReverseString(string txt)
    {
        var result = string.Empty;
        for (int i = txt.Length - 1; i >= 0; i--)
        {
            result += txt[i];
        }

        return result;
    }

    static int? FindElement(int[] elements, int index)
    {
        if (index > elements.Length - 1)
        {
            return null;
        }

        return elements[index];
    }

    static void LoopArrayWithWhile(int[] numbers)
    {
        var enumerator = numbers.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine("enumerator.Current: " + enumerator.Current);
        }
    }

    static void LoopArray(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.WriteLine($"number: '{number}'");
        }
    }


    static void Loop(int upperBound)
    {
        for (int i = 0; i <= upperBound; i++)
        {
            Console.WriteLine($"i: '{i}'");
            if (i == 2)
            {
                Console.WriteLine($"Two");
                continue;
            }

            if (i == 5)
            {
                break;
            }
        }
    }

    static void CheckInt2(int value)
    {
        switch (value)
        {
            case 1:
                {
                    int a = 3;
                    value += a;
                    Console.WriteLine("1: " + value);
                    break;
                }
            case 2:
            case 3:
                {
                    int a = 3;
                    value += a;
                    Console.WriteLine("3: " + value);
                    break;
                }
            default:
                Console.WriteLine("default: " + value);
                break;
        }
    }

    static void CheckInt(int integer)
    {
        if (integer > 0)
        {
            Console.WriteLine("Bigger than zero ");
            if (integer % 2 == 0)
            {
                Console.WriteLine("Bigger than zero and even");
            }
            else
            {
                Console.WriteLine("Odd");
            }
        }
        else if (integer == 0)
        {
            Console.WriteLine("Zero");
        }
        else
        {
            Console.WriteLine("Less than zero");
        }
    }


    static void ControlMyFlow(bool doCasting)
    {
        if (!doCasting)
        {
        }
        else
        {
            Casting();
        }

        //if (doCasting != true)
        //{
        //}

        //if (doCasting == false)
        //{
        //}

    }

    static void Casting()
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

        #region string

        string firstString = "Hello";
        string secondString = "World";

        string thirdString = firstString + secondString;
        Console.WriteLine($"thirdString: {thirdString}");

        string forthString = string.Format("{0}{1}", firstString, secondString);
        Console.WriteLine($"forthString: {forthString}");

        string fifthString = string.Concat(firstString, secondString);
        Console.WriteLine($"fifthString: {fifthString}");

        string sixthString = $"{firstString}{secondString}";
        Console.WriteLine($"sixthString: {sixthString}");

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(firstString);
        stringBuilder.Append("\r\n");
        stringBuilder.Append(secondString);
        Console.WriteLine($"stringBuilder: {stringBuilder.ToString()}");

        #endregion

        Car car = new Car();
        //car.m
    }

}
