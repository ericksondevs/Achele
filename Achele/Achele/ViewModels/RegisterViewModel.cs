
using Achele.Infraestructure;
using Achele.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Achele.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Atrributes
        private string username;
        private string email;
        private string password;
        private string confirmPassword;
        #endregion

        #region Properties
        public string UserName
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public string ConfirmPassword
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }
        #endregion

        #region Commands
        private DelegateCommand saveUserCommand;

        public ICommand SaveUserCommand
        {
            get { return saveUserCommand = saveUserCommand ?? new DelegateCommand(SaveUser); }
        }
        #endregion


        #region Methods
        void SaveUser()
        {
            if (FieldsValid())
            {
                User user = new User
                {
                    UserName = this.UserName,
                    Email = this.Email,
                    Password = this.Password,

                };

                App.Database.userService.Insert(user);
            }
        }

        bool FieldsValid()
        {
            if (string.IsNullOrEmpty(this.UserName))
            {
                App.Current.MainPage.DisplayAlert("Error", "EL campo usuario es obligatorio", "Cancelar");
                return false;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                App.Current.MainPage.DisplayAlert("Error", "EL campo contraseña es obligatorio", "Cancelar");
                return false;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                App.Current.MainPage.DisplayAlert("Error", "EL campo contraseña es obligatorio", "Cancelar");
                return false;
            }

            if (this.Password != this.ConfirmPassword)
            {
                App.Current.MainPage.DisplayAlert("Error", "la contraseñas no coinciden", "Cancelar");
                return false;
            }

            return true;
        }
        #endregion
    }
}