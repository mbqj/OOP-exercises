namespace media_library;

public class SongMedia : Media, IListenable, IDownloadable
{
	public string composer {get; private set;}
	public string singer {get; private set;}
	public string genre {get; private set;}
	public string fileType {get; private set;}
	public int duration {get; private set;}
	public string language {get; private set;}

	public SongMedia(string title, string composer, string singer, string genre, string fileType, int duration, string language) : base(title) {
		this.composer = composer;
		this.singer = singer;
		this.genre = genre;
		this.fileType = fileType;
		this.duration = duration;
		this.language = language;
	}

	public void Download() {

	}

	public void Listen() {

	}

	override public string ToString() {
		return "Song: " + title + ", " + composer + ", " + singer + ", " + genre + ", " + fileType + ", " + duration + ", " + language;
	}
}
