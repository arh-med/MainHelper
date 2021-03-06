﻿using System;
using BookLibrary.Entityes.Base;

namespace BookLibrary.Entityes
{
    public class CategoryClass : EntityNameClass
    {
        public string ColorCategory { get;  set; }
        public CategoryClass(string Name, string ColorCategory)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.ColorCategory = ColorCategory;
        }
        
    }
}
