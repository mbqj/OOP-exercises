namespace media_library;

public class EBookMedia : Media, IDownloadable, IReadable
{
	public string author {get; private set;}
	public string language {get; private set;}
	public int numberOfPages {get; private set;}
	public int yearOfPublication {get; private set;}
	public string ISBN {get; private set;}

	public EBookMedia(string title, string author, string language, int numberOfPages, int yearOfPublication, string ISBN) : base(title) {
		this.author = author;
		this.language = language;
		this.numberOfPages = numberOfPages;
		this.yearOfPublication = yearOfPublication;
		this.ISBN = ISBN;
	}

	public void Download() {

	}

	public void Read() {

	}

	override public string ToString() {
		return "E-Book: " + title + ", " + author + ", " + language + ", " + numberOfPages + ", " + yearOfPublication + ", " + ISBN;
	}

}
