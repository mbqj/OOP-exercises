
/*
8.3.7 Discriminants and Roots

Write a program in which:

1. There is a function called discriminant that calculates a discriminant
   based on the parameters a, b and c.

2. There is a function called roots that takes the parameters a, b and c
   from a quadratic polynomial, and returns an array of roots.

   • Hint: You can use Math.Sqrt(9.0) to calculate √9.

3. There is code that demonstrates how to call roots and prints out the result.
*/
double discriminant (double a, double b, double c){
    return b*b-4*a*c;
}

double[] roots (double a, double b, double c){
    double d = discriminant(a,b,c);
    if(d<0){
        return new double[0];
    }
    else if(d==0){
        double r = -b / (2 * a);
        return new double[] {r};
    }
    else{
        double sqrtD = Math.Sqrt(d);
        double r1 = (-b + sqrtD) / (2 * a);
        double r2 = (-b - sqrtD) / (2 * a);
        return new double[] {r1,r2};
    }
}

Console.WriteLine(discriminant(1,-3,2));
Console.WriteLine("Roots: " + string.Join(", ", roots(1, -3, 2)));

/*
7.6.13 Calendar Prettyprinting

Write a program in which:

1. A datastructure is created to hold the calendar of a single year. One needs
   to be able to index it using a date (month and day) in order to extract
   which weekday it is (e.g., Monday).

   • What is the type of this data structure?
   • How do you initialize a variable of this type?
   • How can you make sure that the contents is correct?

2. Print out the contents of this data structure in a “nice” way.
*/
void calendarPrettyPrint(){
    DayOfWeek[,] calendar;
    int year = 2025;
    calendar = new DayOfWeek[12, 31];

    for (int month = 1; month <= 12; month++)
    {
        int days = DateTime.DaysInMonth(year, month);
        for (int day = 1; day <= days; day++)
        {
            DateTime date = new DateTime(year, month, day);
            calendar[month - 1, day - 1] = date.DayOfWeek;
        }
    }
    //$ er hvad der gør jeg kan bruge variabler inde i strings "" uden at havde en masse +'er
    for (int month = 1; month <= 12; month++)
    {
        int days = DateTime.DaysInMonth(year, month);
        Console.WriteLine($"\nMonth {month}:");

        for (int day = 1; day <= days; day++)
        {
            Console.WriteLine($"{day,2}/{month,2}/{year} is {calendar[month - 1, day - 1]}");
        }
    }
}
calendarPrettyPrint();
