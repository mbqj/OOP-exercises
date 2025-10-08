public class Kitten
{
    private double cuteness;
    public static int count = 0;

    public Kitten(double cuteness)
    {
        this.cuteness = cuteness;
        count++;
    }
    
    
}

class Program
{

        static void Main(string[] args)
        {
            Console.WriteLine("How many cats?");
            int n = Convert.ToInt32(Console.ReadLine());
            Kitten[] kittens = new Kitten[n];
            for (int i = 0; i < n; i++)
            {
                double cuteness = i;
                kittens[i] = new Kitten(cuteness);
            }
            Console.WriteLine(Kitten.count);
        }
}