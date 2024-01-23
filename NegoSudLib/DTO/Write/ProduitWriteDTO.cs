using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using NegoSudLib.NegosudDbContext;
using System;
using System.ComponentModel.DataAnnotations;
namespace NegoSudLib.DTO.Write;

// Produit pour l'écriture dans la BDD
public class ProduitWriteDTO

{
    [Required]
    public string NomProduit { get; set; } = string.Empty;

    [Required]
    public int ContenanceCl { get; set; }
    public int QteEnStock { get; set; }

    [Required]
    public float DegreeAlcool { get; set; }
    public int Millesime { get; set; }
    public int QteCarton { get; set; }

    [Required]
    public string PhotoProduitPath { get; set; } = string.Empty;

    [Required]
    public string DescriptionProduit { get; set; } = string.Empty;

    [Required]
    public int SeuilCommandeMin { get; set; }

    [Required]
    public int CommandeMin { get; set; }

    public int IdDomaine { get; set; }

    [Required]
    public int IdCategorie { get; set; }
    public bool AlaVente { get; set; }
    public PrixAchat? PrixAchat { get; set; }
    public PrixVente? PrixVente { get; set; }
}
