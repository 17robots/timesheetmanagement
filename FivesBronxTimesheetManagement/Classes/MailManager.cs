using Aspose.Email;

namespace FivesBronxTimesheetManagement.Classes
{
    class MailManager
    {
        private MailMessage message;

        public MailManager(string to, string subject)
        {
            message.To.Add(new MailAddress("", "", false));
        }

        public static bool sendRejection()
        {
            return true;
        }

        public static bool sendSubmission()
        {
            return true;
        }
    }
}
