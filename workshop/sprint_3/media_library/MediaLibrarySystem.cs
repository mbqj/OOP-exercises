namespace media_library;

public class MediaLibrarySystem
{
	public static IUserInterface userInterface {get; private set;}
	public static UserManager userManager {get; private set;}
	public static MediaInventory mediaInventory {get; private set;}

	public MediaLibrarySystem(IUserInterface ui, UserManager um, MediaInventory mi) {
		userInterface = ui;
		userManager = um;
		mediaInventory = mi;

		userInterface.Start();
	}
}
