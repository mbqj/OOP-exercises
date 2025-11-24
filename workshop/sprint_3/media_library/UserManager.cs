namespace media_library;

public class UserManager
{
	private User? currentUser = null;
	private List<User> users = new List<User>();

	public User? GetUserByName(string name) {
		foreach(User user in users)
			if (user.userName.Equals(name))
				return user;
		return null;
	}

	public User? GetUserBySNN(string SNN) {
		foreach(User user in users)
			if (user.socialSecurityNumber.Equals(SNN))
				return user;
		return null;
	}

	public void AddUser(User user) {
		users.Add(user);
	}

	public void RemoveUser(User user) {
		users.Remove(user);
	}

	public void Login(string userName) {
		currentUser = GetUserByName(userName);
		if (currentUser == null)
			MediaLibrarySystem.userInterface.OutputError("User not found!"); 
		else
			MediaLibrarySystem.userInterface.Output("You are now logged in as " + currentUser.userName + "."); 
	}

	public void Logout() {
		MediaLibrarySystem.userInterface.Output("You have been logged out."); 
		currentUser = null;
	}

	public User? GetCurrentUser() {
		return currentUser;
	}
}
