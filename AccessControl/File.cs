using System.Text;

namespace AccessControl;

public class File
{
	public void Read(string name)
	{
		using (FileStream fstream = System.IO.File.OpenRead(name)) {
			byte[] buffer = new byte[fstream.Length];
			fstream.Read(buffer, 0, buffer.Length);
			string textFromFile = Encoding.Default.GetString(buffer);
			Console.WriteLine("Текст из файла:\n" + $"{textFromFile}");
		}
	}

	public void Write(string name, string? text)
	{
		using (FileStream fStream = new(name, FileMode.Truncate)) {
			byte[] buffer = Encoding.Default.GetBytes(text);
			fStream.Write(buffer, 0, buffer.Length);
		}
		Console.WriteLine("Запись текста в файл прошла успешно.");
	}

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
}