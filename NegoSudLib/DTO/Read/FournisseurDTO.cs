using System;
// Classe qui contient seulement les informations de base d'un fournisseur (pour faire un liste des fournisseur par exemple)
namespace NegoSudLib.DTO.Read;
public class FournisseurDTO()
{ 
    public int Id { get; set; }
    public string NomFournisseur { get; set; } = string.Empty;
}

