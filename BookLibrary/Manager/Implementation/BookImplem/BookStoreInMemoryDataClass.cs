using BookLibrary.Entityes;
using BookLibrary.Manager.Interfaces.BookInterface;
using BookLibrary.Manager.LocalMemory.LocalMemoryBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.Implementation.BookImplem
{
    public class BookStoreInMemoryDataClass : IBookStoreInMemoryInterface
    {
        BookLocalMemoryClass bookMemoryClass = new BookLocalMemoryClass();
        public void Add(BookClass entity)
        {
            bookMemoryClass.collectionClasses.Add(entity);
        }

        public BookClass Create(string Headline, string ContentBook, DateTime DateBook, ObservableCollection<CategoryClass> LabelCategory)
        {
           BookClass bookClass = new BookClass(Headline, ContentBook, DateBook, LabelCategory);
           return bookClass;
        }

        public void Delete(BookClass entity)
        {
           int index = bookMemoryClass.collectionClasses.IndexOf(entity);
           bookMemoryClass.collectionClasses.RemoveAt(index);
        }

        public void Edit(BookClass entity)
        {
            Guid guid = entity.Id;
            int index = bookMemoryClass.collectionClasses.IndexOf(bookMemoryClass.collectionClasses.FirstOrDefault(c => c.Id == guid));
            bookMemoryClass.collectionClasses.RemoveAt(index);
            BookClass bookClassEdit = entity;
            bookMemoryClass.collectionClasses.Add(bookClassEdit);
        }

        public ObservableCollection<BookClass> GetAll()
        {
            return bookMemoryClass.collectionClasses;
        }

        public BookClass GetByID(Guid guid)
        {
            return bookMemoryClass.collectionClasses.FirstOrDefault(c => c.Id == guid);
        }

        public void Save()
        {
           bookMemoryClass.Serialize();
        }
    }
}
