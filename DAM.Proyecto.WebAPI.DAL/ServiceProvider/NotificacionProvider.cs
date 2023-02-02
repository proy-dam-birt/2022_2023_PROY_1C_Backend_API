using DAM.Proyecto.WebAPI.DAL.Interfaces.IServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.WebAPI.DAL.ServiceProvider
{
    public class NotificationProvider : INotificacionProvider
    { /* private readonly SmtpConfiguration _smtpConfiguration;
        private  User _user;

        #region Ctor
        public EmailProvider(SmtpConfiguration smtpConfiguration)
        {
            _smtpConfiguration = smtpConfiguration;
        }
        #endregion

        public async Task EnviarEmail()
        {
            try
            {
                var mimeMessage = new MimeMessage();
                //_user = user;
                mimeMessage.From.Add(new MailboxAddress(_smtpConfiguration.From, _smtpConfiguration.From));
                mimeMessage.To.Add(new MailboxAddress(_user.Username, _user.email));
                //mimeMessage.Subject = subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    //Text = message
                };

                using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
                smtpClient.Connect(_smtpConfiguration.Hostname, _smtpConfiguration.Port, false);
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }
            catch
            {

            }
            
        }    */
    }
}
