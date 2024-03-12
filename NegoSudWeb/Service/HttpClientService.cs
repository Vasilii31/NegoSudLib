using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.write;
using NegoSudLib.DTO.Write;
using NegoSudWeb.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace NegoSudWeb.Services
{
    public static class httpClientService
    {
        private const string apiAdresse = "https://localhost:7211/";
        private const string webAdresse = "https://localhost:7070/";
        //private readonly UserManager<User> _userManager;

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
                    var handler = new HttpClientHandler()
                    {
                        UseCookies = true,
                        AllowAutoRedirect = true,
                        UseDefaultCredentials = true,
                        CookieContainer = cookieContainer
                    };
                    client = new(handler) { BaseAddress = new Uri(apiAdresse) };
                }
                //var cookie = new Cookie(".AspNetCore.Identity.Application",);
                //cookieContainer.Add(client.BaseAddress, cookie);
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

            var jsonString = "{ \"email\": \"" + email + "\", \"password\": \"" + password + "\" }";
            //var jsonString = "{ \"email\": \"JulietteDu31\", \"password\": \"mdpMDP&1\", \"twoFactorCode\": \"string\", \"twoFactorRecoveryCode\": \"string\" }";
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("login?useCookies=true&useSessionCookies=true", httpContent);

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

        public static async Task<List<ProduitsViewModel>> GetProduitsAll()
        {
            string route = $"api/Produits/";
            var response = await Client.GetAsync(route);
            var resultDTO = new List<ProduitLightDTO>();
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                resultDTO = JsonConvert.DeserializeObject<List<ProduitLightDTO>>(resultat)
               ?? throw new FormatException($"Erreur Http : {route}");
            }

            var resultModel = new List<ProduitsViewModel>();

            foreach (var pdt in resultDTO)
            {
                resultModel.Add(new ProduitsViewModel(pdt));
            }
            return resultModel;
        }

        public static async Task<List<ProduitsViewModel>> SearchProduits(int? IdCat, int? IdDom, int four, string? nom, bool? Envente)
        {
            string route = $"api/Produits/Recherche?";
            //cat=0&dom=0&four=0&nom=string
            if (IdCat != 0) { route += $"&cat={IdCat}"; }
            if (IdDom != 0) { route += $"&dom={IdDom}"; }
            if (four != 0) { route += $"&four={four}"; }
            if (!string.IsNullOrEmpty(nom)) { route += $"&nom={nom}"; }
            if (Envente != null) { route += $"&Envente={Envente}"; }
            var response = await Client.GetAsync(route);
            var resultDTO = new List<ProduitLightDTO>();

            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                resultDTO = JsonConvert.DeserializeObject<List<ProduitLightDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            var resultModel = new List<ProduitsViewModel>();

            foreach (var pdt in resultDTO)
            {
                resultModel.Add(new ProduitsViewModel(pdt));
            }
            return resultModel;
        }

        public static async Task<ProduitLightDTO> GetProductById(int id)
        {
            string route = $"api/Produits/{id}";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProduitLightDTO>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new ProduitLightDTO();
        }

        internal static async Task<ClientDTO> GetClientByUserName(string userName)
        {
            string route = $"api/Client/userName/" + userName;
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ClientDTO>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new ClientDTO();
        }

        internal static async Task<List<Fournisseur>> GetFournisseurs()
        {
            string route = $"api/Fournisseurs/";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Fournisseur>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<Fournisseur>();
        }

        internal static async Task<VentesDTO> AddVente(VentesWriteDTO vente, User user)
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

        public static async Task<CommandeDTO> AddCommande(CommandeWriteDTO commande)
        {
            var venteJson = JsonConvert.SerializeObject(commande);
            string route = $"api/Commandes";

            var content = new StringContent(venteJson, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(route, content);

            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CommandeDTO>(resultat)
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
            var produitJson = JsonConvert.SerializeObject(produitWriteDTO);
            string route = $"api/Produits/{id}";

            var content = new StringContent(produitJson, Encoding.UTF8, "application/json");

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

        public static async Task<ProduitFullDTO> CreateNewProduct(ProduitWriteDTO produitWriteDTO)
        {
            var produitJson = JsonConvert.SerializeObject(produitWriteDTO);
            string route = $"api/Produits/";

            var content = new StringContent(produitJson, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(route, content);

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

        public static async Task<IEnumerable<CategorieDTO>> GetCategories()
        {
            string route = $"api/Categories/";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CategorieDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<CategorieDTO>();
        }

        public static async Task<IEnumerable<Domaine>> GetDomaines()
        {
            string route = $"api/Domaines/";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Domaine>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<Domaine>();
        }

        public static async Task<IEnumerable<TypeMouvement>> GetTypesMouvementsAll()
        {
            string route = $"api/TypeMouvements/";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TypeMouvement>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<TypeMouvement>();
        }

        public static async Task<AutreMvtDTO> AddMouvementStock(AutreMvtWriteDTO mvt)
        {
            var mvtJson = JsonConvert.SerializeObject(mvt);
            string route = $"api/AutreMouvement";

            var content = new StringContent(mvtJson, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(route, content);

            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AutreMvtDTO>(resultat)
                    ?? throw new FormatException($"Erreur lors de la désérialisation de la réponse HTTP : {route}");
            }
            else
            {
                string errorMessage = $"Erreur HTTP : {response.StatusCode} - {response.ReasonPhrase}";
                throw new HttpRequestException(errorMessage);
            }
        }

        public static async Task<TypeMouvement> AddTypeMouvement(TypeMouvement typeMouvement)
        {
            var mvtJson = JsonConvert.SerializeObject(typeMouvement);
            string route = $"api/TypeMouvements";

            var content = new StringContent(mvtJson, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(route, content);

            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TypeMouvement>(resultat)
                    ?? throw new FormatException($"Erreur lors de la désérialisation de la réponse HTTP : {route}");
            }
            else
            {
                string errorMessage = $"Erreur HTTP : {response.StatusCode} - {response.ReasonPhrase}";
                throw new HttpRequestException(errorMessage);
            }
        }

        public static async Task<IEnumerable<VentesDTO>> GetVentes()
        {
            string route = $"api/Ventes/";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<VentesDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<VentesDTO>();
        }

        public static async Task<IEnumerable<CommandeDTO>> GetCommandes()
        {
            string route = $"api/Commandes/";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CommandeDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<CommandeDTO>();
        }

        public static async Task<IEnumerable<AutreMvtDTO>> GetAutresMvt()
        {
            string route = $"api/AutreMouvement/";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<AutreMvtDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<AutreMvtDTO>();
        }

        public static async Task<List<ProduitLightDTO>> GetProductsLow()
        {
            string route = $"api/Produits/QteBasse";
            var response = await Client.GetAsync(route);
            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProduitLightDTO>>(resultat)
                ?? throw new FormatException($"Erreur Http : {route}");
            }
            return new List<ProduitLightDTO>();
        }

        internal async static Task<ClientDTO> AddClient(ClientDTO clientAjout)
        {
            var mvtJson = JsonConvert.SerializeObject(clientAjout);
            string route = $"api/Client";

            var content = new StringContent(mvtJson, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(route, content);

            if (response.IsSuccessStatusCode)
            {
                string resultat = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ClientDTO>(resultat)
                    ?? throw new FormatException($"Erreur lors de la désérialisation de la réponse HTTP : {route}");
            }
            else
            {
                string errorMessage = $"Erreur HTTP : {response.StatusCode} - {response.ReasonPhrase}";
                throw new HttpRequestException(errorMessage);
            }
        }


        //public static async Task<bool> UpdateEmploye(int id, )
        //{
        public static async Task<List<DomaineDTO>> GetDomainess()
        {
            string route = $"api/domaines";
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
            string route = $"api/Domaines/{id}";
            var response = await Client.DeleteAsync(route);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> CreateDomaine(DomaineDTO domaine)
        {
            string route = $"api/Domaines";
            var json = JsonConvert.SerializeObject(domaine);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(route, data);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> UpdateDomaine(DomaineDTO domaine)
        {
            string route = $"api/Domaines/{domaine.Id}";
            var json = JsonConvert.SerializeObject(domaine);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync(route, data);
            return response.IsSuccessStatusCode;
        }

        public static async Task<List<FournisseurDetailDTO>> GetFournisseurss()
        {
            string route = $"api/fournisseurs";
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
            string route = $"api/Fournisseurs/{id}";
            var response = await Client.DeleteAsync(route);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> CreateFournisseur(FournisseurDetailDTO fournisseur)
        {
            string route = $"api/Fournisseurs";
            var json = JsonConvert.SerializeObject(fournisseur);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(route, data);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> UpdateFournisseur(FournisseurDetailDTO fournisseur)
        {
            string route = $"api/Fournisseurs/{fournisseur.Id}";
            var json = JsonConvert.SerializeObject(fournisseur);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync(route, data);
            return response.IsSuccessStatusCode;
        }
    }
}
