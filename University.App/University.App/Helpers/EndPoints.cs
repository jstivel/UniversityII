namespace University.App.Helpers
{
    public class Endpoints
    {
        public static string URL_BASE_UNIVERSITY_AUTH { get; set; } = "http://university-auth.azurewebsites.net/";
        public static string LOGIN { get; set; } = "api/AccountApp/Login/";
        public static string REGISTER { get; set; } = "api/AccountApp/Register/";
        public static string PROFILE { get; set; } = "api/AccountApp/Profile/";
        public static string GET_USER { get; set; } = "api/AccountApp/GetUser/";
        public static string CHANGE_PASSWORD { get; set; } = "api/AccountApp/ChangePassword";

        public static string URL_BASE_UNIVERSITY_API { get; set; } = "https://university-api.azurewebsites.net/";
        public static string GET_COURSES { get; set; } = "api/Courses/GetCourses/";
    }
}