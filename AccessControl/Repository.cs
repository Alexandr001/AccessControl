using AccessControl.Enums;

namespace AccessControl
{
	public class Repository
	{
		private const string ADMIN_FOLDER = @"Admin\";
		private const string BLOCKED_ENTRIES = @"Admin\BlockedEntries.txt";
		private const string GARIK = "Garik";
		private const string IVAN = "Ivan";
		private const string ARTEM = "Artem";
		private const string PETR = "Petr";
		public readonly Dictionary<string, UserType> userCollection = new() {
				[GARIK] = UserType.USER,
				[IVAN] = UserType.USER,
				[ARTEM] = UserType.USER,
				[PETR] = UserType.ADMIN
		};
		public readonly Dictionary<string, string> passwordCollection = new() {
				[GARIK] = "1234aaa",
				[IVAN] = "1234bbb",
				[ARTEM] = "1234vvv",
				[PETR] = "1234admin"
		};
		public readonly Dictionary<string, List<int>> accessCollection = new() {
				[GARIK] = ReadAccess(ADMIN_FOLDER + GARIK + ".txt"),
				[IVAN] = ReadAccess(ADMIN_FOLDER + IVAN + ".txt"),
				[ARTEM] = ReadAccess(ADMIN_FOLDER + ARTEM + ".txt"),
				[PETR] = null
		};
		public readonly Dictionary<string, bool> isBlock = new() {
				/* Последовательность в файле: Alexander, Adilya, Artem */
				[GARIK] = ReadBlockedEntries(BLOCKED_ENTRIES)[0],
				[IVAN] = ReadBlockedEntries(BLOCKED_ENTRIES)[1],
				[ARTEM] = ReadBlockedEntries(BLOCKED_ENTRIES)[2],
				[PETR] = true
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