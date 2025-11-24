namespace media_library;

public class CommandFilter
{
	private List<Command> commands = new List<Command>();

	public CommandFilter() {
		Command exitCommand = new Command("exit", null, args => {
			MediaLibrarySystem.userInterface.Stop();
		});
		commands.Add(exitCommand);

		Command helpCommand = new Command("help", null, args => {
			User currentUser = MediaLibrarySystem.userManager.GetCurrentUser();
			string helpString = "Available commands:\n";
			foreach(Command c in commands) {
				if (c.accessLevel == null || (currentUser != null && c.accessLevel <= currentUser.userType))
					helpString += "- " + c.command + "\n";
			}
			MediaLibrarySystem.userInterface.Output(helpString);
		});
		commands.Add(helpCommand);

		Command loginCommand = new Command("login", null, args => {
			if (args.Length == 0) {
				MediaLibrarySystem.userInterface.OutputError("Login requires a username!");
				return;
			}

			string userName = "";
			foreach(string s in args)
				userName += s + " ";
			userName = userName.Trim();

			MediaLibrarySystem.userManager.Login(userName);
		});
		commands.Add(loginCommand);

		Command logoutCommand = new Command("logout", UserType.BORROWER, args => {
			MediaLibrarySystem.userManager.Logout();
		});
		commands.Add(logoutCommand);

		Command browseCommand = new Command("browse", UserType.BORROWER, args => {});
		browseCommand.SetCommandAction(args => {
			string optionsString = "Options for browse:\n";
			foreach (Command sub in browseCommand.subcommands)
				optionsString += "- browse " + sub.command + "\n";

			MediaLibrarySystem.userInterface.Output(optionsString);
		});
		commands.Add(browseCommand);

		Command browseByTypeCommand = new Command("type", UserType.BORROWER, args => {
			if (args.Length == 0) {
				MediaLibrarySystem.userInterface.OutputError("Browse by type requires a type of media!");
				return;
			}

			List<Media> foundMedia = new List<Media>();
			switch (args[0].ToLower()) {
				case "ebook":
					foundMedia = MediaLibrarySystem.mediaInventory.GetMediaOfType<EBookMedia>();
					break;
				case "movie":
					foundMedia = MediaLibrarySystem.mediaInventory.GetMediaOfType<MovieMedia>();
					break;
				case "app":
					foundMedia = MediaLibrarySystem.mediaInventory.GetMediaOfType<AppMedia>();
					break;
				case "song":
					foundMedia = MediaLibrarySystem.mediaInventory.GetMediaOfType<SongMedia>();
					break;
				case "videogame":
					foundMedia = MediaLibrarySystem.mediaInventory.GetMediaOfType<VideoGameMedia>();
					break;
				case "podcast":
					foundMedia = MediaLibrarySystem.mediaInventory.GetMediaOfType<PodcastMedia>();
					break;
				case "image":
					foundMedia = MediaLibrarySystem.mediaInventory.GetMediaOfType<ImageMedia>();
					break;
			}

			string result = "";
			foreach(Media item in foundMedia)
				result += item.ToString() + "\n";

			MediaLibrarySystem.userInterface.Output(result);

		});
		browseCommand.AddSubCommand(browseByTypeCommand);
	}

	public void ProcessCommandString(string? commandString) {
		if (commandString == null)
			return;

		User? currentUser = MediaLibrarySystem.userManager.GetCurrentUser();
		foreach (Command command in commands) {
			if (command.Process(currentUser, commandString.Split(" ")))
				break;
		}
	}
}
