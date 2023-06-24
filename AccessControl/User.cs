using AccessControl.Enums;

namespace AccessControl
{
	public class User
	{
		private Loger _loger = new();
		private File _file = new();

		public void WorksWithFiles()
		{
			for (int i = 0; i < Identification.MAXIMUM_NUMBER_OF_ATTEMPTS; i++) {
				Console.WriteLine(UserModel.HomeFolder);
				Console.WriteLine("Выберите режим работы:\n" + "1 - Чтение\t" + "2 - Запись\n" + "3 - Создание\t" + "4 - Удаление\n"
				                  + "5 - Копирование\t" + "6 - Перемещение");
				OutputAvailableModes();
				int operatingMode = Convert.ToInt32(Console.ReadLine());
				if (Сheck(operatingMode) == false) {
					Console.WriteLine("Повторите ввод ещё раз!");
					continue;
				}
				Console.WriteLine("Введите название файла:");
				string pathFile = UserModel.HomeFolder + Console.ReadLine();
				switch (operatingMode) {
					case (int) UserAccess.READING:
						_file.Read(pathFile);
						_loger.LogEntry(UserAccess.READING);
						return;
					case (int) UserAccess.RECORD:
						Console.WriteLine("Введите текст для записи:");
						string? text = Console.ReadLine();
						_file.Write(pathFile, text);
						_loger.LogEntry(UserAccess.RECORD);
						return;
					case (int) UserAccess.CREATURE:
						Console.WriteLine(UserModel.HomeFolder);
						_file.Create(pathFile);
						_loger.LogEntry(UserAccess.CREATURE);
						return;
					case (int) UserAccess.REMOVAL:
						_file.Remove(pathFile);
						_loger.LogEntry(UserAccess.REMOVAL);
						return;
					case (int) UserAccess.COPYING:
						Console.WriteLine("Введите путь к папке для копирования: ");
						string? pathCopy = Console.ReadLine();
						_file.Copy(pathFile, pathCopy);
						_loger.LogEntry(UserAccess.COPYING);
						return;
					case (int) UserAccess.MOVING:
						Console.WriteLine("Введите путь к папке для Перемещения:");
						string? pathMove = Console.ReadLine();
						_file.Move(pathFile, pathMove);
						_loger.LogEntry(UserAccess.MOVING);
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