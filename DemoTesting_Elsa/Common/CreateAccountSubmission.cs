using PageObjects.Common.Helps;

namespace PageObjects.Common
{
    public class CreateAccountSubmission : GeneralHelper
    {

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public CreateAccountSubmission SetValidValues()
        {
            var timeStamp = GetTimeStamp(DateTime.Now);
            Name = "LastName";
            Email = $"elecTone" + timeStamp.ToString() + "@mailinator.com";
            Password = "ZonePassword123!";
            return this;
        }
    }
}
