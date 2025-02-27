using PageObjects.Common.Base;

namespace PageObjects.Common.Helps
{
    public class GeneralHelper : GlobalBase
    {
        public static string GetTimeStamp(DateTime value, string format = "yyyyMMddHHmmss")
        {
            // Gets timestamp in defined format
            var timeStamp = value.ToString(format);
            Log.Info("Timestamp generated: " + timeStamp);
            return timeStamp;
        }

        public static string GenerateRandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            // Generate random string of given length
            var random = new Random();
            var randomString = new string(Enumerable.Repeat(allowedChars, length).Select(s => s[random.Next(s.Length)])
                .ToArray());
            Log.Info("Random string generated: " + randomString);
            return randomString;
        }

        public static string GenerateUniqueEmail()
        {
            // Appends timestamp to first part of email to create unique address
            var timestamp = GetTimeStamp(DateTime.Now, "yyyyMMddHHmmssfff");
            var emailAddress = "electroluxtestautomation" + timestamp + "@mailinator.com";
            Log.Info("Email address generated: " + emailAddress);
            return emailAddress;
        }
    }
}
