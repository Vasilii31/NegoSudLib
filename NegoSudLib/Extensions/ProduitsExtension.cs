using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;

namespace NegoSudLib.Extensions
{
    public static class ProduitsExtension
    {

        public static ProduitLightDTO? ToLightDTO(this Produit prod, DateTime? date = null)
        {
            PrixAchat? prixAchat = null;
            PrixVente? prixVente = null;
            if (prod == null) return null;
            if (date.HasValue)
            {
                if (prod.PrixAchats != null)
                {
                    prixAchat = prod.PrixAchats.FirstOrDefault(
                          prixA => prixA.DateDebut <= date &&
                                   (prixA.DateFin == null || prixA.DateFin >= date)
                      );

                }
                if (prod.PrixVentes != null)
                {
                    prixVente = prod.PrixVentes.FirstOrDefault(
                          prixV => prixV.DateDebut <= date &&
                                   (prixV.DateFin == null || prixV.DateFin >= date)
                      );
                }
                /*else
                {
                    if (prod.PrixAchats != null)
                    {
                        prixAchat = prod.PrixAchats.FirstOrDefault();

                    }
                    if (prod.PrixVentes != null)
                    {
                        prixVente = prod.PrixVentes.FirstOrDefault();
                    }
                }*/

                return new ProduitLightDTO
                {
                    Id = prod.Id,
                    NomProduit = prod.NomProduit,
                    ContenanceCl = prod.ContenanceCl,
                    QteEnStock = prod.QteEnStock,
                    CommandeMin = prod.CommandeMin,
                    SeuilCommandeMin = prod.SeuilCommandeMin,
                    QteCarton = prod.QteCarton,
                    DegreeAlcool = prod.DegreeAlcool,
                    Millesime = prod.Millesime,
                    PhotoProduitPath = prod.PhotoProduitPath,
                    ALaVente = prod.AlaVente,
                    Fournisseur = prixAchat != null ? prixAchat.Fournisseur != null ? prixAchat.Fournisseur.NomFournisseur : "" : "",
                    NomDomaine = prod.Domaine?.NomDomaine ?? string.Empty,
                    NomCategorie = prod.Categorie?.NomCategorie ?? string.Empty,
                    IdCategorie = prod.Categorie?.Id ?? 0,
                    PrixVente = (prixVente == null) ? 0 : prixVente.PrixUnite,
                    PrixVenteCarton = (prixVente == null) ? 0 : prixVente.PrixCarton,
                    PrixAchat = prixAchat != null ? prixAchat.PrixUnite : 0,
                    PrixAchatCarton = (prixAchat == null) ? 0 : prixAchat.PrixCarton

                };

            }
            else
            {
                return new ProduitLightDTO
                {
                    Id = prod.Id,
                    NomProduit = prod.NomProduit,
                    ContenanceCl = prod.ContenanceCl,
                    QteEnStock = prod.QteEnStock,
                    CommandeMin = prod.CommandeMin,
                    SeuilCommandeMin = prod.SeuilCommandeMin,
                    QteCarton = prod.QteCarton,
                    DegreeAlcool = prod.DegreeAlcool,
                    Millesime = prod.Millesime,
                    PhotoProduitPath = prod.PhotoProduitPath,
                    NomDomaine = prod.Domaine?.NomDomaine ?? string.Empty,
                    NomCategorie = prod.Categorie?.NomCategorie ?? string.Empty,
                    IdCategorie = prod.Categorie?.Id ?? 0,
                    PrixVente = prod.PrixVentes.Any() ? prod.PrixVentes.First().PrixUnite : 0,
                    PrixVenteCarton = prod.PrixVentes.Any() ? prod.PrixVentes.First().PrixCarton : 0,
                    PrixAchat = prod.PrixAchats.Any() ? prod.PrixAchats.First().PrixUnite : 0,
                    PrixAchatCarton = prod.PrixAchats.Any() ? prod.PrixAchats.First().PrixCarton : 0

                };
            }
        }
        public static ProduitFullDTO ToFullDTO(this Produit prod)
        {
            var test = prod;
            return new ProduitFullDTO
            {
                Id = prod.Id,
                NomProduit = prod.NomProduit,
                ContenanceCl = prod.ContenanceCl,
                QteEnStock = prod.QteEnStock,
                CommandeMin = prod.CommandeMin,
                SeuilCommandeMin = prod.SeuilCommandeMin,
                QteCarton = prod.QteCarton,
                DegreeAlcool = prod.DegreeAlcool,
                Millesime = prod.Millesime,
                PhotoProduitPath = prod.PhotoProduitPath,
                NomDomaine = prod.Domaine?.NomDomaine ?? string.Empty,
                NomCategorie = prod.Categorie?.NomCategorie ?? string.Empty,
                HistoriquePrixVentes = prod.PrixVentes != null ? prod.PrixVentes : [],
                HistoriquePrixAchats = prod.PrixAchats != null ? prod.PrixAchats : [],

            };
        }


    }
}
