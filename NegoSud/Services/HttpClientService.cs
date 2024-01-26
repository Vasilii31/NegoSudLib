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
    }
}
