
using BookLibrary.Manager.Implementation.BookImplem;
using BookLibrary.Manager.Implementation.CategoryImplem;
using BookLibrary.Manager.Interfaces.BookInterface;
using BookLibrary.Manager.Interfaces.CategoryInterface;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailLibrary.Manager.Interfaces.Implementation;
using MailLibrary.Manager.Interfaces.MailInterface;
using MainHelper.Services.ManagerData.TaskManagerData;
using MainHelper.UserControlProject.UserControlBook;
using MainHelper.UserControlProject.UserControlMail;
using MainHelper.UserControlProject.UserControlTask;
using TaskLibrary.Manager.Interfaces;


namespace MainHelper.ViewModel
{
   
    public class ViewModelLocator
    {
      
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region TaskLibrary
            SimpleIoc.Default.Register<TaskUserControlViewModelClass>();
            SimpleIoc.Default.Register<ICategoryManagerInterface, CategoryManagerDataClass>();
            SimpleIoc.Default.Register<ICategoryStoreInMemoryInterface, CategoryStoreInMemoryDataClass>();
            SimpleIoc.Default.Register<ITaskManagerInterface, TaskManagerDataClass>();
            SimpleIoc.Default.Register<ITaskStoreInMemoryInterface, TaskStoreInMemoryDataClass>();
            #endregion
            #region BookLibrary
            SimpleIoc.Default.Register<BookUserControlViewModel>();
            SimpleIoc.Default.Register<ICategoryBookManagerInterface, CategoryBookManagerDataClass>();
            SimpleIoc.Default.Register<ICategoryBookStoreInMemoryInterface, CategoryBookStoreInMemoryDataClass>();
            SimpleIoc.Default.Register<IBookManagerInterface, BookManagerDataClass>();
            SimpleIoc.Default.Register<IBookStoreInMemoryInterface, BookStoreInMemoryDataClass>();
            #endregion
            #region MailLibrary
            SimpleIoc.Default.Register<MailUserControlViewModelClass>();
            SimpleIoc.Default.Register<IMailManagerInterface, MailManagerDataClass>();
            #endregion
        }

        public TaskUserControlViewModelClass  taskUserControlViewModelClass
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TaskUserControlViewModelClass>();
            }
        }
        public BookUserControlViewModel bookUserControlViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BookUserControlViewModel>();
            }
        }
        public MailUserControlViewModelClass mailUserControlViewModelClass
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MailUserControlViewModelClass>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}