using System.Security.Cryptography;
using System.Text;

namespace WeeLink_Infrastructure.Criptography;

public class PasswordEncrypt
{
    public string Encrypt(string pwd)
    {
        var bytes = Encoding.UTF8.GetBytes(pwd);
        var sha512 = SHA512.Create();
        byte[] hashBytes = sha512.ComputeHash(bytes);
        return StringBytes(hashBytes);
    }

    private string StringBytes(byte[] hashBytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in hashBytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }

        return sb.ToString();
    }
}
