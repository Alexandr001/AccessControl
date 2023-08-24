namespace AccessControl
{
	public class UserModel
	{
		private List<int> _accessUser;
		//Block time in second
		public const int BLOCK_TIME = 10;
		public const string COMMAND_FOR_BLOCK = "BLOCK";
		public string Login { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public List<int> AccessUser
		{
			get
			{
				return _accessUser.Count > 4 
						       ? _accessUser.Distinct().ToList() 
						       : _accessUser;
			}
			set { _accessUser = value; }
		}
		public string HomeFolder { get; set; }
		public bool IsBlock { get; set; }
	}
}