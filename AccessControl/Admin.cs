﻿using AccessControl.Enums;

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
			                  "1 - Создать пользователя\n" + 
			                  "2 - Удалить пользователя");
			int operatingMode = int.Parse(Console.ReadLine()!);
			PrintUsers();
			Console.WriteLine();
			switch (operatingMode) {
				case 1:
					CreateUser();
					break;
				case 2:
					RemoveUser();
					break;
				default:
					throw new Exception("Неверный формат ввода");
			}
		}

		private void PrintUsers()
		{
			Console.WriteLine("Существующие пользователи: ");
			foreach (UserModel accessModes in _repo.List.List) {
				Console.WriteLine(accessModes.Login);
			}
		}

		private void CreateUser()
		{
			Console.WriteLine("Введите логин пользователя:");
			string login = Console.ReadLine()!;
			Console.WriteLine("Введите пароль");
			string password = Console.ReadLine()!;
			UserModel userModel = new() {
					Login = login,
					Password = password,
					AccessUser = new List<int>() {
							(int) UserAccess.READING, 
							(int) UserAccess.RECORD,
							(int) UserAccess.CREATURE,
							(int) UserAccess.REMOVAL,
					},
					IsBlock = true,
					HomeFolder = PATH_FOR_USER + login,
					Role = Role.user.ToString()
			};
			_repo.AddUser(userModel);
			Console.WriteLine("Пользователь успешно создан!");
		}

		private void RemoveUser()
		{
			Console.WriteLine("Введите логин пользователя: ");
			string login = Console.ReadLine()!;
			_repo.RemoveUser(login);
			Console.WriteLine("Пользователь успешно удалён!");
		}
	}
}