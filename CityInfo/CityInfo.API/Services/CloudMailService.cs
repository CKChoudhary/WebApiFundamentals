namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "cloud@mycompany.com";
        private string _mailFrom = "noreply@mycompany.com";


        //public CloudMailService(IConfiguration configuration)
        //{
        //    _mailTo = configuration["mailSettings:mailToAddress"];
        //    _mailFrom = configuration["mailSettings:mailFromAddress"];
        //}

        public void Send(string subject, string message)
        {
            // send mail - output to console window
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with {nameof(CloudMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
