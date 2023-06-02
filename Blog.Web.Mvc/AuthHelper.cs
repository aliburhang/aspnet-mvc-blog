using System.Text;

namespace Blog.Web.Mvc.Models
{
    public class AuthHelper
    {
        public static string? Base64Encode(string str)
        {
            if (str == null) return null;

            var textBytes = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(textBytes);
        }

        public static string? Base64Decode(string base64String)
        {
            if (base64String == null) return null;

            var base64EncodedBytes = Convert.FromBase64String(base64String);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
