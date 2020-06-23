using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces;


namespace MainHelper.UserControlProject.UserControlTask
{
    public class TaskUserControlViewModelClass : ViewModelBase 
    {
        ICategoryManagerInterface categoryManager;
        #region Category
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
        #endregion
        #region Collections Category
        private ObservableCollection<CategoryClass>  categories;
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
        private bool CanAddCategoryCommandExecute( )
        {
            return true;
        }
        private void OnAddCategoryCommandExecute( )
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
        public ICommand HideAddCategoryCommand { get; }
        private bool CanHideAddCategoryCommandExecute()
        {
            return true;
        }
        private void OnHideAddCategoryCommandExecute()
        {
            NameCategory = null;
            ColorCategory = null; 
        }
        #endregion
        public TaskUserControlViewModelClass(ICategoryManagerInterface categoryManager )
        {
            #region Category
            ColorComboBoxCategory = new ObservableCollection<SolidColorBrush> { new SolidColorBrush(Colors.DarkRed), new SolidColorBrush(Colors.DarkGreen), new SolidColorBrush(Colors.DarkGoldenrod), new SolidColorBrush(Colors.DarkCyan), new SolidColorBrush(Colors.DarkKhaki), new SolidColorBrush(Colors.DarkMagenta), new SolidColorBrush(Colors.DarkOliveGreen), new SolidColorBrush(Colors.DarkSalmon), };
            AddCategoryCommand = new RelayCommand(OnAddCategoryCommandExecute, CanAddCategoryCommandExecute);
            HideAddCategoryCommand = new RelayCommand(OnHideAddCategoryCommandExecute, CanHideAddCategoryCommandExecute);
            this.categoryManager = categoryManager;
            Categories = new ObservableCollection<CategoryClass>(categoryManager.GetAll());
            #endregion
        }


    }
}
