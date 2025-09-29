class Program {
	public static void Main(string[] args) {
		CustomerDatabase database = new CustomerDatabase();

		database.AddCustomer(new Customer("Peter", 0, 200));
		database.AddCustomer(new Customer("Larry", 1));
		database.AddCustomer(new Customer("Sarah", 2, 45));

		database.PrintCustomers();
	}
}

//Customer class
class Customer {
	public string name;
	public int id;
	public double balance;

	//Constructor #1
	public Customer(string name, int id) {
		this.name = name;
		this.id = id;
		this.balance = 0;
	}

	//Constructor #2
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
	Customer[] customers;

	public CustomerDatabase() {
		customers = new Customer[10];
	}

	public void AddCustomer(Customer customer) {
		for (int i = 0; i < customers.Length; i++) {
			if (customers[i] == null) {
				customers[i] = customer;
				break;
			}
		}
	}

	public void RemoveCustomerById(int id) {
		for (int i = 0; i < customers.Length; i++)
			if (customers[i].id == id)
				customers[i] = null;
	}

	public Customer[] GetCustomers() {
		return customers;
	}

	public void PrintCustomers() {
		Console.WriteLine("<<< Printing customers >>>");
		for (int i = 0; i < customers.Length; i++) {
			if (customers[i] != null) {
				Console.WriteLine("Name: " + customers[i].name + ", id: " + customers[i].id + ", balance: " + customers[i].balance);
			}
		}
	}
}
