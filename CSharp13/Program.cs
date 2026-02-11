namespace CSharp13;

public class Program
{
    delegate int DelegateWithMatchingSignature(string s);
    
    public static void Main()
    {
        int x = 5;
        int postfixIncrement = x++;
        int prefixIncrement = ++x;
        Type theTypeOfAnInteger = typeof(int);
        Type program = typeof(Program);
        string nameOfVariable = nameof(x);
        int howManyBytesInAnInteger = sizeof(int);
        // Console.WriteLine(program);
        // Console.WriteLine(nameOfVariable);
        // Console.WriteLine(howManyBytesInAnInteger);

        Passenger[] passengers = {
            new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
            new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
            new BusinessClassPassenger { Name = "Janice" },
            new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
            new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
        };
        foreach (Passenger passenger in passengers)
        {
            decimal flightCost = passenger switch
            {
                FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
                FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
                FirstClassPassenger _ => 2_000M,
                BusinessClassPassenger _ => 1_000M,
                CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
                CoachClassPassenger _ => 650M,
                _ => 800M
            };
            // Console.WriteLine($"Flight costs {flightCost:C} for {passenger}");
        }
        Person p1 = new();
        DelegateWithMatchingSignature d = new(p1.MethodIWantToCall);
        int answer2 = d("Frog");
        // Console.WriteLine(answer2);

        Action sayHello = () => Console.WriteLine("Hello!");

        Action<string> print = (msg) => Console.WriteLine(msg);

        Action<string, int> repeat = (msg, count) =>
        {
            for (int i = 0; i < count; i++) Console.WriteLine(msg);
        };

        Action<string, int, bool> log = (msg, level, timestamp) =>
        {
            Console.WriteLine($"[{level}] {msg}");
        };

        print("Hello World");
        repeat("Hi", 3);
        log("Error", 2, true);

        Func<int> getNumber = () => 42;

        Func<int, string> toString = (x) => x.ToString();

        Func<int, int, int> add = (a, b) => a + b;

        Func<int, int, int, int> sum = (a, b, c) => a + b + c;

        Func<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>
            crazyFunc = (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => a + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p;

        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var evens = numbers.Where(x => x % 2 == 0);  // Func<int, bool>
        var squares = numbers.Select(x => x * x);     // Func<int, int>
        var sum2 = numbers.Aggregate(0, (acc, x) => acc + x);  // Func<int, int, int>
    }
}


