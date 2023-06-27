using System.Text.Json.Serialization;

namespace AccessControl;

public class ListUserModel
{
	public List<UserModel> List { get; set; } = new();
}