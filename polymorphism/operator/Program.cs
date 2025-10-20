class OperatorTest {
	public static int Operator (int a, int b, bool c) {
		return a + b;
	}

	public static int Operator (int a, int b, char c) {
		return a - b;
	}

	public static void Main (string[] args) {
		for (int a = 0; a < 5; a++) {
			for (int b=0 ; b<5 ; b++) {
				Console.WriteLine(a + " (?1?) " + b + " = " + Operator(a, b, true));
				Console.WriteLine(a + " (?2?) " + b + " = " + Operator(a, b, false));
				Console.WriteLine(a + " (?3?) " + b + " = " + Operator(a, b, 'a'));
				Console.WriteLine(a + " (?4?) " + b + " = " + Operator(a, b, 'b'));
				Console.WriteLine(a + " (?5?) " + b + " = " + Operator(a, b, '.'));
			}
		}
	}
}