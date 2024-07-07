using AccessControl;
using AccessControl.Enums;

try {
	AccessRightsToLoggingFile.RemoveRights();
	
	Repository repository = new();
	Identification ident = new(repository);
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
	if (AccessRightsToLoggingFile.IsUnLock)
	{
		AccessRightsToLoggingFile.RemoveRights();
	}
	else
	{
		AccessRightsToLoggingFile.AddRights();
	}
	Console.ReadKey();
}