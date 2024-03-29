﻿using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using NegoSudLib.Interfaces;

namespace NegoSudLib.Services
{

    public class ProduitService : IProduitsServices
    {
        private readonly IProduitsRepository _produitRepository;
        private readonly IPrixRepository _prixRepository;
        private readonly IPrixService _prixService;
        public ProduitService(IProduitsRepository produitRepository, IPrixRepository prixRepository, IPrixService prixService)
        {
            this._produitRepository = produitRepository;
            this._prixRepository = prixRepository;
            this._prixService = prixService;
        }

        // recupérations de tout les produits
        // route: GET /produits/
        public async Task<IEnumerable<ProduitLightDTO>> GetAll(bool? AlaVente)
        {
            return await this._produitRepository.GetAll(AlaVente);
        }

        // Renvoie les produits par categorie
        // route: GET produits/Categorie/{CatId}
        public async Task<IEnumerable<ProduitLightDTO>> GetByCat(int catId)
        {
            return await this._produitRepository.GetByCat(catId);
        }
        public async Task<IEnumerable<ProduitLightDTO>> Search(int cat, int dom, int four, string? name, bool? enVente)
        {
            return await this._produitRepository.Search(cat, dom, four, name, enVente);
        }

        // Renvoie les produits par domaine
        // route: GET produits/Domaine/{domId}
        public async Task<IEnumerable<ProduitLightDTO>> GetByDom(int domId)
        {
            return await this._produitRepository.GetByDom(domId);
        }


        // renvoi le produit par Id
        public async Task<ProduitLightDTO?> GetById(int id)
        {
            return await this._produitRepository.GetById(id);
        }

        public async Task<ProduitLightDTO?> GetByIdDate(int id, DateTime date)
        {
            return await this._produitRepository.GetByIdDate(id, date);
        }


        // Ajout d'un produit et des prix achat et vente
        // route POST produit/
        public async Task<ProduitFullDTO?> Post(ProduitWriteDTO produit)
        {
            //Ajout du produit
            ProduitFullDTO? prodFullDTO = await _produitRepository.Post(produit);
            if (prodFullDTO == null)
            {
                return null;
            }
            //Ajout des prix 
            if (produit.PrixAchat != null)
            {
                produit.PrixAchat.ProduitId = prodFullDTO.Id;
                var prixAchatAdded = await _prixService.PostPrixAchat(produit.PrixAchat);
                if (prixAchatAdded != null) prodFullDTO.HistoriquePrixAchats = [prixAchatAdded];

            }
            if (produit.PrixVente != null)
            {
                produit.PrixVente.ProduitId = prodFullDTO.Id;
                var prixVenteAdded = await _prixService.PostPrixVente(produit.PrixVente);
                if (prixVenteAdded != null) prodFullDTO.HistoriquePrixVentes = [prixVenteAdded];
            }
            return prodFullDTO;
        }

        // Supprimer un produit
        // route: DELETE produit/{produitId}
        public async Task Delete(int id)
        {
            await _produitRepository.Delete(id);
        }


        //Modifier un produit
        //route: PUT produit/{produitId
        public async Task<ProduitFullDTO?> Put(int id, ProduitWriteDTO ProdNew)
        {
            var prod = await _produitRepository.Put(id, ProdNew);
            if (prod == null) return null;

            //Ajout des prix 
            if (ProdNew.PrixAchat != null)
            {
                var prixAchatNew = await _prixService.PostPrixAchat(ProdNew.PrixAchat);
                if (prixAchatNew != null) prod.HistoriquePrixAchats.Add(prixAchatNew);
            }

            if (ProdNew.PrixVente != null)
            {
                var prixVenteNew = await _prixService.PostPrixVente(ProdNew.PrixVente);
                if (prixVenteNew != null) prod.HistoriquePrixVentes.Add(prixVenteNew);
            }
            return prod;

        }

        public async Task<bool> Exists(int id)
        {
            return await _produitRepository.Exists(id);
        }

        public async Task<IEnumerable<ProduitLightDTO>> GetAllProductsLow()
        {
            return await this._produitRepository.GetAllProductsLow();
        }
    }
}

