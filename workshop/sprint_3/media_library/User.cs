namespace media_library;

public class User
{
	public string userName {get; private set;}
	public int age {get; private set;}
	public string socialSecurityNumber {get; private set;}
	public UserType userType {get; private set;}

	public User(string userName, int age, string socialSecurityNumber, UserType userType) {
		this.userName = userName;
		this.age = age;
		this.socialSecurityNumber = socialSecurityNumber;
		this.userType = userType;
	}

	public void SetUserName(string newUserName) {
		userName = newUserName;
	}

	public void SetAge(int newAge) {
		age = newAge;
	}

	public void SetSocialSecurityNumber(string newSSN) {
		socialSecurityNumber = newSSN;
	}

	public void SetUserType(UserType newUserType) {
		userType = newUserType;
	}
}
