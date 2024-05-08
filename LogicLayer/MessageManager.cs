using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class MessageManager : IMessageManager
    {
        ///<summary>
        /// Creator:            Liam Easton
        /// Created:            02/20/2024
        /// Summary:            Creation of SendEmail method
        /// Last Updated By:    Tyler Barz
        /// Last Updated:       04/03/2024
        /// What Was Changed:   Updated body to work with task queueing
        /// </summary>
        public async Task SendEmail(string to, string subject, string body)
        {
            using (SmtpClient cli = new SmtpClient("smtp.gmail.com", 587))
            {
                string email = "homesforthehomelesscompany@gmail.com";
                MailMessage message = new MailMessage(email, to, subject, body);

                cli.EnableSsl = true;
                cli.Credentials = new NetworkCredential(email, "vtvo iomn pswm sqkw");

                try
                {
                    await cli.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
