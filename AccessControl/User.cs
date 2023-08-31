using AccessControl.Enums;

namespace AccessControl;

public class User
{
	private readonly UserModel _userModel;
	private readonly Logger _logger = new();
	private readonly File _file = new();

	public User(UserModel userModel)
	{
		_userModel = userModel;
	}
	public void WorksWithFiles()
	{
		for (int i = 0; i < Identification.MAXIMUM_NUMBER_OF_ATTEMPTS; i++) {
			Console.WriteLine("Домашняя папка: " + _userModel.HomeFolder);
			Console.WriteLine("Выберите режим работы:\n" + "1 - Создание\t" + "2 - Удаление\n" + 
			                  "3 - Копирование\t" + "4 - Перемещение");
			OutputAvailableModes();
			int operatingMode = Convert.ToInt32(Console.ReadLine());
			if (Сheck(operatingMode) == false) {
				Console.WriteLine("Повторите ввод ещё раз!");
				continue;
			}
			Console.WriteLine("Введите название файла:");
			string pathFile = _userModel.HomeFolder + "/" + Console.ReadLine();
			switch (operatingMode) {
				case (int) UserAccess.CREATURE:
					_file.Create(pathFile);
					_logger.LogEntry(_userModel, UserAccess.CREATURE);
					return;
				case (int) UserAccess.REMOVAL:
					_file.Remove(pathFile);
					_logger.LogEntry(_userModel, UserAccess.REMOVAL);
					return;
				case (int) UserAccess.COPYING:
					Console.WriteLine("Введите путь к папке для копирования: ");
					string? pathCopy = Console.ReadLine();
					_file.Copy(pathFile, pathCopy);
					_logger.LogEntry(_userModel, UserAccess.COPYING);
					return;
				case (int) UserAccess.MOVING:
					Console.WriteLine("Введите путь к папке для Перемещения:");
					string? pathMove = Console.ReadLine();
					_file.Move(pathFile, pathMove);
					_logger.LogEntry(_userModel, UserAccess.MOVING);
					return;
				default:
					throw new Exception("Что то пошло не так!!!");
			}
		}
	}

	private bool Сheck(int mode)
	{
		List<int> accessUser = _userModel.AccessUser;
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
		foreach (int accessModes in _userModel.AccessUser) {
			Console.Write(accessModes + " ");
		}
		Console.Write("\n");
	}
}