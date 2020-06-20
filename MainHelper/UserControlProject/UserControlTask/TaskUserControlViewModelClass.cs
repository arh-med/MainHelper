using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces;
using TaskLibrary.Manager.TaskManager;

namespace MainHelper.UserControlProject.UserControlTask
{
    public class TaskUserControlViewModelClass : ViewModelBase
    {
        ICategoryManagerInterface categoryManager;
        #region SelectItemComboBox
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
        #region Collections
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
        #region Command
        public ICommand AddCategoryCommand { get; }
        private bool CanAddCategoryCommandExecute( )
        {
            return true;
        }
        private void OnAddCategoryCommandExecute( )
        {
            CategoryClass category = new CategoryClass(NameCategory, ColorCategory.ToString());
            categoryManager.Add(category);
        }
        #endregion
        public TaskUserControlViewModelClass(ICategoryManagerInterface categoryManager )
        {
            ColorComboBoxCategory = new ObservableCollection<SolidColorBrush> {new SolidColorBrush(Colors.DarkRed), new SolidColorBrush(Colors.DarkGreen), new SolidColorBrush(Colors.DarkGoldenrod), new SolidColorBrush(Colors.DarkCyan), new SolidColorBrush(Colors.DarkKhaki), new SolidColorBrush(Colors.DarkMagenta), new SolidColorBrush(Colors.DarkOliveGreen), new SolidColorBrush(Colors.DarkSalmon), };
            AddCategoryCommand = new RelayCommand(OnAddCategoryCommandExecute, CanAddCategoryCommandExecute);
            this.categoryManager = categoryManager;
            Categories = new ObservableCollection<CategoryClass>(categoryManager.GetAll());
        }
    }
}
