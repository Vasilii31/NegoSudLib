﻿namespace NegoSudLib.DTO.Read;

// DTO pour l'affichage simple des produits pour les listes
public class ProduitLightDTO
{
    public int Id { get; set; }
    public string NomProduit { get; set; } = string.Empty;
    public int ContenanceCl { get; set; }
    public int QteEnStock { get; set; }
    public int CommandeMin { get; set; }
    public int SeuilCommandeMin { get; set; }
    public float DegreeAlcool { get; set; }
    public int Millesime { get; set; }
    public int QteCarton { get; set; }
    public string PhotoProduitPath { get; set; } = string.Empty;
    public string DescriptionProduit { get; set; } = string.Empty;
    public int IdDomaine { get; set; }
    public string NomDomaine { get; set; } = string.Empty;
    public int IdCategorie { get; set; }
    public string NomCategorie { get; set; } = string.Empty;
    public bool ALaVente { get; set; }
    public int IdFournisseur { get; set; }
    public string Fournisseur { get; set; } = string.Empty;
    public float PrixVente { get; set; }
    public float PrixVenteCarton { get; set; }
    public float PrixAchat { get; set; }
    public float PrixAchatCarton { get; set; }

}
