using University.App.Interfaces;
using University.App.Resources;
using Xamarin.Forms;

namespace University.App.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept { get { return Resource.Accept; } }
        public static string Notification { get { return Resource.Notification; } }
        public static string NoInternetConnection { get { return Resource.NoInternetConnection; } }
        public static string FieldsRequired { get { return Resource.FieldsRequired; } }
    }
}