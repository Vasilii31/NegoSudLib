using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NegoSudLib.DTO;
using NegoSud.MVVM.Model;
using NegoSudLib.DTO.Read;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;

namespace NegoSud.Services
{
    public class httpClientService
    {
        private const string baseAddress = "https://localhost:7211/";

        //private static HttpClient Client = new() { BaseAddress = new Uri(baseAddress) };
        //private static HttpClient Client { get => new() { BaseAddress = new Uri(baseAddress) }; }

        private static HttpClient? client = null;
        private static CookieContainer cookieContainer = new();


        private static HttpClient Client
        {
            get
            {
                if (client == null)
                {
                    var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
                    client = new(handler) { BaseAddress = new Uri(baseAddress) };
                }
                return client;
            }
        }

        public static async Task<EmployeDTO> GetEmployeByMail(string userName)
        {
            string route = $"api/Employes/mail/{userName}";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmployeDTO>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new EmployeDTO();
        }

        public static async Task<bool> Login(string email, string password)
        {
            //var jsonString = "{ \"email\": \"" + email +"\", \"password\": \""+ password + "\" }";
            var jsonString = "{ \"email\": \"JulietteDu31\", \"password\": \"mdpMDP&1\", \"twoFactorCode\": \"string\", \"twoFactorRecoveryCode\": \"string\" }";
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("login?useCookies=true&useSessionCookies=true", httpContent);
            var cookies = cookieContainer.GetCookies(new Uri(baseAddress));
            Debug.WriteLine(cookies);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<EmployeDTO>> GetEmployes()
        {
            string route = $"api/Employes/";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EmployeDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<EmployeDTO>();
        }

        public static async Task<bool> DeleteEmploye(int id)
        {
            string route = $"api/Employes/{id}";
            //var response = await Client.GetAsync(route);
            var response = await Client.DeleteAsync(route);
            return response.IsSuccessStatusCode;
        }

        public static async Task<EmployeDTO> GetEmployeByUserName(string userName)
        {
            //Debug.WriteLine();
            string route = $"api/Employes/userName/{userName}";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmployeDTO>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new EmployeDTO();
        }

        public static async Task<List<ProduitLightDTO>> GetProduitsAll()
        {
            string route = $"api/Produits/";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProduitLightDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<ProduitLightDTO>();
        }

        public static async Task<bool> DeleteProduit(int id)
        {
            string route = $"api/Produits/{id}";
            //var response = await Client.GetAsync(route);
            var response = await Client.DeleteAsync(route);
            return response.IsSuccessStatusCode;
        }


        //public static async Task<bool> UpdateEmploye(int id, )
        //{

        //}
    }
}
