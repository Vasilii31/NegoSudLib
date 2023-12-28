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
        private readonly PrixAchatService _prixAchatService;
        private readonly PrixVenteService _prixVenteService;

        public ProduitService(NegoSudDBContext context)
        {
            _context = context;
            _prixAchatService = new PrixAchatService(context);
            _prixVenteService = new PrixVenteService(context);
        }

        // recupérations de tout les produits
        // route: GET /produits/
        public ICollection<ProduitReadDTO> getProduits()
        {
            ICollection<ProduitReadDTO> produits = _context.Produits.Select(p => new ProduitReadDTO
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
                Domaine = p.Domaine,
                Categorie = p.Categorie,
            }).ToList();

            if (produits.Count > 0)
            {
                foreach (var produit in produits)
                {
                    if (produit != null)
                    {
                        produit.PrixVente = _prixVenteService.getPrixventeActuel(produit.Id);
                        produit.PrixAchat = _prixAchatService.getPrixAchatActuel(produit.Id);
                    }
                }
            }
            return produits;
        }

        // Renvoie les produits par domaine
        // route: GET produits/Domaine/{domaineId}
        public ICollection<ProduitReadDTO> GetProduitsByDomaine(int domaineId)
        {
            ICollection<ProduitReadDTO> produits = _context.Produits
                .Where(Produit => Produit.DomaineId == domaineId)
                .Select(p => new ProduitReadDTO
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
                    Domaine = p.Domaine,
                    Categorie = p.Categorie
                }).ToList();

            if (produits.Count > 0)
            {
                foreach (var produit in produits)
                {
                    if (produit != null)
                    {
                        produit.PrixVente = _prixVenteService.getPrixventeActuel(produit.Id);
                        produit.PrixAchat = _prixAchatService.getPrixAchatActuel(produit.Id);
                    }
                }
            }
            return produits;
        }
        // Renvoie les produits par categorie
        // route: /produits/categorie/{categorieId}
        public ICollection<ProduitReadDTO> GetProduitsByCategorie(int categorieId)
        {
            ICollection<ProduitReadDTO> produits = _context.Produits
                .Where(Produit => Produit.CategorieId == categorieId)
                .Select(p => new ProduitReadDTO
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
                    Domaine = p.Domaine,
                    Categorie = p.Categorie
                }).ToList();

            if (produits.Count > 0)
            {
                foreach (var produit in produits)
                {
                    if (produit != null)
                    {
                        produit.PrixVente = _prixVenteService.getPrixventeActuel(produit.Id);
                        produit.PrixAchat = _prixAchatService.getPrixAchatActuel(produit.Id);
                    }
                }
            }
            return produits;
        }


        public ProduitReadDTO? getProduitById(int produitId)
        {
            Produit? p = _context.Produits.Find(produitId);
            if (p == null)
            {
                return null;
            }
            ProduitReadDTO prod = produitToProduitReadDTO(p);
            return prod;
        }

        public ProduitReadDTO? GetProduitByIdDate(int produitId, DateTime date) {         
            ProduitReadDTO? produitDTO = _context.Produits
                .Where(prod => prod.Id  == produitId)
                .Select(p => new ProduitReadDTO
                {
                    Id = p.Id,
                    NomProduit = p.NomProduit,
                    PhotoProduitPath = p.PhotoProduitPath,
                    DescriptionProduit = p.DescriptionProduit,
                    ContenanceCl = p.ContenanceCl,
                    DegreeAlcool = p.DegreeAlcool,
                    QteEnStock = p.QteEnStock,
                    Millesime = p.Millesime,
                    QteCarton = p.QteCarton,
                    Domaine = p.Domaine,
                    Categorie = p.Categorie
                }).FirstOrDefault();
                
            if (produitDTO.Id != 0)
            {
                produitDTO.PrixVente = _prixVenteService.getPrixVenteByDate(produitId, date);
                produitDTO.PrixAchat = _prixAchatService.getPrixAchatByDate(produitId, date);

                return produitDTO;
            }
            else
            {
                return null;
            }

        }

        // Transforme un produit en ProduitReadDTO
        public ProduitReadDTO produitToProduitReadDTO(Produit p)
        {

            ProduitReadDTO prod = new ProduitReadDTO
            {
                Id = p.Id,
                NomProduit = p.NomProduit,
                PhotoProduitPath = p.PhotoProduitPath,
                DescriptionProduit = p.DescriptionProduit,
                ContenanceCl = p.ContenanceCl,
                DegreeAlcool = p.DegreeAlcool,
                QteEnStock = p.QteEnStock,
                Millesime = p.Millesime,
                QteCarton = p.QteCarton,
                Domaine = p.Domaine,
                Categorie = p.Categorie
            };
            prod.PrixVente = _prixVenteService.getPrixventeActuel(prod.Id);
            prod.PrixAchat = _prixAchatService.getPrixAchatActuel(prod.Id);
            return prod;
        }
        // Ajout d'un produit et des prix achat et vente
        // route POST produit/
        public int AddProduit(ProduitWriteDTO produit)
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
            if (_context.SaveChanges() != 1)
            {
                return 0;
            };

            // récuperation de l'id du produit crée
            int produitId = produitEntity.Id;

            // Ajout du prix de vente
            produit.PrixVenteActuel.ProduitId = produitId;
            if (produit.PrixVenteActuel != null)
            {
                _prixVenteService.addPrixVente(produit.PrixVenteActuel);
            }


            // Ajout du prix d'achat
            produit.PrixAchatActuel.ProduitId = produitId;
            if (produit.PrixAchatActuel != null)
            {
                _prixAchatService.addPrixAchat(produit.PrixAchatActuel);
            }
            _context.SaveChanges();


            return produitId;
        }

        // Modifier un produit
        // route: DELETE produit/{produitId}
        public bool DeleteProduit(int id)
        {
            Produit? prod = _context.Produits.Find(id);
            if (prod != null)
            {
                _context.Produits.Remove(prod);
                if (_context.SaveChanges() == 1)
                {
                    return true;
                };
            }
            return false;
        }


        //Modifier un produit
        //route: PUT produit/{produitId
        public bool UpdateProduit(ProduitWriteDTO ProduitNew)
        {
            Produit? produitOld = _context.Produits.Find(ProduitNew.Id);
            if (produitOld == null)
            {
                // on gère le cas où l'entité n'est pas trouvée
                return false;
            }

            // modif de la table Produit
            produitOld.QteEnStock = ProduitNew.QteEnStock;
            produitOld.NomProduit = ProduitNew.NomProduit;
            produitOld.ContenanceCl = ProduitNew.ContenanceCl;
            produitOld.DegreeAlcool = ProduitNew.DegreeAlcool;
            produitOld.Millesime = ProduitNew.Millesime;
            produitOld.DescriptionProduit = ProduitNew.DescriptionProduit;
            produitOld.QteCarton = ProduitNew.QteCarton;
            produitOld.PhotoProduitPath = ProduitNew.PhotoProduitPath;
            produitOld.DomaineId = ProduitNew.DomaineId;
            produitOld.CategorieId = ProduitNew.CategorieId;
            _context.SaveChanges();

            ProduitReadDTO produitOldDTO = produitToProduitReadDTO(produitOld);

            // Ajout du nouveaux prix de vente si modifié
            if (ProduitNew.PrixVenteActuel != null && produitOldDTO.PrixVente != null)
            {
                if (produitOldDTO.PrixVente.PrixCarton != ProduitNew.PrixVenteActuel.PrixCarton ||
                    produitOldDTO.PrixVente.PrixUnite != ProduitNew.PrixVenteActuel.PrixUnite ||
                    produitOldDTO.PrixVente.Promotion != ProduitNew.PrixVenteActuel.Promotion ||
                    produitOldDTO.PrixVente.Taxe != ProduitNew.PrixVenteActuel.Taxe
                    )
                {
                    _prixVenteService.addPrixVente(ProduitNew.PrixVenteActuel);
                }
            }

            // Ajout du prix d'achat si modifié
            if (ProduitNew.PrixAchatActuel != null && produitOldDTO.PrixAchat != null)
            {
                if (produitOldDTO.PrixAchat.PrixCarton != ProduitNew.PrixAchatActuel.PrixCarton ||
                produitOldDTO.PrixAchat.PrixUnite != ProduitNew.PrixAchatActuel.PrixUnite ||
                produitOldDTO.PrixAchat.Fournisseur.Id != ProduitNew.PrixAchatActuel.FournisseurId
                )
                {
                    _prixAchatService.addPrixAchat(ProduitNew.PrixAchatActuel);
                }

            }

            return true;

        }
    }
}
