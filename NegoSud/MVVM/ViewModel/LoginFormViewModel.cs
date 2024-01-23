using NegoSud.Commands;
using NegoSud.MVVM.Model;
using NegoSud.Services;
using NegoSud.Services.Authenticator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class LoginFormViewModel : ViewModelBase
    {

        private string userName;
        private string password;
        private bool _isViewVisible = true;


        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set {
                _isViewVisible = value; 
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginFormViewModel(IAuthenticator authenticator)
        {
            //LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);  
            //LoginCommand = new LoginCommand(this, authenticator);

        }

        private async void ExecuteLoginCommand(object obj)
        {

            //IsViewVisible = false;

            //Task.Run(async () =>
            //{
            //    return await httpClientService.GetEmployeByMail(userName);
            //}).ContinueWith(t =>
            //{
            //    //verifier si on a un utilisateur avant
            //    if(BCrypt.Net.BCrypt.EnhancedVerify(t.Result.HMotDePasse, Password))
            //    {
            //        UserViewModel user = new UserViewModel(t.Result);
            //    }
            //    //foreach (var volLight in t.Result)
            //    //{
            //    //    ListeVols.Add(new VolLightViewModel(volLight));
            //    //}
            //    //NotifyPropertyChanged(nameof(NombreListeVols));
            //}, TaskScheduler.FromCurrentSynchronizationContext());
            //Console.WriteLine(userName + " " + password);  
            // requête API pour trouver l'utilisateur via son userName ? Email ? et vérifier l'authentification
            //using (HttpClient client = new HttpClient())
            //{
            //    var response = await client.GetAsync("http://localhost:7211/api/Employes/mail/" + UserName);
            //    response.EnsureSuccessStatusCode();
            //    if (response.IsSuccessStatusCode)
            //    {
            //        User user = await response.Content.ReadAsAsync<User>();
            //        if (user.VerifyPassword(password))
            //        {
            //            //si login == OK on ferme la loginview et on ouvre la mainwindow

            //        }

            //    }
            //    else
            //    {
            //        //Serveur non joignable ou User not found

            //        // message d'erreur nom d'utilisateur ou mot de passe incorrect
            //    }
            //}


        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = false;

            //if (string.IsNullOrWhiteSpace(UserName) || UserName.Length < 3 || string.IsNullOrWhiteSpace(Password) || Password.Length < 3)
            //{
            //    validData = false;
            //}
            //else
            //    validData = true;
            return validData;
        }
        
    }
}
