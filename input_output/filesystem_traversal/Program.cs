class Program {
	public static void Main(string[] args) {
		//List for keeping track of found files
		List<CSVFile> filesFound = new List<CSVFile>();

		//First method call. Using commandline arguement as path
		SearchDirectory(args[0], filesFound);

		//Print all found files
		foreach(CSVFile file in filesFound) {
			Console.WriteLine(file);
		}
	}

	public static void SearchDirectory(string directory, List<CSVFile> filesFound) {
		//Get all files ending with .csv in the targeted directory
		string[] paths = Directory.GetFiles(directory, "*.csv");

		//Add each file to the files found list
		foreach (string path in paths) {
			filesFound.Add(new CSVFile(Path.GetFileName(path), path));
		}

		//Get all subdirectories in the targeted directory
		string[] subdirectories = Directory.GetDirectories(directory);

		//Recursivly search all subdirectories until no more remain
		foreach(string sub in subdirectories) {
			SearchDirectory(sub, filesFound);
		}
	}
}

//Class for storing both name and path of found files
class CSVFile {
	public string name;
	public string path;

	public CSVFile(string name, string path) {
		this.name = name;
		this.path = path;
	}

	override public string ToString() {
		return name + " || " + path;
	}
}