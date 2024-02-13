﻿using NegoSudLib.DAO;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace NegoSudLib.DTO.write
    ;

public class CommandeWriteDTO
{
    [Required]
    public DateTime DateMouvement { get; set; }
    public string Commentaire { get; set; } = string.Empty;
    [Required]
    public int EmployeId { get; set; }
    [Required]
    public int FournisseurId { get; set; }
    [Required]
    public Statuts StatutCommande { get; set; }
    public List<DetailMouvementStock>? DetailMouvementStocks { get; set; }

}
