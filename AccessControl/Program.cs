using AccessControl;
using AccessControl.Enums;

try {
	Identification ident = new();
	Console.WriteLine("Введите имя пользователя:");
	if (ident.CheckLogin() == false) {
		Console.WriteLine("Нет такого пользователя!");
		return;
	}
	Console.WriteLine("Введите пароль:");
	if (ident.CheckPassword() == false) {
		Console.WriteLine("Учетная запись заблокирована!!!");
		return;
	}
	ident.CreateFolder();
	if (UserModel.UserType == UserType.USER) {
		User user = new User();
		user.WorksWithFiles();
	}
	if (UserModel.UserType == UserType.ADMIN) {
		Admin admin = new Admin();
		Console.WriteLine("Введите логин пользователя:");
		if (ident.CheckLogin() == false) {
			Console.WriteLine("Нет такого пользователя!");
			return;
		}
		admin.AssignmentRights();
	}
} catch (Exception e) {
	Console.WriteLine(e);
	throw;
}