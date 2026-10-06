using System;

class Program 
{ 
    static bool Prime(int n) 
    { 
        if (n == 2) return true; 
        if (n % 2 == 0) return false; 

        // Math.Sqrt(n) - корень n
        // Math.Floor(Math.Sqrt(n)) - округление вниз (8.9 -> 8.0)
        // (int)Math.Floor(Math.Sqrt(n)) из 8.0 -> 8 то есть в целые числа
        for (int d = 3; d <= (int)Math.Floor(Math.Sqrt(n)); d += 2) 
        { 
            if (n % d == 0) 
            { 
                return false; 
            } 
        } 
        return true; 
    } 

    public static void Main() 
    { 
        int number = 123; 
        Console.WriteLine(Prime(number)); 
    } 
}