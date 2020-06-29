using BookLibrary.Entityes;
using BookLibrary.Manager.Interfaces.Base.ManagerBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Manager.Interfaces.BookInterface
{
    public interface IBookStoreInMemoryInterface : IManagerBaseInterface<BookClass>
    {
        BookClass Create(string Headline, string ContentBook, DateTime DateBook, ObservableCollection<CategoryClass> LabelCategory);
    }
}
