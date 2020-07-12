using MailLibrary.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailLibrary.Entityes
{
    public class SendMailClass : EntityBaseClass
    {
        public string AddressSender { get; set; }
        public string NameSender { get; set; }
        public string AddresRecipient { get; set; }
        public string BodyMessage { get; set; }
        public string AddressServer { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Headline { get; set; }

        public SendMailClass(string AddressSender, string NameSender, string AddresRecipient, string BodyMessage, string AddressServer, int Port, string Login, string Password,   string Headline)
        {
            this.AddressSender = AddressSender;
            this.NameSender = AddressSender;
            this.AddresRecipient = AddresRecipient;
            this.BodyMessage = BodyMessage;
            this.AddressServer = AddressServer;
            this.Port = Port;
            this.Login = Login;
            this.Password = Password;
            this.Headline = Headline;
        }
    }
}
