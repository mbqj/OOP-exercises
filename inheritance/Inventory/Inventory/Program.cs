class Item
{
    private string name;
    private double price;

    public Item(string name, double price)
    {
        this.name = name;
        this.price = price;
    }
    public string getName()
    {
        return name;
    }

    public double getPrice()
    {
        return price;
    }
}

class FoodItem: Item
{
    private DateTime expiresAt;

    public FoodItem(string name, double price, DateTime expiresAt) : base(name, price)
    {
        this.expiresAt = expiresAt;
    }

    public DateTime getExpiresAt()
    {
        return expiresAt;
    }

    public override string ToString()
    {
        return getName() + " - " + getPrice() + " - " +  expiresAt;
    }
    
}

class NonFoodItem: Item
{
    private string[] material;
    
    public NonFoodItem(string name, double price, string[] material) : base(name, price)
    {
        this.material = material;
    }

    public string[] getMaterial()
    {
        return material;
    }

    public override string ToString()
    {
        return getName() + " - " + getPrice() + " - " + string.Join(", ", material); 
    }
}

public class Program
{
    public static void Main(){
        FoodItem[] foodItems = new FoodItem[10];
        for (int i = 0; i < foodItems.Length; i++)
        {
            foodItems[i] = new FoodItem("Food Item " + i, 1.0*i, new DateTime(i * 2000 * 1 * 1));
        }
        NonFoodItem[] nonFoodItems = new NonFoodItem[10];
        for (int i = 0; i < foodItems.Length; i++)
        {
            nonFoodItems[i] = new NonFoodItem("Non Food Item " + i, 1.0*i, new string[] {"wood","nails"});
        }

        foreach (FoodItem foodItem in foodItems)
        {
            Console.WriteLine(foodItem.ToString());
        }

        foreach (NonFoodItem nonFoodItem in nonFoodItems)
        {
            Console.WriteLine(nonFoodItem.ToString());
        }
    }
}

