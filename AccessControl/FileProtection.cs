using System.Text;

namespace AccessControl;

public static class FileProtection
{
	public static string Encrypt(string text, string key)
	{
		StringBuilder encrypted = new();
            
		for (int i = 0; i < text.Length; i++)
		{
			int keyIndex = i % key.Length;
			char encryptedChar = (char) (text[i] ^ key[keyIndex]);
			encrypted.Append(encryptedChar);
		}
            
		return encrypted.ToString();
	}
        
	public static string Decrypt(string encryptedText, string key)
	{
		return Encrypt(encryptedText, key); // Шифрование и расшифрование одной операцией XOR
	}
}

