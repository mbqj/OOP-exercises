namespace media_library;

public class VideoGameMedia : Media, IDownloadable, IPlayable
{
	public string publisher {get; private set;}
	public string genre {get; private set;}
	public int releaseYear {get; private set;}
	public string[] supportedPlatforms {get; private set;}

	public VideoGameMedia(string title, string publisher, string genre, int releaseYear, string[] supportedPlatforms) : base(title) {
		this.publisher = publisher;
		this.genre = genre;
		this.releaseYear = releaseYear;
		this.supportedPlatforms = supportedPlatforms;
	}

	public void Download() {

	}

	public void Play() {

	}

	override public string ToString() {
		string platformsString = "[";
		foreach(string p in supportedPlatforms)
			platformsString += p + ", ";
		platformsString += "]";

		return "Video Game: " + title + ", " + publisher + ", " + genre + ", " + releaseYear + ", " + platformsString;
	}
}
