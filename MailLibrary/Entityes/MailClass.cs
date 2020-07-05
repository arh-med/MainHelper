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
        public string Headline { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public DateTime DateMassege { get; set; }
        public bool CheckMail { get; set; }
        public MailClass(string Headline, string From, string Body, DateTime DateMassege,bool CheckMail)
        {
            Id = Guid.NewGuid();
            this.Headline = Headline;
            this.From = From;
            this.Body = Body;
            this.DateMassege = DateMassege;
            this.CheckMail = CheckMail;
        }
    }
}
