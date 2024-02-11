using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;

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

        internal static async Task<List<ClientDTO>> GetClients()
        {
            string route = $"api/Client/";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ClientDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<ClientDTO>();
        }
        internal static async Task<VentesDTO> AddVente(VentesWriteDTO vente)
        {
            var venteJson = JsonConvert.SerializeObject(vente);
            string route = $"api/Ventes";

            var content = new StringContent(venteJson, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(route, content);

            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<VentesDTO>(resultat)
                    ?? throw new FormatException($"Erreur lors de la désérialisation de la réponse HTTP : {route}");
            }
            else
            {
                string errorMessage = $"Erreur HTTP : {response.StatusCode} - {response.ReasonPhrase}";
                throw new HttpRequestException(errorMessage);
            }
        }

        public static async Task<ProduitFullDTO> ModifyProduct(ProduitWriteDTO produitWriteDTO, int id)
        {
            var venteJson = JsonConvert.SerializeObject(produitWriteDTO);
            string route = $"api/Produits/{id}";

            var content = new StringContent(venteJson, Encoding.UTF8, "application/json");

            var response = await Client.PutAsync(route, content);

            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProduitFullDTO>(resultat)
                    ?? throw new FormatException($"Erreur lors de la désérialisation de la réponse HTTP : {route}");
            }
            else
            {
                string errorMessage = $"Erreur HTTP : {response.StatusCode} - {response.ReasonPhrase}";
                throw new HttpRequestException(errorMessage);
            }
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
