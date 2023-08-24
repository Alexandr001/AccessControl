using System.Net.Mime;

namespace AccessControl;

public static class Writer
{
	public static string Input()
	{
		string? readLine = null;
		Task.Run(() => {
			int i = 0;
			while (true) {
				if (readLine != null) {
					return;
				}
				if (readLine == null && i > UserModel.BLOCK_TIME) {
					Console.WriteLine("Вы слишком долго бездействовали!");
					Environment.Exit(100);
				}
				i += 1;
				Thread.Sleep(1000);
			}
		});
		readLine = Console.ReadLine()!;
		if (readLine == UserModel.COMMAND_FOR_BLOCK) {
			throw new Exception("Программа завершена!");
		}
		
		return readLine;
	}
}