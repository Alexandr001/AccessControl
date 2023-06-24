using AccessControl.Enums;

namespace AccessControl
{
	public class UserModel
	{
		private const string PATH_PROJECT = "C:/Users/Adilya/RiderProjects/AccessСontrol/User/";
		public static UserType UserType { get; private set; }
		public static string HomeFolder { get; private set; }
		public static List<int> AccessUser { get; private set; }
		public static string LoginUser { get; private set; }
		public static bool IsBlock { get; set; }
		public UserModel(string loginUser, UserType userType, string
				                 homeFolder, List<int> accessUser, bool isBlock)
		{
			LoginUser = loginUser;
			UserType = userType;
			HomeFolder = PATH_PROJECT + homeFolder + "/";
			AccessUser = accessUser;
			IsBlock = isBlock;
		}
	}
}