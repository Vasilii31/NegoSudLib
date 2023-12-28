using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NegoSudLib.DAO;
using NegoSudLib.NegosudDbContext;

namespace ConsoleApp1
{
    public static class SeedService
    {
        public static void SeedDatabase()
        {
            using (var context = new NegoSudDBContext())
            {
                if (context.Categories.Any()) { return; }
                context.Categories.Add(new Categorie { Id = 1, NomCategorie = "Rouge" });
                context.Categories.Add(new Categorie { Id = 2, NomCategorie = "Blanc" });
                context.Categories.Add(new Categorie { Id = 3, NomCategorie = "Rosé" });
                context.Categories.Add(new Categorie { Id = 4, NomCategorie = "Pétillant" });
                context.Categories.Add(new Categorie { Id = 5, NomCategorie = "Champagne" });
                context.Categories.Add(new Categorie { Id = 6, NomCategorie = "Digestifs" });

                if (context.Domaines.Any()) { return; }
                context.Domaines.Add(new Domaine{ Id = 1, NomDomaine = "Domaine des Roches Neuves" });
                context.Domaines.Add(new Domaine{ Id = 2, NomDomaine = "Domaine du Pélican" });
                context.Domaines.Add(new Domaine{ Id = 3, NomDomaine = "Domaine Fondrèche" });
                context.Domaines.Add(new Domaine{ Id = 4, NomDomaine = "Domaine d'Uby" });
                context.Domaines.Add(new Domaine{ Id = 5, NomDomaine = "Philippe Cordonnier" });
                context.Domaines.Add(new Domaine{ Id = 6, NomDomaine = "Domaine Parigot Père et Fils" });
                context.Domaines.Add(new Domaine{ Id = 7, NomDomaine = "Domaine de Santa Duc" });
                context.Domaines.Add(new Domaine{ Id = 8, NomDomaine = "Bollinger" });
                context.Domaines.Add(new Domaine{ Id = 9, NomDomaine = "Champagne Pierre Gimonnet et Fils" });
                context.Domaines.Add(new Domaine{ Id = 10, NomDomaine = "Château Bertrand Braneyre" });
                context.Domaines.Add(new Domaine{ Id = 11, NomDomaine = "Dominique Lafon" });
                context.Domaines.Add(new Domaine{ Id = 12, NomDomaine = "Château Esclans" });
                context.Domaines.Add(new Domaine{ Id = 13, NomDomaine = "Château Rieussec" });
                context.Domaines.Add(new Domaine{ Id = 14, NomDomaine = "Château Belgrave" });
                context.Domaines.Add(new Domaine{ Id = 15, NomDomaine = "Domaine la Rêverie" });
                context.Domaines.Add(new Domaine{ Id = 16, NomDomaine = "Moët et Chandon" });
                

                if (context.Produits.Any()) { return; }
                context.Produits.Add(new Produit { 
                    Id = 1, NomProduit = "Gros et Petit Manseng", QteEnStock = 0, 
                    AlaVente = true,
                    DescriptionProduit= "Domaine D'Uby Tortues Gros Et Petit Manseng Blanc 2021",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12, 
                    PhotoProduitPath="",
                    DomaineId = 4,
                    CategorieId = 2,
                    ContenanceCl=75,
                    DegreeAlcool = 11f,
                    Millesime =2021});
                context.Produits.Add(new Produit
                {
                    Id = 2,
                    NomProduit = "Colombard Sauvignon Blanc",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Domaine D'Uby Tortues Colombard Sauvignon Blanc 2020",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 4,
                    CategorieId = 2,
                    ContenanceCl = 75,
                    DegreeAlcool = 11f,
                    Millesime = 2020});
                context.Produits.Add(new Produit
                {
                    Id = 3,
                    NomProduit = "Saumur L'Insolite Blanc 2019",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Domaine Des Roches Neuves Saumur L'Insolite Blanc 2019",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 1,
                    CategorieId = 2,
                    ContenanceCl = 75,
                    DegreeAlcool = 13.5f,
                    Millesime = 2019
                });
                context.Produits.Add(new Produit
                {
                    Id = 4,
                    NomProduit = "Saumur Champigny Terres Chaudes",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Domaine Des Roches Neuves Saumur Champigny Terres Chaudes Rouge 2018",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 1,
                    CategorieId = 1,
                    ContenanceCl = 75,
                    DegreeAlcool = 13.5f,
                    Millesime = 2018
                });
                context.Produits.Add(new Produit
                {
                    Id = 5,
                    NomProduit = "La Marginale",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Domaine Des Roches Neuves La Marginale Rouge 2018",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 1,
                    CategorieId = 1,
                    ContenanceCl = 75,
                    DegreeAlcool = 13.5f,
                    Millesime = 2018
                });
                context.Produits.Add(new Produit
                {
                    Id = 6,
                    NomProduit = "Les Memoires",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Domaine Des Roches Neuves Les Memoires Rouge 2018",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 1,
                    CategorieId = 1,
                    ContenanceCl = 75,
                    DegreeAlcool = 13.5f,
                    Millesime = 2018
                });
                context.Produits.Add(new Produit
                {
                    Id = 7,
                    NomProduit = "L'Echelier",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Domaine Des Roches Neuves L'Echelier Blanc 2019",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 1,
                    CategorieId = 2,
                    ContenanceCl = 75,
                    DegreeAlcool = 13.5f,
                    Millesime = 2019
                });
                context.Produits.Add(new Produit
                {
                    Id = 8,
                    NomProduit = "Sauternes Chateau Rieussec",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Château Rieussec Château Rieussec Blanc 2011",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 13,
                    CategorieId = 2,
                    ContenanceCl = 75,
                    DegreeAlcool = 14f,
                    Millesime = 2011
                });
                context.Produits.Add(new Produit
                {
                    Id = 9,
                    NomProduit = "Le Serre du Rieu",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Domaine De Santa Duc Le Serre Du Rieu Blanc 2020",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 7,
                    CategorieId = 2,
                    ContenanceCl = 75,
                    DegreeAlcool = 13f,
                    Millesime = 2020
                });
                context.Produits.Add(new Produit
                {
                    Id = 10,
                    NomProduit = "Les Quatres Terres",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Domaine De Santa Duc Les Quatre Terres Rouge 2019",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 7,
                    CategorieId = 1,
                    ContenanceCl = 75,
                    DegreeAlcool = 14.5f,
                    Millesime = 2019
                });
                context.Produits.Add(new Produit
                {
                    Id = 11,
                    NomProduit = "Les Hautes Garrigues",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Domaine De Santa Duc Les Hautes Garrigues Rouge 2019",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 7,
                    CategorieId = 1,
                    ContenanceCl = 75,
                    DegreeAlcool = 14.5f,
                    Millesime = 2019
                });
                context.Produits.Add(new Produit
                {
                    Id = 12,
                    NomProduit = "Les Grands Calcaires",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Domaine De Santa Duc Les Grands Calcaires Blanc 2019",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 7,
                    CategorieId = 2,
                    ContenanceCl = 75,
                    DegreeAlcool = 13f,
                    Millesime = 2019
                });
                context.Produits.Add(new Produit
                {
                    Id = 13,
                    NomProduit = "Grand Vintage Rosé",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Un Grand Vintage naît de l’interprétation libre du Chef de Cave, à partir d’une sélection des vins les plus remarquables produits au cours d’une année unique. L’année 1842 est celle de la création des champagnes Grand Vintage, par Moët & Chandon, élaborés pour le plaisir des connaisseurs anglais et américains à la recherche de vins plus matures. Depuis, chaque millésime reflète la vision personnelle du Chef de Cave, ainsi que son respect pour l’individualité de chaque millésime, à chaque année donnée.",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 16,
                    CategorieId = 5,
                    ContenanceCl = 150,
                    DegreeAlcool = 12.5f,
                    Millesime = 2008
                });
                context.Produits.Add(new Produit
                {
                    Id = 14,
                    NomProduit = "Réserve Impérial étui",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Réserve Impériale apparaît dans la gamme Moët & Chandon en 1996. Réserve Impériale est une expression florissante et vineuse du style Moët & Chandon, un style qui se distingue par son fruité vif, son palais séduisant et sa maturité élégante.",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 16,
                    CategorieId = 5,
                    ContenanceCl = 75,
                    DegreeAlcool = 12f
                });
                context.Produits.Add(new Produit
                {
                    Id = 15,
                    NomProduit = "Rock Angel Mathusalem",
                    QteEnStock = 0,
                    AlaVente = true,
                    DescriptionProduit = "Un rosé qui incarne à la fois un superbe vin d’apéritif rosé et un vin fin accompagnant brillamment un large éventail de mets raffinés. Les raisins, principalement Grenache, Rolle (Vermentino) et Syrah proviennent des plus belles terres de Provence.",
                    SeuilCommandeMin = 10,
                    CommandeMin = 10,
                    QteCarton = 12,
                    PhotoProduitPath = "",
                    DomaineId = 12,
                    CategorieId = 3,
                    ContenanceCl = 600,
                    DegreeAlcool = 13.5f
                });

                context.Fournisseurs.Add(new Fournisseur
                {
                    Id = 1,
                    NomFournisseur = "Cave du Jurançon"
                });

                context.PrixAchats.Add(new PrixAchat
                {
                    DateDebut = DateTime.Now,
                    DateFin = null,
                    ProduitId = 1,
                    PrixCarton = 12,
                    PrixUnite = 3,
                    FournisseurId = 1
                });

                context.PrixVentes.Add(new PrixVente
                {
                    DateDebut = DateTime.Now,
                    DateFin = null,
                    ProduitId = 1,
                    PrixCarton = 50,
                    PrixUnite = 7,
                    Taxe = 20
                });

                context.Employes.Add(new Employe
                {
                    Id=1,
                    NomUtilisateur = "Blanc",
                    PrenomUtilisateur = "Christopher",
                    Gerant = false,
                    MailUtilisateur = "test@test.fr",
                    AdresseUtilisateur = "12 rue du test",
                }) ;

                context.TypesMouvement.Add(new TypeMouvement
                {
                    Id = 1,
                    NomTypeMouvement = "Vente"
                });

                context.TypesMouvement.Add(new TypeMouvement
                {
                    Id = 2,
                    NomTypeMouvement = "Commande"
                });

                context.Clients.Add(new Client
                {
                    Id=1,
                    NomUtilisateur = "Dupont",
                    PrenomUtilisateur = "José",
                    NumClient = "12F3",
                    MailUtilisateur = "test@test.fr",
                    AdresseUtilisateur = "12 rue du test",
                    NumTelUtilisateur = "010101010"
                });
                context.SaveChanges();

                context.Ventes.Add(new Vente
                {
                    ClientId = 1,
                    QteMouvement = 1,
                    EntreeOuSortie = true,
                    Commentaire = "test",
                    NumFacture = "123",
                    DateMouvement = DateTime.Now,
                    EmployeId = 1,
                    TypeMouvementId = 1
                });
                context.SaveChanges();

                context.DetailsMouvementStock.Add(new DetailMouvementStock
                {
                    Id = 1,
                    QteProduit = 1,
                    AuCarton = true,
                    PrixApresRistourne = 12,
                    MouvementStockId = 1,
                    ProduitId = 1
                });

                context.SaveChanges();
            }
        }
    }
}
