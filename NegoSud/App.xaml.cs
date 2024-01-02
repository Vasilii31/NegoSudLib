using System.Configuration;
using System.Data;
using System.Windows;
using NegoSud.MVVM.View;

namespace NegoSud
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, EventArgs e)
        {
            var loginView = new LoginFormView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainWindow = new MainWindow();
                    Application.Current.MainWindow = mainWindow;
                    loginView.Close();
                    mainWindow.Show();
                    //Application.Current.MainWindow.Show();
                }
            };

            
        }
    }

}
