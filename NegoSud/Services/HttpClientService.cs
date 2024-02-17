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

namespace NegoSud.Services
{
    public class httpClientService
    {
        private const string baseAddress = "https://localhost:7211/api/";
        private static HttpClient Client { get => new() { BaseAddress = new Uri(baseAddress) }; }
        public static async Task<EmployeDTO> GetEmployeByMail(string userName)
        {
            string route = $"Employes/mail/{userName}";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmployeDTO>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new EmployeDTO();
        }

        public static async Task<List<EmployeDTO>> GetEmployes()
        {
            string route = $"Employes/";
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
            string route = $"Employes/{id}";
            //var response = await Client.GetAsync(route);
            var response = await Client.DeleteAsync(route);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<DomaineDTO>> GetDomaines()
        {
            string route = "domaines";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();               
                return JsonConvert.DeserializeObject<List<DomaineDTO>>(resultat)
                    ?? throw new FormatException($"Erreur Http : {route}");
            }
            throw new Exception(response.ReasonPhrase);
        }

        public static async Task<bool> DeleteDomaine(int id)
        {
            string route = $"Domaines/{id}";
            var response = await Client.DeleteAsync(route);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> PostDomaine(DomaineDTO domaine)
        {
            string route = "Domaines";
            var json = JsonConvert.SerializeObject(domaine);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(route, data);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<FournisseurDetailDTO>> GetFournisseurs()
        {
            string route = "fournisseurs";
            var reponse = await Client.GetAsync(route);
            if (reponse.IsSuccessStatusCode)
            {
                string resultat = await reponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<FournisseurDetailDTO>>(resultat)
                    ?? throw new FormatException($"Erreur Http : {route}");
            }
            throw new Exception(reponse.ReasonPhrase);         
        }

        public static async Task<bool> DeleteFournisseur(int id)
        {
            string route = $"Fournisseurs/{id}";
            var response = await Client.DeleteAsync(route);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> PostFournisseur(FournisseurDetailDTO fournisseur)
        {
            string route = "Fournisseurs";
            var json = JsonConvert.SerializeObject(fournisseur);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(route, data);
            return response.IsSuccessStatusCode;
        }

    }
}
