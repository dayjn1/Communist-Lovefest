/**
* --------------------------------------------------------------------------- 
* File name: NotificationService.cs
* Project name: 404 Industries BucHunt
* --------------------------------------------------------------------------- 
* Author’s name and email: Janine Day, dayjn1@etsu.edu
* Creation Date: Nov 8, 2022
* Last modified: Janine Day, dayjn1@etsu.edu, Nov 10, 2022
* --------------------------------------------------------------------------- 
*/

using System.Net;
using System.Net.Mail;

namespace Team_3_BucHunt_WebApp.Services;

/**
* Class Name: NotificationService
* Class Purpose: Creates object that will handle all notification needs
* <hr>
* Date created: Nov 8, 2022
* Date last modified: Nov 10, 2022 
* @author Janine Day
*/
public class NotificationService
{
    SmtpClient Client;

    /**
    * Method Name: NotificationService
    * Method Purpose: Basic constructor that sets up SMPT client with default settings
    *
    * <hr>
    * Date created: Nov 8, 2022
    * Last modified: Nov 10, 2022
    *
    * <hr>
    * Using gmail for now, should look into getting an ETSU email set up
    * 
    */
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
    }//end NotificationService()

    /**
    * Method Name: SendEmail
    * Method Purpose: Uses param values to set up email and send
    *
    * <hr>
    * Date created: Nov 8, 2022
    * Last modified: Nov 10, 2022
    *
    * <hr>
    * @param string toEmail, email address we are sending information to
    * @param string body,    contents of email body
    * @param string subject, contents of email subject
    */
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
    }//end SendEmail(string, string, string)

    /**
    * Method Name: SendText
    * Method Purpose: Uses param values to set up text and send
    *
    * <hr>
    * Date created: Nov 8, 2022
    * Last modified: Nov 10, 2022
    *
    * Uses carrier email-to-text instead of SMS
    *
    * <hr>
    * @param string phoneNumber, what number are we sending text to
    * @param string body,        contents of text message
    * @param string carrier,     carrier of phone number (like Verizon or AT&T)
    */
    public void SendText(string phoneNumber, string body, string carrier)
    {
        MailAddress from = new MailAddress("404IndustriesETSU@gmail.com");
        MailAddress to = new MailAddress(phoneNumber + carrier);

        MailMessage message = new MailMessage(from, to);

        message.Body = body;
        message.BodyEncoding = System.Text.Encoding.UTF8;
        
        Client.Send(message);
    }//end SendText(string, string, string)
}//end NotificationService