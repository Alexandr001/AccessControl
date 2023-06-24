using AccessControl.Enums;

namespace AccessControl
{
	public class Loger
	{
		private const string PATH = @"Admin\journal.txt";
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