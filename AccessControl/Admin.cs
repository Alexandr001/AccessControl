namespace AccessControl
{
	public class Admin
	{
		private const string PATH_ADMIN_FOLDER = @"Admin\";
		private const int MAX_VALUE_ACCESS = 6;
		private const int MIN_VALUE_ACCESS = 1;

		public void AssignmentRights()
		{
			Console.WriteLine("Выберите режим:\n" + "1 - добавить права\n" + "2 - удалить права");
			int operatingMode = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Режимы доступа:\n" + "1 - Чтение\t" + "2 - Запись\n" +
			                  "3 - Создание\t" + "4 - Удаление\n" + 
			                  "5 - Копирование\t" + "6 - Перемещение");
			OutputAvailableModes();
			switch (operatingMode) {
				case 1:
					Console.WriteLine("Выберите режим доступа:");
					AddPrivilege();
					break;
				case 2:
					Console.WriteLine("Выберите режим доступа:");
					RemovePrivilege();
					break;
				default:
					throw new Exception("Неверный формат ввода");
			}
		}

		private void OutputAvailableModes()
		{
			Console.WriteLine($"Режимы доступа доступные пользователю {UserModel.LoginUser}:");
			foreach (int accessModes in UserModel.AccessUser) {
				Console.Write(accessModes + " ");
			}
			Console.Write("\n");
		}

		private void AddPrivilege()
		{
			for (int i = 0; i < Identification.MAXIMUM_NUMBER_OF_ATTEMPTS; i++) {
				int accessModes = Convert.ToInt32(Console.ReadLine());
				if (accessModes < MIN_VALUE_ACCESS || accessModes > MAX_VALUE_ACCESS) {
					Console.WriteLine("Неправильно введен режим доступа!\n" + "Повторите ввод");
					continue;
				}
				if (Сheck(accessModes, true)) {
					Console.WriteLine("Нельзя добавить данный режим доступа, т.к.он уже есть!\n" + "Повторите ввод!");
					continue;
				}
				using (StreamWriter writer = new(PATH_ADMIN_FOLDER + UserModel.LoginUser + ".txt", true)) {
					writer.WriteLine(accessModes);
					return;
				}
			}
			throw new Exception("Неправитьно введен режим доступа!!!");
		}

		private bool Сheck(int accessMode, bool isRemove)
		{
			foreach (int i in UserModel.AccessUser) {
				if (accessMode == i) {
					return isRemove;
				}
			}
			return !isRemove;
		}

		private void RemovePrivilege()
		{
			for (int i = 0; i < Identification.MAXIMUM_NUMBER_OF_ATTEMPTS; i++) {
				int accessModes = Convert.ToInt32(Console.ReadLine());
				if (accessModes < MIN_VALUE_ACCESS || accessModes > MAX_VALUE_ACCESS) {
					Console.WriteLine("Неправильно введен режим доступа!");
					continue;
				}
				if (Сheck(accessModes, false)) {
					Console.WriteLine("Нельзя удалить данный режим доступа, т.к.он не добавлен!\n" + "Повторите ввод!");
					continue;
				}
				List<int> accessUser = UserModel.AccessUser;
				accessUser.Remove(accessModes);
				using (StreamWriter writer = new(PATH_ADMIN_FOLDER + UserModel.LoginUser + ".txt", false)) {
					foreach (int acces in accessUser) {
						writer.WriteLine(acces);
					}
					break;
				}
			}
		}
	}
}