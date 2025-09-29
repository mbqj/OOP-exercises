//T1 Marcus

//More comments and explanations available in the customer_database exercise!

class Program {
	public static void Main(string[] args) {
		Customer aCustomer; //Declaration
		aCustomer = new Customer("Peter", 0, 500); //Instantiate a new customer (name=Peter, id=0, balance=500)
		aCustomer.Deposit(100);
		aCustomer.Withdraw(150);
		Console.WriteLine(aCustomer.GetBalance());
	}
}

class Customer {
	string name;
	int id;
	double balance;

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
