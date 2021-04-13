
using Achele.Infraestructure;
using Achele.Models;
using Achele.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

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
            get { return this.username; }
            set { SetValue(ref this.username, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public string ConfirmPassword
        {
            get { return this.confirmPassword; }
            set { SetValue(ref this.confirmPassword, value); }
        }

        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        #endregion

        #region Commands
        private DelegateCommand saveUserCommand;

        public ICommand SaveUserCommand
        {
            get { return saveUserCommand = saveUserCommand ?? new DelegateCommand(SaveUser); }
        }
        #endregion

        #region Constructor
        public RegisterViewModel()
        {
        }
        #endregion

        #region Methods
        async void SaveUser()
        {
            if (FieldsValid())
            {
                User user = new User
                {
                    UserName = this.UserName,
                    Email = this.Email,
                    Password = this.Password,

                };

                var tasks = new List<Task>();

                tasks.Add(App.Database.userService.Insert(user));
                tasks.Add(App.Current.MainPage.Navigation.PushAsync(new HomePage()));
                await Task.WhenAll(tasks);
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

            if (string.IsNullOrEmpty(this.ConfirmPassword))
            {
                App.Current.MainPage.DisplayAlert("Error", "EL campo contraseña de confirmación es obligatoria", "Cancelar");
                return false;
            }

            if (this.Password != this.ConfirmPassword)
            {
                App.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden", "Cancelar");
                return false;
            }

            if (string.IsNullOrEmpty(this.Email))
            {
                App.Current.MainPage.DisplayAlert("Error", "EL correo es obligatorio", "Cancelar");
                return false;
            }

            return true;
        }
        #endregion
    }
}