﻿using MailLibrary.Entityes;
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
        #region MailKit Imap
        ImapClient client;
        IMailFolder folderMail;
        
        ObservableCollection<MailClass> mailClasses;
        
        public bool Connection(string login, string password, string mail, int port)
        {
            client = new ImapClient();
                try
                {client.Connect(mail, port, true);
                 client.Authenticate(login, password);  
                return true;
                }
                catch (Exception)
                {
                     return false;
                }
               
        }
        public void Indox()
        { folderMail = client.Inbox;
          folderMail.Open(FolderAccess.ReadWrite); }

        public ObservableCollection<MailClass> GetAll(int Count, int returnMessage)
        {
            bool Flag;
            if (Count >= folderMail.Count || Count <= 0) return mailClasses;
            mailClasses = new ObservableCollection<MailClass>();
            for (int i = Count; i > Count - returnMessage; i--)
            {
                if (i > folderMail.Count || i <= 0) return mailClasses;
                var message = client.Inbox.GetMessage(i);
                char CharFrom = message.From.ToString().ToArray()[1];
                var folderMailInfo = client.Inbox.Fetch(new[] { i }, MessageSummaryItems.Flags);
                if (folderMailInfo[0].Flags.ToString() == "Seen")
                {Flag = false;}
                else
                { Flag = true; }
                MailClass mailClass = new MailClass(i,message.Subject, message.From.ToString(), CharFrom, message.HtmlBody,message.TextBody, message.Date.DateTime, false, Flag);
                mailClasses.Add(mailClass);
            }
            return mailClasses;
        }
        public int Count()
        {
            int Count = folderMail.Count - 1;
            return Count;
        }

        public void Delete(int index)
        {
            folderMail.AddFlags(index, MessageFlags.Deleted, false);
            client.Disconnect(false);
        }
        public void DeleteRange(IList<int> indexList)
        {
            folderMail.AddFlags(indexList, MessageFlags.Deleted,false);
            client.Disconnect(false);
        }

        public void FlagSeen(int index)
        {
            folderMail.AddFlags(index, MessageFlags.Seen, true);
        }
        #endregion

    }
}
