public class Person
{
    private string name;
    private int age;
    private string cpr;

    public Person(string name, int age, string cpr)
    {
        this.name = name;
        this.age = age;
        this.cpr = cpr;
    }
    
    public string getName()
    {
        return name;
    }

    public int getAge()
    {
        return age;
    }
    
    public string getCpr()
    {
        return cpr;
    }

    public override string ToString()
    {
        return "Name: "+ name + ", Age: " + age+", Cpr: " + cpr ;
    }
}

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        people.Add(new Person("John", 10, "010101-0101"));
        people.Add(new Person("Jane", 10, "110101-0102"));
        people.Add(new Person("Carl", 10, "110101-0103"));
        people.Add(new Person("Jack", 10, "010101-0105"));
        people.Add(new Person("frank", 10, "010101-0107"));

        foreach (Person person in people)
        {
            if (person.getCpr() == "010101-0101")
            {
                Console.WriteLine(person.ToString());
            }
        }
        
        Dictionary<string, Person> peopleDict = new Dictionary<string, Person>();
        foreach (Person person in people)
        {
            peopleDict.Add(person.getCpr(), person);
        }
        Console.WriteLine(peopleDict["010101-0101"].ToString());
    }
}