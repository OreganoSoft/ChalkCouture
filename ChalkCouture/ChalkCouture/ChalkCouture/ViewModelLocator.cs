using Autofac;
using AutoMapper;
using ChalkCouture.Services;
using ChalkCouture.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ChalkCouture
{
    public static class ViewModelLocator
    {
        private static IContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
          BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // View models

            RegisterViewModels(builder);

            //Services

            RegisterServices(builder);

            //Automapper

            //builder.RegisterAssemblyTypes().AssignableTo(typeof(Profile));

            //register your configuration as a single instance
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                //    //Needs to be changes according to our need. Registering all profile might cause performance issue.
                //    //Some of the configuration should be done in view model contructor
            })).AsSelf().SingleInstance();

            //register your mapper
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().SingleInstance();

            if (_container != null)
            {
                _container.Dispose();
            }

            _container = builder.Build();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            // builder.RegisterType<HttpService>().As<IHttpService>().SingleInstance();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();
            //builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();

        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<LoginViewModel>();

            builder.RegisterType<RootPageViewModel>();
            builder.RegisterType<DashboardViewModel>();

            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<CustomersViewModel>();
            builder.RegisterType<InventoryViewModel>();
            builder.RegisterType<OrdersViewModel>();
            builder.RegisterType<TransferViewModel>();

            builder.RegisterType<AccountViewModel>();
            builder.RegisterType<SettingsViewModel>();

            builder.RegisterType<AddCustomerViewModel>();
            builder.RegisterType<CheckoutViewModel>();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var view = bindable as Element;
                if (view == null)
                {
                    return;
                }

                var viewType = view.GetType();
                var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

                Type viewModelType = Type.GetType(viewModelName);
                if (viewModelType == null)
                {
                    return;
                }

                var viewModel = _container.Resolve(viewModelType);
                view.BindingContext = viewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
