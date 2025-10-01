class Program
{
    public static void Main()
    {
        Prime prime = new Prime();
        Console.WriteLine("The largest prime number is: " + prime.LargestPrime(1000000));
    }
}

class Prime {
    public int LargestPrime(int n){
        bool[] primes = new bool[n];
        Array.Fill(primes, true);
        
        int limit = (int)Math.Sqrt(n - 1);
        for (int i = 2; i < limit; i++)
        {
            if (primes[i])
            {
                for (int j = i*i; j < n; j += i)
                {
                    primes[j] = false;
                }
            }
        }

        for (int i = n-1; i >= 2; i--)
        {
            
            if (primes[i])
            {
                return i;
            }
        }
        return 0;
    }
}