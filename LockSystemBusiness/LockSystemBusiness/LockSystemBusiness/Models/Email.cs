using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Data;
using System.Collections;

namespace LockSystemBusiness.Classes
{
    public static class Email
    {
        //send email with attachment
        public static bool SendEmail(string emailToSend, string subjectToSend, string MsgBody)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
            mail.From = new MailAddress("");
            //mail.From = new MailAddress("stevey@coastalflow.com");
            mail.Subject = subjectToSend;
            mail.To.Add(emailToSend);
            mail.Bcc.Add("");
            mail.Body = MsgBody;
            SmtpServer.Port = 587;
            SmtpServer.EnableSsl = true;
            System.Net.NetworkCredential aCredential = new System.Net.NetworkCredential("", "");
            SmtpServer.Credentials = aCredential;
            try
            {
                SmtpServer.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                //attachment.Dispose();
            }

        }
    }
}