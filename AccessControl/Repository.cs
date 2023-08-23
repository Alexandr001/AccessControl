using System.Text.Json;

namespace AccessControl;

public class Repository
{
	private const string PATH_TO_JSON = "Admin/repository.json";
	public ListUserModel List { get; set; }
	public Repository()
	{
		List = JsonSerializer.Deserialize<ListUserModel>(System.IO.File.ReadAllText(PATH_TO_JSON)) ??
		       throw new NullReferenceException();
	}

	public UserModel? GetUser(string login)
	{
		return List.List.Find(u => u.Login == login);
	}

	public void SetUsers(UserModel model)
	{
		int findIndex = List.List.FindIndex(m => m.Login == model.Login);
		if (findIndex == -1) {
			throw new Exception("Не удалось найти пользователя. Что то пошло не так!");
		}
		List.List[findIndex] = model;
		string serialize = JsonSerializer.Serialize(List);
		OverwritingJsonFile(serialize);
	}

	public void AddUser(UserModel model)
	{
		List.List.Add(model);
	}
	public void RemoveUser(string login)
	{
		UserModel userModel = GetUser(login) ??
		                      throw new NullReferenceException("UserModel is NULL! (Remove user)");
		List.List.Remove(userModel);
	}

	private void OverwritingJsonFile(string jsonStr)
	{
		System.IO.File.WriteAllText(PATH_TO_JSON, jsonStr);
	}

	public void BlockUser(string login)
	{
		GetUser(login).IsBlock = false;
	}

	public void UnblockUser(string login)
	{
		throw new NotImplementedException();
	}
}