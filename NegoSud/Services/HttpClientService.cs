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
        private const string baseAddress = "https://localhost:7227/api/";
        private static HttpClient Client { get => new() { BaseAddress = new Uri(baseAddress) }; }
        public static async Task<EmployeDTO> GetEmployeByMail(string userName)
        {
            string route = $"employe/mail/{userName}";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<EmployeDTO>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            throw new Exception(response.ReasonPhrase);
        }
    }
}
