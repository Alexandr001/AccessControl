using AccessControl.Enums;

namespace AccessControl
{
	public class Logger
	{
		private const string PATH = @"Admin\log.txt";
		public void LogEntry(UserAccess action)
		{
			string log = $"Пользователь [{UserModel.LoginUser}]; действие[{action}]; дата и время: {DateTime.Now}";
			using (StreamWriter writer = new(PATH, true))
			{
				writer.WriteLine(log);
			}
		}
		public void LogEntry(string action)
		{
			string log = $"Пользователь [{UserModel.LoginUser}]; действие[{action}]; дата и время: {DateTime.Now}";
			using (StreamWriter writer = new StreamWriter(PATH, true))
			{
				writer.WriteLine(log);
			}
		}
	}
}