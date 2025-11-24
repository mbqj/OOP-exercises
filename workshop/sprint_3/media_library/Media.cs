namespace media_library;

public abstract class Media
{
	public string title {get; private set;}
	public bool isBorrowed {get; private set;}
	public User? borrower {get; private set;}
	private List<User> hasBeenBorrowedBy = new List<User>();
	private Dictionary<User, int> ratings = new Dictionary<User, int>();

	public Media(string title) {
		this.title = title;
		isBorrowed = false;
		borrower = null;
	}

	public void SetTitle(string newTitle) {
		title = newTitle;
	}

	public void Borrow(User borrowingUser) {
		isBorrowed = true;
		borrower = borrowingUser;
	}

	public void Unborrow() {
		borrower = null;
		isBorrowed = false;
	}

	public void rate(User user, int rating) {

	}
}
