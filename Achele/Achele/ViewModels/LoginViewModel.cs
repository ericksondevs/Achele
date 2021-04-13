using Achele.Infraestructure;
using Achele.Views;
using System.Windows.Input;

namespace Achele.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Atrributes
        private string username;
        private string password;
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
        #endregion

        #region Commands
        private DelegateCommand loginUserCommand;

        public ICommand LoginUserCommand
        {
            get { return loginUserCommand = loginUserCommand ?? new DelegateCommand(LoginUser); }
        }
        #endregion

        #region Methods
        async void LoginUser()
        {
            if (FieldsValid())
            {
                var user = await App.Database.userService.Get(x=> x.UserName == this.username && x.Password == this.password);

                if (user != null)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No se encontró la cuenta", "Cancelar");
                }
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

            return true;
        }
        #endregion  
    }
}