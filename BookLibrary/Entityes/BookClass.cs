using BookLibrary.Entityes.Base;
using System;
using System.Collections.Generic;

namespace BookLibrary.Entityes
{
   public class BookClass : EntityNameClass
    {
        public string Headline { get; set; }
        public string ContentBook { get; set; }
        public DateTime DateBook { get; set; }
        public List<CategoryClass> LabelCategory { get; set; }
        public BookClass(string Headline, string ContentBook, DateTime DateBook, List<CategoryClass> LabelCategory)
        {
            this.Headline = Headline;
            this.ContentBook = ContentBook;
            this.DateBook = DateBook;
            this.LabelCategory = LabelCategory;
        }
    }
}
