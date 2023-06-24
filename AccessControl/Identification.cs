namespace AccessControl;

public class Identification
{
	public const int MAXIMUM_NUMBER_OF_ATTEMPTS = 3;
	private readonly Logger _logger = new();
	private readonly Repository _repo;

	public Identification(Repository repo)
	{
		_repo = repo;
	}

	public void CreateFolder(string login) => Directory.CreateDirectory($"User/{login}");

	public UserModel Autorize()
	{
		UserModel model = CheckLogin() ?? throw new Exception("Такого пользователя не существует!");
		if (CheckPassword(model)) {
			return model;
		}
		throw new Exception("Неверный пароль!");
	}

	public UserModel? CheckLogin()
	{
		for (int i = 0; i < MAXIMUM_NUMBER_OF_ATTEMPTS; i++) {
			Console.WriteLine("Введите логин: ");
			string login = Console.ReadLine() ?? "";
			UserModel? userModel = _repo.GetUser(login);
			if (userModel != null) {
				if (userModel.IsBlock == false) {
					throw new Exception("Пользователь заблокирован!");
				}
				return userModel;
			}
			Console.WriteLine("Неверное имя пользователя!");
		}
		return null;
	}

	public bool CheckPassword(UserModel model)
	{
		for (int i = 0; i < MAXIMUM_NUMBER_OF_ATTEMPTS; i++) {
			Console.WriteLine("Введите пароль:");
			string pass = Console.ReadLine() ?? "";
			if (pass == model.Password) {
				return true;
			}
			Console.WriteLine("Неверный пароль!");
		}
		BlockUser(model);
		return false;
	}

	private void BlockUser(UserModel model)
	{
		model.IsBlock = false;
		_logger.LogEntry(model, "УЧЕТНАЯ ЗАПИСЬ ЗАБЛОКИРОВАНА");
	}
}