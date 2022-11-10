using RestSharp;
using System.Net;
using System.Net.Mail;

namespace Team_3_BucHunt_WebApp.Services;


public class NotificationService
{
    SmtpClient Client;
    public NotificationService()
    {
        Client = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("404IndustriesETSU@gmail.com", "npsovbvygcqovxxg")
        };

    }

    public void SendEmail(string toEmail, string body, string subject)
    {
        MailAddress from = new MailAddress("404IndustriesETSU@gmail.com", "BucHunt - 404 Industries", System.Text.Encoding.UTF8);
        MailAddress to = new MailAddress(toEmail);

        MailMessage message = new MailMessage(from, to);

        message.Body = body;
        message.BodyEncoding = System.Text.Encoding.UTF8;
        message.Subject = subject;
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        
        Client.Send(message);
    }

    public void SendText(string phoneNumber, string body, string carrier)
    {
        MailAddress from = new MailAddress("404IndustriesETSU@gmail.com");
        MailAddress to = new MailAddress(phoneNumber + carrier);

        MailMessage message = new MailMessage(from, to);

        message.Body = body;
        message.BodyEncoding = System.Text.Encoding.UTF8;
        
        Client.Send(message);
    }

}