
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MainHelper.UserControlProject.UserControlTask;
using TaskLibrary.Manager.Interfaces;
using TaskLibrary.Manager.TaskManager;

namespace MainHelper.ViewModel
{
   
    public class ViewModelLocator
    {
      
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);


            SimpleIoc.Default.Register<TaskUserControlViewModelClass>();
            SimpleIoc.Default.Register<ICategoryManagerInterface, CategoryManagerClass>();
            SimpleIoc.Default.Register<ICategoryStoreInMemoryInterface, CategoryStoreInMemoryClass>();
        }

        public TaskUserControlViewModelClass  taskUserControlViewModelClass
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TaskUserControlViewModelClass>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}