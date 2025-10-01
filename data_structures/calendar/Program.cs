//T1 Marcus

int[] daysPerMonth = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
int[] daysPerMonthLeap = {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

for (int year = 2000; year <= 2020; year++) {
	
	//Use of a ternary operator (basically an if statement, but as an expression)
	//Format: <condition> ? <value_if_true> : <value_if_false>
	int[] pointer = year % 4 == 0 ? daysPerMonthLeap : daysPerMonth;

	Console.Write(year + ": ");

	for (int i = 0; i < pointer.Length; i++) {
		Console.Write(pointer[i] + ", ");
	}
	Console.WriteLine();
}
