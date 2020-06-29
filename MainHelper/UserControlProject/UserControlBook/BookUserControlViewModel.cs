using BookLibrary.Manager.Interfaces.BookInterface;
using BookLibrary.Manager.Interfaces.CategoryInterface;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MainHelper.UserControlProject.UserControlBook
{
   public class BookUserControlViewModel: ViewModelBase
    {
      
        #region Category
        ICategoryBookManagerInterface categoryManager;
        #endregion
        #region Book
        IBookManagerInterface bookManager;
        #endregion
        public BookUserControlViewModel(ICategoryBookManagerInterface categoryManager, IBookManagerInterface bookManager)
        {
           
            #region Category
            this.categoryManager = categoryManager;
            #endregion
            #region Book
            this.bookManager= bookManager;
            #endregion
        }
    }
}
