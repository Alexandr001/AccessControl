using AccessControl;
using AccessControl.Enums;
using File = System.IO.File;

try {
	Repository repository = new();
	Identification ident = new(repository);

	Console.WriteLine("1 - Зашифровать или 2 - расшифровать log файл. 0 - Ничего не делать");
	int i = int.Parse(Console.ReadLine()!);
	if (i == 1) {
		Console.WriteLine("Введите пароль");
		string password = Console.ReadLine()!;
		string encryptedText = FileProtection.Encrypt(File.ReadAllText("Admin/log.txt"), password);
		File.WriteAllText("Admin/logEn.txt", encryptedText);
		Console.WriteLine("Зашифрованный текст записан в файл");
	} else if (i == 2) {
		Console.WriteLine("Введите пароль");
		string password = Console.ReadLine()!;
		string decryptedText = FileProtection.Decrypt(File.ReadAllText("Admin/logEn.txt"), password);
		File.WriteAllText("Admin/logDec.txt", decryptedText);
		Console.WriteLine("Расшифрованный текст записан в файл.");
	}

	UserModel model = ident.Autorize();
	if (model.IsBlock == false) {
		repository.SetUsers(model);
		return;
	}
	if (model.Role == Role.user.ToString()) {
		ident.CreateFolder(model.Login);
		User user = new(model);
		user.WorksWithFiles();
	}
	if (model.Role == Role.admin.ToString()) {
		Admin admin = new(repository);
		admin.OperationsWithUsers();
		repository.SetUsers(model);
	}
} catch (Exception e) {
	Console.WriteLine(e.Message);
} finally {
	Console.ReadKey();
}