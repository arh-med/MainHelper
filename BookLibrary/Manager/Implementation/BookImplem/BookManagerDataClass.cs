using BookLibrary.Entityes;
using BookLibrary.Manager.Interfaces.BookInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookLibrary.Manager.Implementation.BookImplem
{
    public class BookManagerDataClass : IBookManagerInterface
    {
        IBookStoreInMemoryInterface bookStoreInMemoryInterface;
        public BookManagerDataClass(IBookStoreInMemoryInterface bookStoreInMemoryInterface)
        {
            this.bookStoreInMemoryInterface = bookStoreInMemoryInterface;
        }
        public void Add(BookClass entity)
        {
            bookStoreInMemoryInterface.Add(entity);
        }

        public BookClass Create(string Headline, string ContentBook, DateTime DateBook, ObservableCollection<CategoryClass> LabelCategory)
        {
            return bookStoreInMemoryInterface.Create(Headline, ContentBook, DateBook, LabelCategory);
        }

        public void Delete(BookClass entity)
        {
            bookStoreInMemoryInterface.Delete(entity);
        }

        public void Edit(BookClass entity)
        {
            bookStoreInMemoryInterface.Edit(entity);
        }

        public ObservableCollection<BookClass> GetAll()
        {
            return bookStoreInMemoryInterface.GetAll();
        }

        public BookClass GetByID(Guid guid)
        {
            return bookStoreInMemoryInterface.GetByID(guid);
        }

        public void Save()
        {
            bookStoreInMemoryInterface.Save();
        }
    }
}
