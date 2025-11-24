namespace media_library;

public interface IUserInterface
{
	void Start();

	void Output(string str);

	void OutputError(string str);

	void Stop();
}
