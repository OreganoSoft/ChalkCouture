using ChalkCouture.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ChalkCouture
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitApp();
        }
        private void InitApp()
        {
            ViewModelLocator.RegisterDependencies();
        }

        private Task InitNavigation()
        {
            try
            {
                var navigationService = ViewModelLocator.Resolve<INavigationService>();
                return navigationService.InitializeAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected async override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();
            await InitNavigation();
            base.OnResume();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
