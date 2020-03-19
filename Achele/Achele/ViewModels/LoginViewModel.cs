using Achele.Infraestructure;
using System.Windows.Input;

namespace Achele.ViewModels
{
    public class LoginViewModel
    {
        #region Commands
        private DelegateCommand saveUserCommand;

        public ICommand SaveUserCommand
        {
            get { return saveUserCommand; }
        }
        #endregion
    }
}