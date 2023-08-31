namespace AccessControl;

public class File
{
	public void Create(string name)
	{
		System.IO.File.Create(name);
		Console.WriteLine("Файл успешно создан!");
	}

	public void Remove(string name)
	{
		System.IO.File.Delete(name);
		Console.WriteLine("Файл успешно удалён!");
	}
	public void Copy(string name, string? copyPath)
	{
		System.IO.File.Copy(name, copyPath, true);
	}

	public void Move(string name, string? movePath)
	{
		System.IO.File.Move(name, movePath);
	}
}