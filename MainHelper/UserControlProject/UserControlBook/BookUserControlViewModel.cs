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
                if (Books.Count != 0)
                {
                    foreach (BookClass book in new ObservableCollection<BookClass>(bookManager.GetAll()))
                    {
                        if (Data == book.DateBook)
                        {
                            Headline = book.Headline;
                            Content = book.ContentBook;
                            CategoryClassesList = new ObservableCollection<CategoryClass>(book.LabelCategory);

                            HeadlineLastDay = book.Headline;
                            ContentLastDay = book.ContentBook;
                            CategoryClassesListLastDay = book.LabelCategory;
                            return;
                        }
                        else
                        {
                            Headline = null;
                            Content = null;
                            CategoryClassesList.Clear();
                        }
                    }
                }
                else
                {
                    CategoryClassesList = new ObservableCollection<CategoryClass>();
                }
                
            }
        }

        private string headlineLastDay;
        public string HeadlineLastDay
        {
            get
            {
                return headlineLastDay;
            }
            set
            {
                Set(ref headlineLastDay, value);
            }
        }
        private string contentLastDay;
        public string ContentLastDay
        {
            get
            {
                return contentLastDay;
            }
            set
            {
                Set(ref contentLastDay, value);
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
        private ObservableCollection<CategoryClass> categoryClassesListLastDay;
        public ObservableCollection<CategoryClass> CategoryClassesListLastDay
        {
            get
            {
                return categoryClassesListLastDay;
            }
            set
            {
                Set(ref categoryClassesListLastDay, value);
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
            CategoryClassesList.Add(SelectCategory);
        }
        public ICommand AddNewContentCommand { get; }
        private bool CanNewContentCommandExecute()
        {
            return true;
        }
        private void OnNewContentCommandExecute()
        {
            if (Content is null) return;
            bookManager.Add(bookManager.Create(Headline, Content,Data, CategoryClassesList));
            bookManager.Save();
            Books.Add(bookManager.Create(Headline, Content, Data, CategoryClassesList));

            HeadlineLastDay = Headline;
            ContentLastDay = Content;
            CategoryClassesListLastDay = Books[Books.Count - 1].LabelCategory;
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
            AddCategoryInListCommand = new  RelayCommand(OnAddCategoryInListCommandExecute, CanAddCategoryInListCommandExecute);
            AddNewContentCommand = new RelayCommand(OnNewContentCommandExecute, CanNewContentCommandExecute);
            #endregion
            #region Last day
            if (Books.Count != 0)
            {
                HeadlineLastDay = Books[Books.Count - 1].Headline;
                ContentLastDay = Books[Books.Count - 1].ContentBook;
                Data = Books[Books.Count - 1].DateBook;
                CategoryClassesListLastDay = new ObservableCollection<CategoryClass>(Books[Books.Count - 1].LabelCategory);
            }
            else
            {
                HeadlineLastDay = null;
                ContentLastDay = null;
                Data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                CategoryClassesListLastDay = new ObservableCollection<CategoryClass>();
            }
           
            #endregion
        }
    }
}
