namespace media_library;

public class MovieMedia : Media, IDownloadable, IWatchable
{
	public string director {get; private set;}
	public string[] genres {get; private set;}
	public int releaseYear {get; private set;}
	public string language {get; private set;}
	public int duration {get; private set;}

	public MovieMedia(string title, string director, string[] genres, int releaseYear, string language, int duration) : base(title) {
		this.director = director;
		this.genres = genres;
		this.releaseYear = releaseYear;
		this.language = language;
		this.duration = duration;
	}

	public void Download() {

	}

	public void Watch() {

	}

	override public string ToString() {
		string genresString = "[";
		foreach (string g in genres)
			genresString += g + ", ";
		genresString += "]";
		return "Movie: " + title + ", " + director + ", " + genresString + ", " + releaseYear + ", " + language + ", " + duration;
	}
}
