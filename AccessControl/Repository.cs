using System.Text.Json;

namespace AccessControl;

public class Repository
{
	private const string PATH_TO_JSON = "/Admin/repository.json";
	public List<UserModel> List { get; private set; }
	public Repository()
	{
		List = JsonSerializer.Deserialize<List<UserModel>>(System.IO.File.ReadAllText(PATH_TO_JSON)) ??
		       throw new NullReferenceException();
	}

	public UserModel? GetUser(string login)
	{
		return List.Find(u => u.Login == login);
	}

	public void SetUsers(UserModel model)
	{
		int findIndex = List.FindIndex(m => m.Login == model.Login);
		if (findIndex == -1) {
			throw new Exception("Не удалось найти пользователя. Что то пошло не так!");
		}
		List[findIndex] = model;
		JsonSerializer.Serialize(List);
	}

	public void AddUser(UserModel model)
	{
		List.Add(model);
	}
	public void RemoveUser(string login)
	{
		UserModel userModel = GetUser(login) ??
		                      throw new NullReferenceException("UserModel is NULL! (Remove user)");
		List.Remove(userModel);
	}

	private void OverwritingJsonFile(string jsonStr)
	{
		System.IO.File.WriteAllText(PATH_TO_JSON, jsonStr);
	}
}