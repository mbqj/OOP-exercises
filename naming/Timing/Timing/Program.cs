class Timing
{
    public static double Fun(double x, double y)
    {
        if (y<=1)
        {
            return x;
        }

        return Fun(x, y - 1) * Fun(x, y-1);
    }

    static void Main(string[] args)
    {
        for (int i = 1; i < 32; i++)
        {
            long latest = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("Fun: " + Fun(1.0000001, i));
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("Time taken: " + (now-latest) + " Milliseconds");
        }
    }
}