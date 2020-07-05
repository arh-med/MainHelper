using MailLibrary.Entityes;
using OpenPop.Mime;
using OpenPop.Pop3;
using MailLibrary.Manager.Interfaces.Base;
using MailLibrary.Manager.Interfaces.MailInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;

namespace MailLibrary.Manager.Interfaces.Implementation
{
    public class MailManagerDataClass : IMailManagerInterface
    {
        //#region Pop3
        //Pop3Client client = new Pop3Client();
        //MessagePart plainTextPart = default(MessagePart);
        //ObservableCollection<MailClass> mailClasses = new ObservableCollection<MailClass>();


        ////Pop3Client client = new Pop3Client();
        ////client.Connect("pop.mail.ru", 995, true);
        ////client.Authenticate("rotarenko1983", "103a89A217", OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword);

        //public bool Connection(string login, string password,string mail, int port)
        //{
        //    client.Connect(mail, port, true);
        //    client.Authenticate(login, password, OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword);
        //    return client.Connected;
        //}
        //public ObservableCollection<MailClass> GetAll()
        //{
        //    int Cont = client.GetMessageCount();
        //    for (int i = Cont; i > Cont - 10; i--)
        //    { 
        //        Message message = client.GetMessage(i);
        //        plainTextPart = message.FindFirstPlainTextVersion();
        //        string Body;
        //        if (plainTextPart is null)
        //        {
        //            Body = " ";
        //        }
        //        else
        //        {
        //            Body = plainTextPart.GetBodyAsText();
        //        }
        //        MailClass mailClass = new MailClass(message.Headers.Subject,message.Headers.From.ToString(), Body, message.Headers.DateSent, message.MessagePart.IsAttachment);
        //        mailClasses.Add(mailClass);
        //    }
        //    return mailClasses;
        //}
        //#endregion

        ImapClient client;
        IMailFolder indox;
        ObservableCollection<MailClass> mailClasses = new ObservableCollection<MailClass>();
        public bool Connection(string login, string password, string mail, int port)
        {
            client = new ImapClient();
                try
                {
                    client.Connect(mail, port, true);
                    client.Authenticate(login, password);
                    indox = client.Inbox;
                    indox.Open(FolderAccess.ReadOnly);
                return true;
                }
                catch (Exception)
                {
                     return false;
                }
               
        }

        public ObservableCollection<MailClass> GetAll()
        {
           
           
            int Count = indox.Count-1;
            for (int i = Count; i > Count -10; i--)
            {
                var message = client.Inbox.GetMessage(i);
                MailClass mailClass = new MailClass(message.Subject, message.From.ToString(), message.TextBody, message.Date.DateTime, true);
                mailClasses.Add(mailClass);
            }
            return mailClasses;
        }
        public int Count()
        {
            int Count = indox.Count - 1;
            return Count;
        }
    }
}
