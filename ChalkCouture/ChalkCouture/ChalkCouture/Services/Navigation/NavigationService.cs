using ChalkCouture.ViewModels;
using ChalkCouture.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChalkCouture.Services
{
    public class NavigationService : INavigationService
    {
        public async Task InitializeAsync()
        {
            try
            {
                //this.settingsService.ClearAllSettings();

                //var authInfo = this.settingsService.GetValue<AuthInfo>("AuthDetails");
                //if (authInfo == null || string.IsNullOrEmpty(authInfo.AccessToken))
                //    await NavigateToAsync<LoginViewModel>();
                //else
                //{
                //    await this.refreshTokenService.Build();
                //    authInfo = this.settingsService.GetValue<AuthInfo>("AuthDetails");
                //    AppContext.AuthoInfo = authInfo;
                //    AppContext.CurrentUser = this.settingsService.GetValue<ControlUser>(SettingsConstants.User);
                await NavigateToAsync<LoginViewModel>();
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }


        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            try
            {
                Page page = CreatePage(viewModelType, parameter);
                if (page is RootPageView)
                {
                    Application.Current.MainPage = page;
                }
                else if (Application.Current.MainPage is RootPageView)
                {
                    var rootPage = Application.Current.MainPage as RootPageView;
                    if (rootPage.Detail is NavigationPage navigationPage)//if it is internal navigation
                    {
                        var currentPage = navigationPage.CurrentPage;
                        if (currentPage.GetType() != page.GetType())
                            await navigationPage.PushAsync(page);
                    }
                    else
                    {
                        navigationPage = new NavigationPage(page)
                        {
                            BarBackgroundColor = Color.FromHex("#454545"),
                            BarTextColor = Color.White

                        };
                        rootPage.Detail = navigationPage;
                    }
                    rootPage.IsPresented = false;
                }
                else
                {
                    if (page is LoginView)
                        Application.Current.MainPage = page;
                    else
                    if (Application.Current.MainPage is NavigationPage)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(page);
                    }
                }
                await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
            }
            catch (Exception ex)
            {

            }
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        private View CreateView(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }
            try
            {
                View view = Activator.CreateInstance(pageType) as View;

                return view;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
