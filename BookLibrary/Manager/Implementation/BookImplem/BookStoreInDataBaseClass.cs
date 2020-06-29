using BookLibrary.Entityes;
using BookLibrary.Manager.Interfaces.BookInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.Implementation.BookImplem
{
    public class BookStoreInDataBaseClass : IBookStoreInDataBaseInterface
    {
        public void Add(BookClass entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BookClass entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(BookClass entity)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<BookClass> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookClass GetByID(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
