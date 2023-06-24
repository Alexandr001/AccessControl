using AccessControl.Enums;

namespace AccessControl;

public class Identification
{
	public const int MAXIMUM_NUMBER_OF_ATTEMPTS = 3;
	private readonly Repository _repository = new();
	private readonly Loger _loger = new();
	private string _login;
	private string _password;
	public void CreateFolder() =>
			Directory.CreateDirectory(UserModel.HomeFolder);
	public bool CheckLogin()
	{
		for (int i = 0; i < MAXIMUM_NUMBER_OF_ATTEMPTS; i++)
		{
			_login = Console.ReadLine();
			foreach (KeyValuePair<string, UserType> id in
			         _repository.userCollection) {
				if (id.Key == _login) {
					UserModel userModel = new(_login,
					                          _repository.userCollection[_login],
					                          _login,
					                          _repository.accessCollection[_login],
					                          _repository.isBlock[_login]);
					if (UserModel.IsBlock == false) {
						Console.WriteLine("Учетная запись заблокирована!");
						return false;
					}
					return true;
				}
			}
		}
		return false;
	}
	public bool CheckPassword()
	{
		for (int i = 0; i < MAXIMUM_NUMBER_OF_ATTEMPTS; i++)
		{
			_password = Console.ReadLine();
			if (_repository.passwordCollection[_login] == _password) {
				Console.WriteLine($"Вы вошли как: {_login}\n" +
				                  $"C правами: {_repository.userCollection[_login]}");
				_loger.LogEntry("ВХОД");
				return true;
			}
		}
		BlockEntry(false);
		return false;
	}
	private void BlockEntry(bool isBlock)
	{
		_repository.isBlock[UserModel.LoginUser] = false;
		Repository.WriteBlockedEntries(_repository.isBlock);
		_loger.LogEntry("УЧЕТНАЯ ЗАПИСЬ ЗАБЛОКИРОВАНА");
	}
}