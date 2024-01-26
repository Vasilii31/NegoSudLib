using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using NegoSud.MVVM.View;
using NegoSud.MVVM.ViewModel;
using NegoSud.MVVM.ViewModel.Factories;
using NegoSud.Services.Authenticator;
using NegoSud.Services.Authentification;
using NegoSud.Services.Navigator;

namespace NegoSud
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, EventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            IAuthentificationService authentificationService = serviceProvider.GetRequiredService<IAuthentificationService>();

            //----------Commencer par ouvrir l'app
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            //----------Commencer par ouvrir le Login
            //var loginView = serviceProvider.GetRequiredService<LoginFormView>();
            //var loginView = new LoginFormView();
            //loginView.DataContext = serviceProvider.GetRequiredService<LoginFormViewModel>();
            //loginView.Show();

            //loginView.IsVisibleChanged += (s, ev) =>
            //{
            //    if (loginView.IsVisible == false && loginView.IsLoaded)
            //    {
            //        Window mainWindow = new MainWindow();
            //        mainWindow.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            //        loginView.Close();
            //        mainWindow.Show();
            //        //Application.Current.MainWindow.Show();
            //    }
            //};


        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();
            //services.AddScoped<LoginFormViewModel>();

            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<IAuthentificationService, AuthentificationService>();

            services.AddSingleton<IViewModelAbstractFactory, ViewModelAbstractFactory>();
            services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<LoginViewModel>, LoginViewModelFactory>(services => 
                new LoginViewModelFactory(services.GetRequiredService<IAuthenticator>(), 
                new ViewModelFactoryRedirector<HomeViewModel>(services.GetRequiredService<INavigator>(),
                services.GetRequiredService<IViewModelFactory<HomeViewModel>>())));
            services.AddSingleton<IViewModelFactory<ProductsViewModel>, ProductsViewModelFactory>();
            services.AddSingleton<IViewModelFactory<EmployesViewModel>, EmployesViewModelFactory>();
            services.AddSingleton<IViewModelFactory<ProductsViewModel>, ProductsViewModelFactory>();
            services.AddSingleton<IViewModelFactory<DomaineViewModel>, DomaineViewModelFactory>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            //services.AddScoped<LoginFormView>(s => new LoginFormView(s.GetRequiredService<LoginFormViewModel>()));
            return services.BuildServiceProvider();
        }
    }

}
