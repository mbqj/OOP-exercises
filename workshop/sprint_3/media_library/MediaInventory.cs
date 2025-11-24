namespace media_library;

public class MediaInventory
{
	private List<Media> media = new List<Media>();

	public List<Media> GetMediaOfType<T>() {
		List<Media> matchingMedia = new List<Media>();

		foreach(Media item in media)
			if (item is T)
				matchingMedia.Add(item);
		
		return matchingMedia;
	}

	public List<Media> GetMediaBySearch(string searchTerm) {
		List<Media> matchingMedia = new List<Media>();

		foreach(Media item in media)
			if (item.title.Contains(searchTerm))
				matchingMedia.Add(item);
		
		return matchingMedia;
	}

	public void AddMedia(Media newMedia) {
		media.Add(newMedia);
	}

	public void RemoveMedia(Media removeMedia) {
		media.Remove(removeMedia);
	}
}
