namespace media_library;

public class PodcastMedia : Media, IDownloadable, IListenable
{
	public int releaseYear {get; private set;}
	public string[] hosts {get; private set;}
	public string[] guests {get; private set;}
	public int episodeNumber {get; private set;}
	public string language {get; private set;}

	public PodcastMedia(string title, int releaseYear, string[] hosts, string[] guests, int episodeNumber, string language) : base(title) {
		this.releaseYear = releaseYear;
		this.hosts = hosts;
		this.guests = guests;
		this.episodeNumber = episodeNumber;
		this.language = language;
	}

	public void Download() {

	}

	public void Listen() {

	}

	override public string ToString() {
		string hostsString = "[";
		foreach(string host in hosts)
			hostsString += host + ", ";
		hostsString += "]";

		string guestsString = "[";
		foreach(string guest in guests)
			guestsString += guest + ", ";
		guestsString += "]";


		return "Podcast: " + title + ", " + releaseYear + ", " + hostsString + ", " + guestsString + ", " + episodeNumber + ", " + language;
	}
}
