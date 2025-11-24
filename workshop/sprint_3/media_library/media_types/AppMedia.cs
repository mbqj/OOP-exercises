namespace media_library;

public class AppMedia : Media, IDownloadable, IExecuteable
{
	public string publisher {get; private set;}
	public string version {get; private set;}
	public string[] supportedPlatforms {get; private set;}
	public int fileSize {get; private set;}

	public AppMedia(string title, string publisher, string version, string[] supportedPlatforms, int fileSize) : base(title) {
		this.publisher = publisher;
		this.version = version;
		this.supportedPlatforms = supportedPlatforms;
		this.fileSize = fileSize;
	}

	public void Download() {

	}

	public void Execute() {

	}

	override public string ToString() {
		string platformsString = "[";
		foreach(string p in supportedPlatforms)
			platformsString += p + ", ";
		platformsString += "]";

		return "App: " + title + ", " + publisher + ", " + version + ", " + supportedPlatforms + ", " + fileSize;
	}
}
