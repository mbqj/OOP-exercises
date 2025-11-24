namespace media_library;

public class ConsoleInterface : IUserInterface
{
	private bool shutdown = false;
	private CommandFilter? commandFilter;

	public void Start() {
		commandFilter = new CommandFilter();

		Output("Welcome to the new Media Library!\nPlease type 'login' followed by your username now:");

		while(!shutdown) {
			string? commandString = Console.ReadLine();
			commandFilter?.ProcessCommandString(commandString);
		}
	}

	public void Output(string str) {
		Console.WriteLine(str + "\n");
	}

	public void OutputError(string str) {
		Console.WriteLine("ERROR: " + str + "\n");
	}

	public void Stop() {
		Output("Thanks for using the Media Library.");
		shutdown = true;
	}
}
