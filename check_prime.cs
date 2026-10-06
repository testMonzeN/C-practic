using System;

class Program 
{ 
    static bool Prime(int n) 
    { 
        if (n == 2) return true; 
        if (n % 2 == 0) return false; 

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