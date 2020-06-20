
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MainHelper.Services.ManagerData.TaskManagerData;
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
            #endregion
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