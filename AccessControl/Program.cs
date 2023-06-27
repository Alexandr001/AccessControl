using AccessControl;
using AccessControl.Enums;

try {
	Repository repository = new();
	Identification ident = new(repository);
	UserModel model = ident.Autorize();
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
	Console.WriteLine(e);
} finally {
	Console.ReadKey();
}