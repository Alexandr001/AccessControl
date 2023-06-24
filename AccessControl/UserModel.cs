using AccessControl.Enums;

namespace AccessControl
{
	public class UserModel
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public Role Role { get; set; }
		public List<int> AccessUser { get; set; }
		public string HomeFolder { get; set; }
		public bool IsBlock { get; set; }
	}
}