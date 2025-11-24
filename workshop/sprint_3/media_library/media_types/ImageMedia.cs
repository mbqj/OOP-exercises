namespace media_library;

public class ImageMedia : Media, IDownloadable, IDisplayable
{
	public string resolution {get; private set;}
	public string fileFormat {get; private set;}
	public int fileSize {get; private set;}
	public string dateTaken {get; private set;}

	public ImageMedia(string title, string resolution, string fileFormat, int fileSize, string dateTaken) : base(title) {
		this.resolution = resolution;
		this.fileFormat = fileFormat;
		this.fileSize = fileSize;
		this.dateTaken = dateTaken;
	}

	public void Download() {

	}

	public void Display() {

	}

	override public string ToString() {
		return "Image: " + title + ", " + resolution + ", " + fileFormat + ", " + fileSize + ", " + dateTaken;
	}
}
