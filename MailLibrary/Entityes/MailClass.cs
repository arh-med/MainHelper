using MailLibrary.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailLibrary.Entityes
{
    public class MailClass : EntityBaseClass
    {
        public int Uid { get; set; }
        public string Headline { get; set; }
        public string From { get; set; }
        public char CharFrom { get; set; }
        public string Body { get; set; }
        public string BodyText { get; set; }
        public DateTime DateMassege { get; set; }
        public bool CheckMail { get; set; }
        public bool FlagMail { get; set; }
        public MailClass(int Uid,string Headline, string From, char CharFrom, string Body, string BodyText, DateTime DateMassege,bool CheckMail, bool FlagMail)
        {
            Id = Guid.NewGuid();
            this.Uid = Uid;
            this.Headline = Headline;
            this.From = From;
            this.Body = Body;
            this.BodyText = BodyText;
            this.DateMassege = DateMassege;
            this.CheckMail = CheckMail;
            this.CharFrom = CharFrom;
            this.FlagMail = FlagMail;
        }
    }
}
