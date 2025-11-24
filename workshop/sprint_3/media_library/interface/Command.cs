namespace media_library;

public class Command
{
	public string command {get; private set;}
	public UserType? accessLevel {get; private set;}
	private CommandAction action;

	public List<Command> subcommands {get; private set;} = new List<Command>();

	public Command(string command, UserType? accessLevel, CommandAction action) {
		this.command = command;
		this.accessLevel = accessLevel;
		this.action = action;
	}

	//Returns true if the command has been executed!
	public bool Process(User? user, string[] input) {
		if (input.Length > 0 && input[0].Equals(command)) {

			//Check if a sub command matches the input!
			foreach(Command sub in subcommands) {
				if (sub.Process(user, input.Skip(1).ToArray())) {
					return true;
				}
			}

			//Otherwise process this command!
			if ((user == null && accessLevel != null) || (user != null && user.userType < accessLevel)) {
				MediaLibrarySystem.userInterface.OutputError("You do not have access to this command!");
				return true;
			}

			action(input.Skip(1).ToArray());
			return true;
		}
		return false;
	}

	public void AddSubCommand(Command command) {
		subcommands.Add(command);
	}

	public void SetCommandAction(CommandAction action) {
		this.action = action;
	}
}
