using AccessControl.Enums;

namespace AccessControl
{
	public class User
	{
		private Logger _logger = new();
		private File _file = new();

		public void WorksWithFiles()
		{
			for (int i = 0; i < Identification.MAXIMUM_NUMBER_OF_ATTEMPTS; i++) {
				Console.WriteLine(UserModel.HomeFolder);
				Console.WriteLine("Выберите режим работы:\n" + "1 - Создание\t" + "2 - Удаление\n"
				                  + "3 - Копирование\t" + "4 - Перемещение");
				OutputAvailableModes();
				int operatingMode = Convert.ToInt32(Console.ReadLine());
				if (Сheck(operatingMode) == false) {
					Console.WriteLine("Повторите ввод ещё раз!");
					continue;
				}
				Console.WriteLine("Введите название файла:");
				string pathFile = UserModel.HomeFolder + Console.ReadLine();
				switch (operatingMode) {
					case (int) UserAccess.CREATURE:
						Console.WriteLine(UserModel.HomeFolder);
						_file.Create(pathFile);
						_logger.LogEntry(UserAccess.CREATURE);
						return;
					case (int) UserAccess.REMOVAL:
						_file.Remove(pathFile);
						_logger.LogEntry(UserAccess.REMOVAL);
						return;
					case (int) UserAccess.COPYING:
						Console.WriteLine("Введите путь к папке для копирования: ");
						string? pathCopy = Console.ReadLine();
						_file.Copy(pathFile, pathCopy);
						_logger.LogEntry(UserAccess.COPYING);
						return;
					case (int) UserAccess.MOVING:
						Console.WriteLine("Введите путь к папке для Перемещения:");
						string? pathMove = Console.ReadLine();
						_file.Move(pathFile, pathMove);
						_logger.LogEntry(UserAccess.MOVING);
						return;
					default:
						throw new Exception("Что то пошло не так!!!");
				}
			}
		}

		private bool Сheck(int mode)
		{
			List<int> accessUser = UserModel.AccessUser;
			foreach (int i in accessUser) {
				if (i == mode) {
					return true;
				}
			}
			return false;
		}

		private void OutputAvailableModes()
		{
			Console.WriteLine("Доступные режимы доступа:");
			foreach (int accessModes in UserModel.AccessUser) {
				Console.Write(accessModes + " ");
			}
			Console.Write("\n");
		}
	}
}