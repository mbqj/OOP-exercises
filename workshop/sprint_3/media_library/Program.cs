namespace media_library;

public class Program {
	
	public static void Main(string[] args) {
		UserManager userManager = new UserManager();
		userManager.AddUser(new User("Peter A", 28, "111197-1111", UserType.ADMIN));
		userManager.AddUser(new User("Jimmy E", 37, "222288-3333", UserType.EMPLOYEE));
		userManager.AddUser(new User("Jake B", 19, "555506-5555", UserType.BORROWER));

		MediaInventory mediaInventory = new MediaInventory();
		mediaInventory.AddMedia(new EBookMedia("A Fire Upon The Deep", "Vernor Vince", "English", 378, 1990, "194821-942"));

		MediaLibrarySystem mls = new MediaLibrarySystem(new ConsoleInterface(), userManager, mediaInventory);
	}
}
