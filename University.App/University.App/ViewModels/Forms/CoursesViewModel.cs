using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using University.App.Helpers;
using University.BL.DTOs;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class CoursesViewModel : BaseViewModel
    {
        #region Attributes
        private BL.Services.Implements.ApiService _apiService;
        private ObservableCollection<CourseDTO> _courses;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<CourseDTO> Courses
        {
            get { return this._courses; }
            set { this.SetValue(ref this._courses, value); }
        }

        public bool IsRefreshing
        {
            get { return this._isRefreshing; }
            set { this.SetValue(ref this._isRefreshing, value); }
        }
        #endregion

        #region Commands
        public Command RefreshCommand { get; set; }
        #endregion

        #region Constructor
        public CoursesViewModel()
        {
            this._apiService = new BL.Services.Implements.ApiService();

            this.RefreshCommand = new Command(GetCourses);
            this.RefreshCommand.Execute(null);
        }
        #endregion

        #region Methods
        async void GetCourses(object obj)
        {
            try
            {
                this.IsRefreshing = true;

                var connection = await _apiService.CheckConnection();
                if (!connection)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert("Notification",
                        "No internet connection",
                        "Cancel");
                    return;
                }

                var responseDTO = await _apiService.RequestAPI<List<CourseDTO>>(Endpoints.URL_BASE_UNIVERSITY_API,
                    Endpoints.GET_COURSES,
                    null,
                    BL.Services.Implements.ApiService.Method.Get);

                this.Courses = new ObservableCollection<CourseDTO>((List<CourseDTO>)responseDTO.Data);
                this.IsRefreshing = false;
            }
            catch (Exception ex)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Notification", ex.Message, "Cancel");
            }
        }
        #endregion
    }
}