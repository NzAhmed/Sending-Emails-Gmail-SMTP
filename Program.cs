 /*
    myaccount.google.com 
    -> security 
    -> 2-Step Verification 
    -> Get Started 

    -> To continue, first verify it's you
    -> setup your phone
    -> 
    2-step verification turned on

    -------------------
    myaccount.google.com
    security -> Signing in to Google
             -> App passwords
    generate passwords ,,,
*/

using System.Net;
using System.Net.Mail;


string smtpAddress = "smtp.gmail.com";  
int portNumber = 587;  
bool enableSSL = true; 

//Sender Email Address  
string SenderAddress = "nizocode@gmail.com"; 
//Sender Password  
string password = "xxxxxxxxxxxxxxxx"; 

//Receiver Email Address  
string ReceiverAddress = "example@gmail.com"; 

string subject = "[Title]";  

string body = "<head>" +
   "</head>" +
   "<body dir='rtl'>" +
       "<!-- Logo -->"
       "<img src='http://vignette3.wikia.nocookie.net/okami/images/2/24/Google_chrome_logo.png/revision/latest?cb=20130220183624' alt='Smiley face' height='42' width='42'>" +

       "<h1>Account confirmation reqest.</h1>" + Environment.NewLine +
       "<a>Dear User, </a>" + Environment.NewLine +
       "<a>In order to be able to use NZ app properly, we require You to confirm Your email address.</a>" + Environment.NewLine +
       "<a>This is the last step towards using our app.</a>" + Environment.NewLine +
       "<a>Pleas follow this hyperlink to confirm your address.</a>" + Environment.NewLine +
       "<a>[Callback url]</a>" +
   "</body>";

using(MailMessage mail = new MailMessage()) 
{  
    mail.From = new MailAddress(SenderAddress);  
    mail.To.Add(ReceiverAddress);  
    mail.Subject = subject;  
    mail.Body = body;  
    mail.IsBodyHtml = true;  
    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
    using(SmtpClient smtp = new SmtpClient(smtpAddress, portNumber)) 
    {  
        smtp.Credentials = new NetworkCredential(SenderAddress, password);  
        smtp.EnableSsl = enableSSL;  
        smtp.Send(mail);  
    }  
}  
