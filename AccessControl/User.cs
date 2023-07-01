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
			Console.WriteLine("Выберите режим работы:\n" + "1 - Чтение\t" + "2 - Запись\n" + 
			                  "3 - Создание\t" + "4 - Удаление");
			OutputAvailableModes();
			int operatingMode = Convert.ToInt32(Console.ReadLine());
			if (Сheck(operatingMode) == false) {
				Console.WriteLine("Повторите ввод ещё раз!");
				continue;
			}
			Console.WriteLine("Введите название файла:");
			string pathFile = _userModel.HomeFolder + "/" + Console.ReadLine();
			switch (operatingMode) {
				case (int) UserAccess.READING:
					_file.Read(pathFile);
					_logger.LogEntry(_userModel, UserAccess.READING);
					return;
				case (int) UserAccess.RECORD:
					Console.WriteLine("Введите текст для записи:");
					string? text = Console.ReadLine();
					_file.Write(pathFile, text);
					_logger.LogEntry(_userModel, UserAccess.RECORD);
					return;
				case (int) UserAccess.CREATURE:
					_file.Create(pathFile);
					_logger.LogEntry(_userModel, UserAccess.CREATURE);
					return;
				case (int) UserAccess.REMOVAL:
					_file.Remove(pathFile);
					_logger.LogEntry(_userModel, UserAccess.REMOVAL);
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