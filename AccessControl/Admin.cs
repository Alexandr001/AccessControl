using AccessControl.Enums;

namespace AccessControl
{
	public class Admin
	{
		private readonly Repository _repo;

		public Admin(Repository repo)
		{
			_repo = repo;
		}

		private const string PATH_FOR_USER = "User/";
		
		public void OperationsWithUsers()
		{
			Console.WriteLine("Выберите режим работы:\n" +
			                  "1 - Добавить полномочия\n" +
			                  "2 - Удалить полномочия");
			int operatingMode = int.Parse(Console.ReadLine());
			PrintUsers();
			Console.WriteLine();
			switch (operatingMode) {
				case 1:
					AddRights();
					break;
				case 2:
					RemoveRights();
					break;
				default:
					throw new Exception("Неверный формат ввода");
			}
		}

		private void PrintUsers()
		{
			Console.WriteLine("Существующие пользователи: ");
			foreach (UserModel accessModes in _repo.List.List) {
				Console.WriteLine(accessModes.Login + " - " + accessModes.IsBlock);
			}
		}
		
		private void AddRights()
		{
			Console.WriteLine("Введите логин пользователя: ");
			string login = Console.ReadLine();
			UserModel userModel = _repo.GetUser(login)!;
			
			Console.WriteLine("1 - Чтение\t" + "2 - Запись\n" + 
			                  "3 - Создание\t" + "4 - Удаление");
			Console.WriteLine("Доступные права: " + string.Join(", ", userModel.AccessUser));
			Console.WriteLine("Введите цифру действия с файлами, которую вы хотите добавить:");
			int input = InputMode();
			userModel.AccessUser.Add(input);
		}

		private void RemoveRights()
		{
			Console.WriteLine("Введите логин пользователя: ");
			string login = Console.ReadLine();
			UserModel userModel = _repo.GetUser(login)!;
			
			Console.WriteLine("1 - Чтение\t" + "2 - Запись\n" + 
			                  "3 - Создание\t" + "4 - Удаление");
			Console.WriteLine("Доступные права: " + string.Join(", ", userModel.AccessUser));
			Console.WriteLine("Введите цифру действия с файлами, которую вы хотите удалить:");
			
			int input = InputMode();
			userModel.AccessUser.Remove(input);
			
		}

		private int InputMode()
		{
			int input = int.Parse(Console.ReadLine());
			if (input < 1 || input > 4) {
				throw new Exception("Неверно введенный режим!");
			}
			return input;
		}
	}
}