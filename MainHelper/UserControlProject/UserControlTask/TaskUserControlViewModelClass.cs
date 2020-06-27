using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using TaskLibrary.Entityes;
using TaskLibrary.Manager.Interfaces;


namespace MainHelper.UserControlProject.UserControlTask
{
    public class TaskUserControlViewModelClass : ViewModelBase 
    {

        #region Category
        ICategoryManagerInterface categoryManager;

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

        private CategoryClass selectedCategory;
        public CategoryClass SelectedCategory
        {
            get
            {
                return selectedCategory;
            }
            set
            {
               
                Set(ref selectedCategory, value);
            }
        }

        private string sortName = "All";
        public string SrotName
        {
            get
            {
                return sortName;
            }
            set
            {
                Set(ref sortName, value);
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
        public ICommand RemoveCategoryCommand { get; }
        private bool CanRemoveCategoryCommandExecute()
        {
            return true;
        }
        private void OnRemoveCategoryCommandExecute()
        {
            if (SelectedCategory is null) return;
            categoryManager.Delete(SelectedCategory);
            categoryManager.Save();
            Categories.Remove(SelectedCategory);

        }
        public ICommand SortCategoryCommand { get; }
        private bool CanSortCategoryCommandExecute(object para)
        {
            return true;
        }
        private void OnSortCategoryCommandExecute(object para)
        {
            CategoryClass categoryClass = (CategoryClass)para;
            Tasks.Clear();
            foreach (TaskClass task in new ObservableCollection<TaskClass>(taskManager.GetAll()))
            {
                if (task.CategoryTask.Name == categoryClass.Name && task.CheckTask == CheckTask)
                {
                    Tasks.Add(task);
                }
            }
            SrotName = categoryClass.Name;

        }
        #endregion
        #region Task
        ITaskManagerInterface taskManager;
       
        private string priority;
        public string Priority
        {
            get
            {
                return priority;
            }
            set
            {
                Set(ref priority, value);
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
            }
        }
        private DateTime time;
        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                Set(ref time, value);
            }
        }
        private CategoryClass taskCategoryClass;
        public CategoryClass TaskCategoryClass
        {
            get
            {
                return taskCategoryClass;
            }
            set
            {
                Set(ref taskCategoryClass, value);
            }
        }
        private string body;
        public string Body
        {
            get
            {
                return body;
            }
            set
            {
                Set(ref body, value);
            }
        }

        private TaskClass selectedTask;
        public TaskClass SelectedTask
        {
            get
            {
                return selectedTask;
            }
            set
            {
                
                Set(ref selectedTask, value);
            }
        }
        // Binding Completed tasks
        private bool checkTask;
        public bool CheckTask
        {
            get
            {
                return checkTask;
            }
            set
            {
                
                Set(ref checkTask, value);
                Tasks = new ObservableCollection<TaskClass>(taskManager.GetAll());
            }
        }

         
        #endregion
        #region Collections Task
        private ObservableCollection<TaskClass> tasks;
        public ObservableCollection<TaskClass> Tasks
        {
            get
            {
                return tasks;

            }
            set
            {
                   
                foreach (TaskClass task in new ObservableCollection<TaskClass>(taskManager.GetAll()))
                {
                    if (task.CheckTask != CheckTask)
                    {
                        value.Remove(task);
                    }
                }
                
                Set(ref tasks, value);
            }
        }
        #endregion
        #region Command Task

        public ICommand AddTaskCommand { get; }
        private bool CanAddTaskCommandExecute()
        {
            return true;
        }
        private void OnAddTaskCommandExecute()
        {
            if (Body is null) return;
            if (Priority == null)
                Priority = "Without";
            if (TaskCategoryClass == null)
            {
                TaskCategoryClass = categoryManager.Create("Without", "White");
            }
            bool CheckAlarm = false;
            DateTime dateTime = new DateTime(Data.Year, Data.Month, Data.Day, Time.Hour, Time.Minute, Time.Second);
            taskManager.Add(taskManager.Create("", Body, DateTime.Now, dateTime, TaskCategoryClass, CheckAlarm, Priority));
            taskManager.Save();
            if (CheckTask == false)
            {
                Tasks.Add(taskManager.Create("", Body, DateTime.Now, dateTime, TaskCategoryClass, CheckAlarm, Priority));
            }         
            Priority = null;
            Data = new DateTime();
            Time = new DateTime();
            CheckAlarm = false;
            TaskCategoryClass = null;
            Body = null;
        }
        public ICommand HideTaskPanel { get; }
        private bool CanHideTaskPanelCommandExecute()
        {
            return true;
        }
        private void OnHideTaskPanelCommandExecute()
        {
            Priority = null;
            Data = new DateTime();
            Time = new DateTime();
            TaskCategoryClass = null;
            Body = null;
        }
        public ICommand DatePickerNow { get; }
        private bool CanDatePickerNowCommandExecute()
        {
            return true;
        }
        private void OnDatePickerNowCommandExecute()
        {

            Data = DateTime.Now;
            Time = DateTime.Now;

        }
        public ICommand RemoveTaskCommand { get; }
        private bool CanRemoveTaskCommandExecute()
        {
            return true;
        }
        private void OnRemoveTaskCommandExecute()
        {
            if (SelectedTask is null) return;
            taskManager.Delete(SelectedTask);
            Tasks.Remove(SelectedTask);
            taskManager.Save();

        }
        public ICommand SortTaskAllCommand { get; }
        private bool CanSortTaskAllCommandExecute()
        {
            return true;
        }
        private void OnSortTaskAllCommandExecute()
        {
            Tasks.Clear();
            Tasks = new ObservableCollection<TaskClass>(taskManager.GetAll());
            SrotName = "All";
        }
        public ICommand SortTaskTodayCommand { get; }
        private bool CanSortTaskTodayCommandExecute()
        {
            return true;
        }
        private void OnSortTaskTodayCommandExecute()
        {
            Tasks.Clear();
            foreach (TaskClass task in new ObservableCollection<TaskClass>(taskManager.GetAll()))
            {
                DateTime dayMonthYearTask = new DateTime(task.AlarmTimeTask.Year, task.AlarmTimeTask.Month, task.AlarmTimeTask.Day);
                DateTime dayMonthYearTaskNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                if (dayMonthYearTask == dayMonthYearTaskNow && task.CheckTask == checkTask)
                {
                    Tasks.Add(task);
                }
            }
            SrotName = "Today";
        }
        public ICommand SortTaskNextSevenDayCommand { get; }
        private bool CanSortTaskNextSevenDayCommandExecute()
        {
            return true;
        }
        private void OnSortTaskNextSevenDayCommandExecute()
        {
            Tasks.Clear();
            for (int i = 0; i < 7; i++)
            {
                foreach (TaskClass task in new ObservableCollection<TaskClass>(taskManager.GetAll()))
                {
                    DateTime dayMonthYearTask = new DateTime(task.AlarmTimeTask.Year, task.AlarmTimeTask.Month, task.AlarmTimeTask.Day);
                    DateTime dayMonthYearTaskNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(i);
                    if (dayMonthYearTask == dayMonthYearTaskNow && task.CheckTask == checkTask)
                    {
                        Tasks.Add(task);
                    }
                }
            }
            SrotName = "Next 7 days";

        }
        public ICommand ComletedTaskComman { get; }
        private bool CanComletedTaskCommanExecute(object para)
        {
            return true;
        }
        private void OnComletedTaskCommanExecute(object para)
        {
            TaskClass taskListView = (TaskClass)para;
            taskListView.CheckTask = !CheckTask;
            taskManager.Edit(taskListView);
            taskManager.Save();
            Tasks.Clear();
            Tasks = new ObservableCollection<TaskClass>(taskManager.GetAll());
        }
        #endregion
        public TaskUserControlViewModelClass(ICategoryManagerInterface categoryManager, ITaskManagerInterface taskManager )
        {
            #region Timer
            
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += (sender, e) =>
             {
                 ObservableCollection<TaskClass> TasksAlarmSort = new ObservableCollection<TaskClass>(taskManager.GetAll());
                 foreach (TaskClass task in TasksAlarmSort)
                 {
                     if (task.CheckTask == false && task.AlarmTimeTask != new DateTime()) 
                     {
                         if (task.AlarmTimeTask <= DateTime.Now)
                         {
                             task.CheckAlarm = true;
                             taskManager.Edit(task);
                             Tasks.Clear();
                             Tasks = new ObservableCollection<TaskClass>(taskManager.GetAll());
                             System.Media.SystemSounds.Asterisk.Play();
                         }    
                     }
                 }
             };
            timer.Start();
            #endregion
            #region Category
            ColorComboBoxCategory = new ObservableCollection<SolidColorBrush> { new SolidColorBrush(Colors.DarkRed), new SolidColorBrush(Colors.DarkGreen), new SolidColorBrush(Colors.DarkGoldenrod), new SolidColorBrush(Colors.DarkCyan), new SolidColorBrush(Colors.DarkKhaki), new SolidColorBrush(Colors.DarkMagenta), new SolidColorBrush(Colors.DarkOliveGreen), new SolidColorBrush(Colors.DarkSalmon), };
            AddCategoryCommand = new RelayCommand(OnAddCategoryCommandExecute, CanAddCategoryCommandExecute);
            HideAddCategoryCommand = new RelayCommand(OnHideAddCategoryCommandExecute, CanHideAddCategoryCommandExecute);
            RemoveCategoryCommand = new RelayCommand(OnRemoveCategoryCommandExecute, CanRemoveCategoryCommandExecute);
            SortCategoryCommand = new RelayCommand<object>(OnSortCategoryCommandExecute, CanSortCategoryCommandExecute);
            this.categoryManager = categoryManager;
            Categories = new ObservableCollection<CategoryClass>(categoryManager.GetAll());
            #endregion
            #region Task
            this.taskManager = taskManager;
            AddTaskCommand = new RelayCommand(OnAddTaskCommandExecute, CanAddTaskCommandExecute);
            HideTaskPanel = new RelayCommand(OnHideTaskPanelCommandExecute, CanHideTaskPanelCommandExecute);
            DatePickerNow = new RelayCommand(OnDatePickerNowCommandExecute, CanDatePickerNowCommandExecute);
            RemoveTaskCommand = new RelayCommand(OnRemoveTaskCommandExecute, CanRemoveTaskCommandExecute);
            SortTaskAllCommand = new RelayCommand(OnSortTaskAllCommandExecute, CanSortTaskAllCommandExecute);
            SortTaskTodayCommand = new RelayCommand(OnSortTaskTodayCommandExecute, CanSortTaskTodayCommandExecute);
            SortTaskNextSevenDayCommand = new RelayCommand(OnSortTaskNextSevenDayCommandExecute, CanSortTaskNextSevenDayCommandExecute);
            ComletedTaskComman = new RelayCommand<object>(OnComletedTaskCommanExecute, CanComletedTaskCommanExecute);
            Tasks = new ObservableCollection<TaskClass>(taskManager.GetAll());
            #endregion
         }


    }
}
