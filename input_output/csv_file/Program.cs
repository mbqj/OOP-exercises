//T1 Marcus

class Program {
	public static void Main(string[] args) {
		Matrix m = new Matrix("matrix.csv");
		Console.WriteLine(m);
		Console.WriteLine(m.GetValue(3, 1));
		m.SetValue(17, 3, 1);
		Console.WriteLine(m);
		m.Save("matrix.csv");

	}
}

class Matrix {
	//Data '2D' array (This type is actually called a jagged array)
	private double[][] data;

	//Constructor with file
	public Matrix(string fileName) {
		//Define a text reader
		TextReader reader = null;
		try {
			//Initialize the reader using the filename
			reader = new StreamReader(File.OpenRead(fileName));
			
			//Temporary storage for lines in the file
			List<string> lines = new List<string>();

			//While the file still contains informaiton, loop. (Peek() returns -1 if there is no next character)
			while(reader.Peek() != -1)
				lines.Add(reader.ReadLine()); //Store each line

			//Initialize the outer array using the line count
			data = new double[lines.Count][];

			//For every line
			for (int i = 0; i < lines.Count; i++) {
				
				//Split the line into its values
				string[] values = lines[i].Split(",");

				//Initialize the inner array for this line
				data[i] = new double[values.Length];
				
				//Insert each value at a specific index (in both outer and inner array)
				for (int j = 0; j < values.Length; j++)
					data[i][j] = double.Parse(values[j]);
			}
		}
		catch (FileNotFoundException) {
			//If the file name was not found in the expected location
			Console.WriteLine("File not found!");
			data = new double[0][];
		}
		catch (FormatException) {
			//If the file contains non-double parseable data
			Console.WriteLine("Bade file content!");
			data = new double[0][];
		}
		finally {
			//Close the reader!!! Very important, and not seen in slides if I remember correctly!
			if (reader != null)
				reader.Close();
		}
	}

	//Constructor with size
	public Matrix(int width, int height) {
		//Initialize outer array
		data = new double[height][];

		//Initialize each inner array
		for (int i = 0; i < data.Length; i++)
			data[i] = new double[width];
	}

	public double GetValue(int x, int y) {
		return data[y][x];
	}

	public void SetValue(double newValue, int x, int y) {
		data[y][x] = newValue;

	}

	public void Save(string fileName) {
		//Define a text writer
		TextWriter writer = null;
		try {
			//Initialize the text writer using the file name
			writer = new StreamWriter(File.OpenWrite(fileName));

			//Loop over each line and value, and write them back into the file
			for (int i = 0; i < data.Length; i++) {
				for (int j = 0; j < data[i].Length; j++) {
					//Here we write each specific double value
					writer.Write(data[i][j] + (j == data[i].Length - 1 ? "" : ","));
				}
				//Here we jump to the next line
				writer.WriteLine();
			}
		}
		catch (FileNotFoundException) {
			//If the file name was not found in the expected location
			Console.WriteLine("File not found!");
		}
		finally {
			//Close the writer!!! Very important, and not seen in slides if I remember correctly!
			if (writer != null)
				writer.Close();
		}
	}

	override public string ToString() {
		string result = "";
		if (data == null)
			return result;

		for (int i = 0; i < data.Length; i++) {
			for (int j = 0; j < data[i].Length; j++) {
				result += data[i][j] + ",";
			}
			result += "\n";
		}

		return result;
	}
}