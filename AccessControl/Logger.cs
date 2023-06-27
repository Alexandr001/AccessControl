using AccessControl.Enums;

namespace AccessControl
{
	public class Logger
	{
		private const string PATH = "Admin/log.txt";
		public void LogEntry(UserModel model, UserAccess action)
		{
			string log = $"Пользователь [{model.Login}]; действие[{action}]; дата и время: {DateTime.Now}";
			using (StreamWriter writer = new(PATH, true))
			{
				writer.WriteLine(log);
			}
		}
		public void LogEntry(UserModel model, string action)
		{
			string log = $"Пользователь [{model.Login}]; действие[{action}]; дата и время: {DateTime.Now}";
			using (StreamWriter writer = new(PATH, true))
			{
				writer.WriteLine(log);
			}
		}
	}
}