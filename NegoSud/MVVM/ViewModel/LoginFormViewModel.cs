using NegoSud.MVVM.Model;
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

        public LoginFormViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);  
        }

        private async void ExecuteLoginCommand(object obj)
        {

            IsViewVisible = false;
            //Console.WriteLine(userName + " " + password);  
            // requête API pour trouver l'utilisateur via son userName ? Email ? et vérifier l'authentification
            //using (HttpClient client = new HttpClient())
            //{
            //    var response = await client.GetAsync("http://localhost:3300/api/users/nomutilisateur");
            //    response.EnsureSuccessStatusCode();
            //    if (response.IsSuccessStatusCode)
            //    {
            //        User user = await response.Content.ReadAsAsync<User>();
            //        if(user.VerifyPassword(password))
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
            bool validData;

            if (string.IsNullOrWhiteSpace(UserName) || UserName.Length < 3 || string.IsNullOrWhiteSpace(Password) || Password.Length < 3)
            {
                validData = false;
            }
            else
                validData = true;
            return validData;
        }
        
    }
}
