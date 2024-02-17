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
            }
            else
            {
                if (prod.PrixAchats != null)
                {
                    prixAchat = prod.PrixAchats.FirstOrDefault();

                }
                if (prod.PrixVentes != null)
                {
                    prixVente = prod.PrixVentes.FirstOrDefault();
                }
            }

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
                Fournisseur = prixAchat.Fournisseur != null ? prixAchat.Fournisseur.NomFournisseur : "",
                IdFournisseur = prixAchat != null ? prixAchat.FournisseurId : 0,
                IdDomaine = prod.Domaine.Id,
                NomDomaine = prod.Domaine?.NomDomaine ?? string.Empty,
                IdCategorie = prod.Categorie.Id,
                NomCategorie = prod.Categorie?.NomCategorie ?? string.Empty,
                PrixVente = (prixVente == null) ? 0 : prixVente.PrixUnite,
                PrixVenteCarton = (prixVente == null) ? 0 : prixVente.PrixCarton,
                PrixAchat = prixAchat != null ? prixAchat.PrixUnite : 0,
                PrixAchatCarton = (prixAchat == null) ? 0 : prixAchat.PrixCarton

            };

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
        public static ProduitFullDTO ToWriteDTO(this Produit prod)
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
