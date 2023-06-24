using AccessControl.Enums;

namespace AccessControl
{
	public class Repository
	{
		private const string ADMIN_FOLDER = @"Admin\";
		private const string BLOCKED_ENTRIES = @"Admin\BlockedEntries.txt";
		private const string ALEXANDER = "Alexander";
		private const string ADILYA = "Adilya";
		private const string ARTEM = "Artem";
		private const string POPOV = "Popov";
		public readonly Dictionary<string, UserType> userCollection = new() {
				[ALEXANDER] = UserType.USER,
				[ADILYA] = UserType.USER,
				[ARTEM] = UserType.USER,
				[POPOV] = UserType.ADMIN
		};
		public readonly Dictionary<string, string> passwordCollection = new() {
				[ALEXANDER] = "1234aaa",
				[ADILYA] = "1234bbb",
				[ARTEM] = "1234vvv",
				[POPOV] = "1234admin"
		};
		public readonly Dictionary<string, List<int>> accessCollection = new() {
				[ALEXANDER] = ReadAccess(ADMIN_FOLDER + ALEXANDER + ".txt"),
				[ADILYA] = ReadAccess(ADMIN_FOLDER + ADILYA + ".txt"),
				[ARTEM] = ReadAccess(ADMIN_FOLDER + ARTEM + ".txt"),
				[POPOV] = null
		};
		public readonly Dictionary<string, bool> isBlock = new() {
				/* Последовательность в файле: Alexander, Adilya, Artem */
				[ALEXANDER] = ReadBlockedEntries(BLOCKED_ENTRIES)[0],
				[ADILYA] = ReadBlockedEntries(BLOCKED_ENTRIES)[1],
				[ARTEM] = ReadBlockedEntries(BLOCKED_ENTRIES)[2],
				[POPOV] = true
		};

		private static List<int> ReadAccess(string path)
		{
			using (StreamReader reader = new(path)) {
				List<int> accessRights = new();
				string right;
				while ((right = reader.ReadLine()) != null) {
					accessRights.Add(Convert.ToInt32(right));
				}
				return accessRights;
			}
		}

		private static List<bool> ReadBlockedEntries(string path)
		{
			using (StreamReader reader = new(path)) {
				List<bool> isBlock = new();
				string right;
				while ((right = reader.ReadLine()) != null) {
					isBlock.Add(Convert.ToBoolean(right));
				}
				return isBlock;
			}
		}

		public static void WriteBlockedEntries(Dictionary<string, bool> dictionary)
		{
			using (StreamWriter writer = new(BLOCKED_ENTRIES, false)) {
				foreach (KeyValuePair<string, bool> pair in dictionary) {
					writer.WriteLine(pair.Value);
				}
			}
		}
	}
}