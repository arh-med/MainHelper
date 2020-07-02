using BookLibrary.Entityes;
using BookLibrary.Manager.Interfaces.BookInterface;
using BookLibrary.Manager.Interfaces.CategoryInterface;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace MainHelper.UserControlProject.UserControlBook
{
   public class BookUserControlViewModel: ViewModelBase
    {
        

        #region Category
        ICategoryBookManagerInterface categoryManager;
        private string nameCategory;
        public string NameCategory
        {
            get
            {
                return nameCategory;
            }
            set
            {

                Set(ref nameCategory, value);
            }
        }
        private SolidColorBrush colorCategory;
        public SolidColorBrush ColorCategory
        {
            get
            {
                return colorCategory;
            }
            set
            {
                Set(ref colorCategory, value);
            }
        }
        private CategoryClass selectCategory;
        public CategoryClass SelectCategory
        {
            get
            {
                return selectCategory;
            }
            set
            {
                Set(ref selectCategory, value);
            }
        }
        private CategoryClass selectCategorySearch;
        public CategoryClass SelectCategorySearch
        {
            get
            {
                return selectCategorySearch;

            }
            set
            {
                Set(ref selectCategorySearch, value);
            }
        }
        #endregion
        #region Collections Category
        private ObservableCollection<CategoryClass> categories;
        public ObservableCollection<CategoryClass> Categories
        {
            get
            {
                return categories;

            }
            set
            {
                Set(ref categories, value);
            }
        }
        private ObservableCollection<SolidColorBrush> colorComboBoxCategory;
        public ObservableCollection<SolidColorBrush> ColorComboBoxCategory
        {
            get
            {
                return colorComboBoxCategory;
            }
            set
            {
                Set(ref colorComboBoxCategory, value);
            }
        }
        #endregion
        #region Command Category
        public ICommand AddCategoryCommand { get; }
        private bool CanAddCategoryCommandExecute()
        {
            return true;
        }
        private void OnAddCategoryCommandExecute()
        {
            if (NameCategory is null || ColorCategory is null) return;
            // Adding category to the repository
            categoryManager.Add(categoryManager.Create(NameCategory, ColorCategory.ToString()));
            categoryManager.Save();
            //Add category to the list 
            Categories.Add(categoryManager.Create(NameCategory, ColorCategory.ToString()));
            NameCategory = null;
            ColorCategory = null;
        }
        #endregion
        #region Book
        IBookManagerInterface bookManager;
        private string headline;
        public string Headline
        {
            get
            {
                return headline;
            }
            set
            {
                Set(ref headline, value);
            }
        }
        private string content;
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                Set(ref content, value);
            }
        }
        private DateTime data; 
        public DateTime Data
        {
            get
            {
                return data;
            }
            set
            {
                Set(ref data, value);
                if (value == new DateTime()) return;
                #region SortBooksvsData
                Books.Clear();
                foreach (BookClass book in new ObservableCollection<BookClass>(bookManager.GetAll()))
                {
                    if (value == book.DateBook)
                    {
                        Books.Add(book);
                        Headline = book.Headline;
                        Content = book.ContentBook;
                        CategoryClassesList = new ObservableCollection<CategoryClass>(book.LabelCategory);
                        return;
                    }
                    else
                    {
                        Headline = null;
                        Content = null;
                        if (CategoryClassesList != null)
                        {
                            CategoryClassesList = new ObservableCollection<CategoryClass>();
                        }
                    }
                }
                #endregion
            }
        }
        private BookClass bookSelect;
        public BookClass BookSelect
        {
            get
            {
                return bookSelect;
            }
            set
            {
                Set(ref bookSelect, value);
                Books.Clear();
                Books.Add(value);
            }
        }

        #endregion
        #region Collections Book
        private ObservableCollection<CategoryClass> categoryClassesList;
        public ObservableCollection<CategoryClass> CategoryClassesList
        {
            get
            {
                return categoryClassesList;
            }
            set
            {
                Set(ref categoryClassesList, value);
            }
        }
        private ObservableCollection<BookClass> books;
        public ObservableCollection<BookClass> Books
        {
            get
            {
                return books;
            }
            set
            {
                Set(ref books, value);
            }
        }
        private ObservableCollection<BookClass> booksSearch;
        public ObservableCollection<BookClass> BooksSearch
        {
            get
            {
                return booksSearch;
            }
            set
            {
                Set(ref booksSearch, value);
            }
        }
        #endregion
        #region Command Book
        public ICommand AddCategoryInListCommand { get; }
        private bool CanAddCategoryInListCommandExecute()
        {
            return true;
        }
        private void OnAddCategoryInListCommandExecute()
        {
            if (SelectCategory is null) return;
            if (CategoryClassesList is null) CategoryClassesList = new ObservableCollection<CategoryClass>();
            CategoryClassesList.Add(SelectCategory);
        }
        public ICommand AddNewContentCommand { get; }
        private bool CanNewContentCommandExecute()
        {
            return true;
        }
        private void OnNewContentCommandExecute()
        {
            BookClass bookClass = Books.FirstOrDefault(h => h.DateBook == Data);
            if (bookClass != null)
            {
                bookManager.Delete(bookClass);
                Books.Remove(bookClass);
                bookManager.Add(bookManager.Create(Headline, Content, Data, CategoryClassesList));
                bookManager.Save();
                Books.Clear();
                Books.Add(bookManager.Create(Headline, Content, Data, CategoryClassesList));
               
            }
            else
            {
                if (Content is null || Headline is null) return;
                bookManager.Add(bookManager.Create(Headline, Content, Data, CategoryClassesList));
                bookManager.Save();
                Books.Clear();
                Books.Add(bookManager.Create(Headline, Content, Data, CategoryClassesList));
            }
           

        }
        public ICommand DataNowCommand { get; }
        private bool CanDataNowCommandExecute()
        {
            return true;
        }
        private void OnDataNowCommandExecute()
        {
            Data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        }
        public ICommand DataSortAllCommand { get; }
        private bool CanDataSortAllCommandExecute()
        {
            return true;
        }
        private void OnDataSortAllCommandExecute()
        {
            Data = new DateTime();
            Books.Clear();
            Books = new ObservableCollection<BookClass>(bookManager.GetAll());
            Books = new ObservableCollection<BookClass>(Books.OrderBy(x => x.DateBook));
        }
        public ICommand DataLeftCommand { get; }
        private bool CanDataLeftCommandExecute()
        {
            return true;
        }
        private void OnDataLeftCommandExecute()
        {
            if (Data == new DateTime()) return;
            Data = Data.AddDays(-1);
        }
        public ICommand DataRigthCommand { get; }
        private bool CanDataRigthCommandExecute()
        {
            return true;
        }
        private void OnDataRigthCommandExecute()
        {
            Data = Data.AddDays(1);
        }
        public ICommand RemoveEntryCommand { get; }
        private bool CanRemoveEntryCommandExecute()
        {
            return true;
        }
        private void OnRemoveEntryCommandExecute()
        {
          
          BookClass bookClass =  Books.FirstOrDefault(h => h.DateBook == Data);
          if (bookClass is null) return;
            bookManager.Delete(bookClass);
            bookManager.Save();
            Headline = null;
            Content = null;
            CategoryClassesList.Clear();
            Data = new DateTime();
            Books.Clear();
            Books = new ObservableCollection<BookClass>(bookManager.GetAll());
            Books = new ObservableCollection<BookClass>(Books.OrderBy(x => x.DateBook));
        }
        public ICommand SearchEntryCommand { get; }
        private bool CanSearchEntryCommandExecute()
        {
            return true;
        }
        private void OnSearchEntryCommandExecute()
        {

            BooksSearch = new ObservableCollection<BookClass>();
            if (SelectCategorySearch is null) return;
            foreach (BookClass book in new ObservableCollection<BookClass>(bookManager.GetAll()))
            {
                foreach (CategoryClass category in book.LabelCategory)
                {
                    if (category.Name == SelectCategorySearch.Name)
                    {
                        BooksSearch.Add(book);
                        break;
                    }
                }
            }
        }
        #endregion
        public BookUserControlViewModel(ICategoryBookManagerInterface categoryManager, IBookManagerInterface bookManager)
        {
           
            #region Category
            this.categoryManager = categoryManager;
            ColorComboBoxCategory = new ObservableCollection<SolidColorBrush> { new SolidColorBrush(Colors.DarkRed), new SolidColorBrush(Colors.DarkGreen), new SolidColorBrush(Colors.DarkGoldenrod), new SolidColorBrush(Colors.DarkCyan), new SolidColorBrush(Colors.DarkKhaki), new SolidColorBrush(Colors.DarkMagenta), new SolidColorBrush(Colors.DarkOliveGreen), new SolidColorBrush(Colors.DarkSalmon), };
            Categories = new ObservableCollection<CategoryClass>(categoryManager.GetAll());
            AddCategoryCommand = new RelayCommand(OnAddCategoryCommandExecute, CanAddCategoryCommandExecute);
            #endregion
            #region Book
            this.bookManager= bookManager;
            Books = new ObservableCollection<BookClass>(bookManager.GetAll());
            Books = new ObservableCollection<BookClass>(Books.OrderBy(x => x.DateBook));
            AddCategoryInListCommand = new  RelayCommand(OnAddCategoryInListCommandExecute, CanAddCategoryInListCommandExecute);
            AddNewContentCommand = new RelayCommand(OnNewContentCommandExecute, CanNewContentCommandExecute);
            DataNowCommand = new RelayCommand(OnDataNowCommandExecute, CanDataNowCommandExecute);
            DataSortAllCommand = new RelayCommand(OnDataSortAllCommandExecute, CanDataSortAllCommandExecute);
            DataRigthCommand = new RelayCommand(OnDataRigthCommandExecute, CanDataRigthCommandExecute);
            DataLeftCommand = new RelayCommand(OnDataLeftCommandExecute, CanDataLeftCommandExecute);
            RemoveEntryCommand = new RelayCommand(OnRemoveEntryCommandExecute, CanRemoveEntryCommandExecute);
            SearchEntryCommand = new RelayCommand(OnSearchEntryCommandExecute, CanSearchEntryCommandExecute);
            #endregion
           

        }
    }
}
