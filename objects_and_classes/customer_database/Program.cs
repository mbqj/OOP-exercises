//T1 Marcus

//Class containing the main method
class Program {
	public static void Main(string[] args) {
		//Declaration and instantiation of CustomerDatabase object
		CustomerDatabase database = new CustomerDatabase();

		//Calling the AddCustomer method and instantiating new Customer objects
		database.AddCustomer(new Customer("Peter", 0, 200));
		database.AddCustomer(new Customer("Larry", 1));
		database.AddCustomer(new Customer("Sarah", 2, 45));

		database.PrintCustomers();

		//Remove Larry
		database.RemoveCustomerById(1);

		database.PrintCustomers();
	}
}

//Customer class
class Customer {
	//Public attributes
	public string name;
	public int id;
	public double balance;

	//Constructor method #1
	/*
	The 'this' keyword referes to the current customer object on which the method is being called.
	In this case, 'this.name' refers to the 'name' attribute instead of the 'name' parameter. (And same with the other uses of 'this').
	*/
	public Customer(string name, int id) {
		this.name = name;
		this.id = id;
		this.balance = 0;
	}

	//Constructor method #2
	/*
	The 'this' keyword referes to the current customer object on which the method is being called.
	In this case, 'this.name' refers to the 'name' attribute instead of the 'name' parameter. (And same with the other uses of 'this').
	*/
	public Customer(string name, int id, double balance) {
		this.name = name;
		this.id = id;
		this.balance = balance;
	}

	//Deposit method
	public void Deposit(double amount) {
		balance += amount;
	}

	//Withdraw method
	public void Withdraw(double amount) {
		if (balance >= amount)
			balance -= amount;
	}

	//Get balance method
	public double GetBalance() {
		return balance;
	}
}

//Customer database class
class CustomerDatabase {
	//Array attribute (of Customer objects)
	Customer[] customers;

	public CustomerDatabase() {
		//Instantiate the array with 10 slots
		customers = new Customer[10];
	}

	//Method for adding customer objects to the database array
	/* 
	Works by iterating over each slot of the customers array,
	then uses an if statement to check wether the slot is empty (null).
	When an empty slot is found, sets that slot to be equal to the customer object.
	Uses a break to stop after a single slot has been filled.
	*/
	public void AddCustomer(Customer customer) {
		for (int i = 0; i < customers.Length; i++) {
			if (customers[i] == null) {
				customers[i] = customer;
				break;
			}
		}
	}

	//Method for removing customer objects from the database array
	/*
	Works by iterating over each slot of the customers array,
	first checking if the current slot is not null (meaning the slot contains a customer),
	if the slot contains a customer, that customers id is compared to the method parameter.
	If the id matches, the slot is set to null (removing the reference to the customer object, 
	which will make it be removed from memory by the C# garbage collector)
	*/
	public void RemoveCustomerById(int id) {
		for (int i = 0; i < customers.Length; i++)
			if (customers[i] != null && customers[i].id == id)
				customers[i] = null;
	}

	public Customer[] GetCustomers() {
		return customers;
	}

	//Method for printing all attributes of each customer
	/*
	Ensures to check if each slot contains a customer. 
	*/
	public void PrintCustomers() {
		Console.WriteLine("<<< Printing customers >>>");
		for (int i = 0; i < customers.Length; i++) {
			if (customers[i] != null) {
				Console.WriteLine("Name: " + customers[i].name + ", id: " + customers[i].id + ", balance: " + customers[i].balance);
			}
		}
	}
}
