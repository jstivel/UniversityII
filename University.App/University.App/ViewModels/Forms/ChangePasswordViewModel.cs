using System;
using University.App.Views.Forms;
using University.App.Views.Menu;
using University.BL.DTOs;
using University.BL.Services.Implements;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        #region Attributes
        
        private string _oldPassword;
        private string _confirmPassword;
        private string _newPassword;
        private bool _isEmailValid;
        private bool _isEnabled;
        private bool _isRunning;
        private ApiService _apiService;
        #endregion

        #region Properties
      
        public string OldPassword
        {
            get { return this._oldPassword; }
            set { this.SetValue(ref this._oldPassword, value); }
        }
        public string NewPassword
        {
            get { return this._newPassword; }
            set { this.SetValue(ref this._newPassword, value); }
        }
        public string ConfirmPassword
        {
            get { return this._confirmPassword; }
            set { this.SetValue(ref this._confirmPassword, value); }
        }
        public bool IsEmailValid
        {
            get { return this._isEmailValid; }
            set { this.SetValue(ref this._isEmailValid, value); }
        }
        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set { this.SetValue(ref this._isEnabled, value); }
        }
        public bool IsRunning
        {
            get { return this._isRunning; }
            set { this.SetValue(ref this._isRunning, value); }
        }
        #endregion

        #region Commands
        
        public Command LoginCommand { get; set; }
        public Command ChangePasswordCommand { get; set; }
        #endregion

        #region Methods
        async void Login()
        {
            Application.Current.MainPage = new LoginPage();
        }

        async void ChangePassword()
        {
            try
            {
                this.IsRunning = true;
                this.IsEnabled = false;

                if (!await _apiService.CheckConnection())
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;

                    await Application.Current.MainPage.DisplayAlert("Notification", "No internet connection", "Accept");
                    return;
                }

                if (string.IsNullOrEmpty(this.OldPassword))
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;

                    await Application.Current.MainPage.DisplayAlert("Notification", "The fields are required", "Accept");
                    return;
                }
                
                var changePasswordDTO = new ChangePasswordDTO
                {
                    UserId = Helpers.Settings.UserID,
                    OldPassword = this.OldPassword,
                    NewPassword = this.NewPassword,
                    ConfirmPassword = this.ConfirmPassword
                };

                var responseDTO = await _apiService.RequestAPI<UserDTO>(Helpers.Endpoints.URL_BASE_UNIVERSITY_AUTH,
                    Helpers.Endpoints.CHANGE_PASSWORD,
                    changePasswordDTO,
                    ApiService.Method.Post,
                    true);
            
                if (responseDTO.Code == 200)
                {


                    await Application.Current.MainPage.DisplayAlert("Notification", "Cambio exitoso", "Accept");
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Notification", responseDTO.Message, "Accept");

                this.IsRunning = false;
                this.IsEnabled = true;
            }
            catch (Exception ex)
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Notification", ex.Message, "Accept");
            }
        }
        #endregion

        #region Constructor
        public ChangePasswordViewModel()
        {
            this.IsEmailValid = this.IsEnabled = true;
            this.IsRunning = false;

            this._apiService = new ApiService();
            this.LoginCommand = new Command(Login);
            this.ChangePasswordCommand = new Command(ChangePassword);
        }
        #endregion
    }
}
