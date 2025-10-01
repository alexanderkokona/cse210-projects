using System;

class Program
{
    static void Main(string[] args)
    {
        // Test all three constructors
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Test setters
        f1.SetTop(7);
        f1.SetBottom(8);
        Console.WriteLine(f1.GetFractionString()); // should print 7/8
        Console.WriteLine(f1.GetDecimalValue());  // should print 0.875
    }
}
