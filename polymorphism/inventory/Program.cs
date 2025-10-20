//T1 Marcus

class Program {
	public static void Main(string[] args) {
		Inventory inventory = new Inventory(15);

		//Put some items into the inventory
		for (int i = 0; i < 15; i++) {
			if (i % 3 == 0)
				inventory.AddItem(new NonFoodItem("Item " + i, 12.3 * i, new string[] { "Wood", "Nails", "WD40" }));
			else
				inventory.AddItem(new FoodItem("Item " + i, 8.7 * i, new DateTime(2026, i % 12, (i * 3) % 28, (i * 13) % 23, (i * 27) % 59, (i * 41) % 59))); //Lots of modulo to create semi random dates
		}
		
		//Print the total value of all items in the inventory
		Console.WriteLine(inventory.GetInventoryValue());
		Console.WriteLine();

		//Print all the items in the inventory
		inventory.PrintInventory();

	}
}


//Inventory class
class Inventory {
	private Item[] items;

	public Inventory() {
		items = new Item[10];
	}

	public Inventory(int capacity) {
		items = new Item[capacity];
	}

	public void AddItem(Item item) {
		for(int i = 0; i < items.Length; i++) {
			if (items[i] != null) //This is a guard clause! (Look it up if you are interested ;])
				continue;
			
			items[i] = item;
			return;
		}
	}

	public void RemoveItem(Item item) {
		for(int i = 0; i < items.Length; i++) {
			if (items[i] != item) //This is a guard clause! (Look it up if you are interested ;])
				continue;
			
			items[i] = null;
		}
	}

	public double GetInventoryValue() {
		double total = 0;
		foreach(Item item in items)
			total += item.GetPrice();

		return total;
	}

	public void PrintInventory() {
		foreach(Item item in items) {
			Console.WriteLine(item);
			Console.WriteLine();
		}
	}
}



//Item class
class Item {
	private string name;
	private double price;
	
	public Item (string nameValue, double priceValue) {
		name = nameValue;
		price = priceValue;
	}

	public string GetName () {
		return name;
	}

	public double GetPrice () {
		return price;
	}
}


//FoodItem class
class FoodItem : Item {
	private DateTime expiresAt;
	
	public FoodItem (string name, double price, DateTime expiresAtValue) : base(name, price) {
		expiresAt = expiresAtValue;
	}

	public DateTime GetExpiresAt () {
		return expiresAt;
	}

	public override string ToString () {
		return "FoodItem name: " + GetName() + "\nPrice: " + GetPrice() + "\nExpiresAt: " + GetExpiresAt();
	}
}


//NonFoodItem class
class NonFoodItem : Item {
	private string[] materials;
	
	public NonFoodItem (string name, double price, string[] materialsValue) : base(name, price) {
		materials = materialsValue;
	}

	public string[] GetMaterials () {
		return materials;
	}

	public override string ToString () {
		string m = "[";
		
		for (int i = 0; i < materials.Length; i++) {
			m += (i == 0 ? "" : ",") + materials[i];
		}
		m += "]";
		
		return "NonFoodItem name: " + GetName() + "\nPrice: " + GetPrice() + "\nMaterials: " + m;
	}
}