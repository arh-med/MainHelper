﻿using System;
using System.Collections.ObjectModel;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces;

namespace MainHelper.Services.ManagerData.TaskManagerData
{
    public class CategoryManagerDataClass : ICategoryManagerInterface
    {
        ICategoryStoreInMemoryInterface categoryStoreInMemoryClass;
        public CategoryManagerDataClass(ICategoryStoreInMemoryInterface categoryStoreInMemoryClass)
        {
            this.categoryStoreInMemoryClass = categoryStoreInMemoryClass;
        }
        public ObservableCollection<CategoryClass> GetAll()
        {
            return categoryStoreInMemoryClass.GetAll();
        }
        public CategoryClass GetByID(Guid guid)
        {
            return categoryStoreInMemoryClass.GetById(guid);
        }

        public void Add(CategoryClass newCategory)
        {
            categoryStoreInMemoryClass.Add(newCategory);
        }
        public void Edit(CategoryClass editCategory)
        {

        }
        public void Delete(CategoryClass removeCategory)
        {
            categoryStoreInMemoryClass.Delete(removeCategory);
        }
        public void Save()
        {
            categoryStoreInMemoryClass.Save();
        }
        public CategoryClass Create(string Name, string Color)
        {
           return  categoryStoreInMemoryClass.Create(Name,  Color);
        }


    }
}
