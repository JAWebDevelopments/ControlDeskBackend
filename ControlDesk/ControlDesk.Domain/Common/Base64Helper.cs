using System.Text;

namespace ControlDesk.Domain.Common
{
    public class Base64Helper
    {
        public static string Encrypt(string stringEnc)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(stringEnc);
            return Convert.ToBase64String(bytes);
        }

        public static string Decrypt(string stringDec)
        {
            byte[] bytes = Convert.FromBase64String(stringDec);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
