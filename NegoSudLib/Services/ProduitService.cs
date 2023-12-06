using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.DTO;
using NegoSudLib.NegosudDbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.Services
{

    public class ProduitService
    {
        private readonly NegoSudDBContext _context;
        private readonly PrixVenteService prixVenteService;
        private readonly PrixAchatService prixAchatService;
        public ProduitService(NegoSudDBContext context)
        {
            _context = context;
        }


        public ProduitDTO? produitVersProduitDTO(Produit p)
        {
            if (p == null)
            {
                return null;
            }
            ProduitDTO produitDTO = new ProduitDTO
            {
                Id = p.Id,
                QteEnStock = p.QteEnStock,
                NomProduit = p.NomProduit,
                ContenanceCl = p.ContenanceCl,
                DegreeAlcool = p.DegreeAlcool,
                Millesime = p.Millesime,
                DescriptionProduit = p.DescriptionProduit,
                QteCarton = p.QteCarton,
                PhotoProduitPath = p.PhotoProduitPath,
                DomaineId = p.DomaineId,
                NomDomaine = p.Domaine.NomDomaine,
                CategorieId = p.CategorieId,
                NomCategorie = p.Categorie.NomCategorie,
                PrixVenteUnite = _context.PrixVentes
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                PrixVenteCarton = _context.PrixVentes
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                PrixAchatUnite = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                PrixAchatCarton = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                FournisseurId = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.FournisseurId)
                                        .FirstOrDefault(),
            };
            return produitDTO;
        }


        // recupérations de tout les produits
        // route: GET /produits/
        public ICollection<ProduitDTO> GetProduits()
        {
            return _context.Produits.Select(p => new ProduitDTO
            {
                Id = p.Id,
                QteEnStock = p.QteEnStock,
                NomProduit = p.NomProduit,
                ContenanceCl = p.ContenanceCl,
                DegreeAlcool = p.DegreeAlcool,
                Millesime = p.Millesime,
                DescriptionProduit = p.DescriptionProduit,
                QteCarton = p.QteCarton,
                PhotoProduitPath = p.PhotoProduitPath,
                DomaineId = p.DomaineId,
                NomDomaine = p.Domaine.NomDomaine,
                CategorieId = p.CategorieId,
                NomCategorie = p.Categorie.NomCategorie,
                PrixVenteUnite = _context.PrixVentes
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                PrixVenteCarton = _context.PrixVentes
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                PrixAchatUnite = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                PrixAchatCarton = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                FournisseurId = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.FournisseurId)
                                        .FirstOrDefault(),
            }).ToList();
        }

        // Renvoie les produits par domaine
        // route: GET produits/Domaine/{domaineId}
        public ICollection<ProduitDTO> GetProduitsByDomaine(int domaineId)
        {
            return _context.Produits
                .Where(Produit => Produit.DomaineId == domaineId)
                .Select(p => new ProduitDTO
                {
                    Id = p.Id,
                    QteEnStock = p.QteEnStock,
                    NomProduit = p.NomProduit,
                    ContenanceCl = p.ContenanceCl,
                    DegreeAlcool = p.DegreeAlcool,
                    Millesime = p.Millesime,
                    DescriptionProduit = p.DescriptionProduit,
                    QteCarton = p.QteCarton,
                    PhotoProduitPath = p.PhotoProduitPath,
                    DomaineId = p.DomaineId,
                    NomDomaine = p.Domaine.NomDomaine,
                    CategorieId = p.CategorieId,
                    NomCategorie = p.Categorie.NomCategorie,
                    PrixVenteUnite = _context.PrixVentes
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                    PrixVenteCarton = _context.PrixVentes
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                    PrixAchatUnite = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                    PrixAchatCarton = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                    FournisseurId = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.FournisseurId)
                                        .FirstOrDefault(),
                }).ToList();
        }
        // Renvoie les produits par categorie
        // route: /produits/categorie/{categorieId}
        public ICollection<ProduitDTO> GetProduitsByCategorie(int categorieId)
        {
            return _context.Produits
                .Where(Produit => Produit.CategorieId == categorieId)
                .Select(p => new ProduitDTO
                {
                    Id = p.Id,
                    QteEnStock = p.QteEnStock,
                    NomProduit = p.NomProduit,
                    ContenanceCl = p.ContenanceCl,
                    DegreeAlcool = p.DegreeAlcool,
                    Millesime = p.Millesime,
                    DescriptionProduit = p.DescriptionProduit,
                    QteCarton = p.QteCarton,
                    PhotoProduitPath = p.PhotoProduitPath,
                    DomaineId = p.DomaineId,
                    NomDomaine = p.Domaine.NomDomaine,
                    CategorieId = p.CategorieId,
                    NomCategorie = p.Categorie.NomCategorie,
                    PrixVenteUnite = _context.PrixVentes
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                    PrixVenteCarton = _context.PrixVentes
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                    PrixAchatUnite = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                    PrixAchatCarton = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.PrixUnite)
                                        .FirstOrDefault(),
                    FournisseurId = _context.PrixAchats
                                        .Where(prix => (prix.ProduitId == p.Id && prix.DateFin == null))
                                        .Select(prix => prix.FournisseurId)
                                        .FirstOrDefault(),
                }).ToList();
        }


        // Ajout d'un produit et des prix achat et vente
        // route POST produit/
        public void AddProduit(ProduitDTO produit)
        {
            Produit produitEntity = new Produit
            {
                QteEnStock = produit.QteEnStock,
                NomProduit = produit.NomProduit,
                ContenanceCl = produit.ContenanceCl,
                DegreeAlcool = produit.DegreeAlcool,
                Millesime = produit.Millesime,
                DescriptionProduit = produit.DescriptionProduit,
                QteCarton = produit.QteCarton,
                PhotoProduitPath = produit.PhotoProduitPath,
                DomaineId = produit.DomaineId,
                CategorieId = produit.CategorieId,
            };

            _context.Produits.Add(produitEntity);
            _context.SaveChanges();

            // récuperation de l'id du produit crée
            int produitId = produitEntity.Id;

            // Ajout du prix de vente
            PrixVenteDTO prixVente = new PrixVenteDTO
            {
                DateDebut = DateTime.Now,
                DateFin = null,
                PrixCarton = produit.PrixVenteCarton,
                PrixUnite = produit.PrixVenteUnite,
                ProduitId = produitId,
                Taxe = produit.Taxe
            };
            prixVenteService.addPrixVente(prixVente);


            // Ajout du prix d'achat
            PrixAchatDTO prixAchat = new PrixAchatDTO
            {
                DateDebut = DateTime.Now,
                DateFin = null,
                PrixCarton = produit.PrixAchatCarton,
                PrixUnite = produit.PrixAchatUnite,
                ProduitId = produitId,
                FournisseurId = produit.FournisseurId
            };
            prixAchatService.addPrixAchat(prixAchat);

        }



        // Modifier un produit
        // route: POST produit/{produitId}
        public void updateProduit(ProduitDTO produit)
        {
            Produit? produitAModifier = _context.Produits.Find(produit.Id);
            if (produitAModifier == null)
            {
                // on gère le cas où l'entité n'est pas trouvée
                throw new ArgumentException("Produit non trouvé");
            }
            ProduitDTO produitAModifierDTO = produitVersProduitDTO(produitAModifier);


            produitAModifier.QteEnStock = produit.QteEnStock;
            produitAModifier.NomProduit = produit.NomProduit;
            produitAModifier.ContenanceCl = produit.ContenanceCl;
            produitAModifier.DegreeAlcool = produit.DegreeAlcool;
            produitAModifier.Millesime = produit.Millesime;
            produitAModifier.DescriptionProduit = produit.DescriptionProduit;
            produitAModifier.QteCarton = produit.QteCarton;
            produitAModifier.PhotoProduitPath = produit.PhotoProduitPath;
            produitAModifier.DomaineId = produit.DomaineId;
            produitAModifier.CategorieId = produit.CategorieId;
            _context.SaveChanges();

            // Ajout du nouveaux prix de vente si modifié
            if (produitAModifierDTO.PrixVenteCarton != produit.PrixVenteCarton || produitAModifierDTO.PrixVenteUnite != produit.PrixVenteUnite)
            {
                PrixVenteDTO prixVente = new PrixVenteDTO
                {
                    DateDebut = DateTime.Now,
                    DateFin = null,
                    PrixCarton = produit.PrixVenteCarton,
                    PrixUnite = produit.PrixVenteUnite,
                    ProduitId = produit.Id,
                    Taxe = produit.Taxe
                };
                prixVenteService.addPrixVente(prixVente);
            }

            // Ajout du prix d'achat si modifié
            if (produitAModifierDTO.PrixAchatCarton != produit.PrixAchatCarton || produitAModifierDTO.PrixAchatUnite != produit.PrixAchatUnite)
            {

                PrixAchatDTO prixAchat = new PrixAchatDTO
                {
                    DateDebut = DateTime.Now,
                    DateFin = null,
                    PrixCarton = produit.PrixAchatCarton,
                    PrixUnite = produit.PrixAchatUnite,
                    ProduitId = produit.Id,
                    FournisseurId = produit.FournisseurId
                };
                prixAchatService.addPrixAchat(prixAchat);

            }

        }

    }

}
