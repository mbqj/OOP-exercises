class Program {
	public static void Main(string[] args) {
		TurtleCommand tc = new TurtleCommand();

		TextReader reader = Console.In;
		while (true) {
			Console.WriteLine("The turtle demands command:");
			string? input = reader.ReadLine();
			
			if (input == null)
				continue;

			if (input.Equals("exit"))
				break;

			tc.EvaluateCommand(input);
		}
	}
}

class Canvas {
	private bool[][] data;

	public Canvas(int width, int height) {
		data = new bool[height][];
		for (int i = 0; i < data.Length; i++) {
			data[i] = new bool[width];
		}
	}

	public bool GetValue(int x, int y) {
		return data[y][x];
	}

	public void SetValue(bool value, int x, int y) {
		data[y][x] = value;
	}

	public int GetWidth() {
		return data[0].Length;
	}
	
	public int GetHeight() {
		return data.Length;
	}

	public void Print() {
		string str = "";

		for (int i = 0; i < data[0].Length + 2; i++) {
			str += (i == 0 || i == data[0].Length + 1 ? "O" : "-");
		}
		str += "\n";

		for (int i = 0; i < data.Length; i++) {
			str += "|";
			for (int j = 0; j < data[i].Length; j++) {
				str += (data[i][j] ? "#" : " ");
			}
			str += "|";
			str += "\n";
		}

		for (int i = 0; i < data[0].Length + 2; i++) {
			str += (i == 0 || i == data[0].Length + 1 ? "O" : "-");
		}
		str += "\n";

		Console.WriteLine(str);
	}
}

class Turtle {
	private int x;
	private int y;

	private bool draw;
	private Canvas currentCanvas;

	public Turtle(Canvas canvas) {
		currentCanvas = canvas;
	}

	public void GoNorth() {
		if (draw)
			currentCanvas.SetValue(true, x, y);
		
		if (y == 0)
			return;
		y--;
	}

	public void GoSouth() {
		if (draw)
			currentCanvas.SetValue(true, x, y);
		
		if (y == currentCanvas.GetHeight() - 1)
			return;
		y++;
	}

	public void GoWest() {
		if (draw)
			currentCanvas.SetValue(true, x, y);

		if (x == 0)
			return;
		x--;
	}

	public void GoEast() {
		if (draw)
			currentCanvas.SetValue(true, x, y);

		if (x == currentCanvas.GetWidth() - 1)
			return;
		x++;
	}

	public void Draw(bool draw) {
		this.draw = draw;
	}
}

class TurtleCommand {
	Canvas canvas;
	Turtle turtle;

	public TurtleCommand() {
		canvas = new Canvas(12, 8);
		turtle = new Turtle(canvas);
	}

	public void EvaluateCommand(string input) {
		string[] commands = input.Split(" ");

		if (commands.Length == 2 && commands[0].Equals("draw")) {
			if (commands[1].Equals("begin"))
				turtle.Draw(true);
			else if (commands[1].Equals("end"))
				turtle.Draw(false);
		}

		if (commands.Length == 2 && commands[0].Equals("go")) {
			if (commands[1].Equals("north")) {
				turtle.GoNorth();
			}
			else if (commands[1].Equals("south")) {
				turtle.GoSouth();
			}
			else if (commands[1].Equals("east")) {
				turtle.GoEast();
			}
			else if (commands[1].Equals("west")) {
				turtle.GoWest();
			}
		}

		if (commands.Length == 1 && commands[0].Equals("print")) {
			canvas.Print();
		}
	}
}