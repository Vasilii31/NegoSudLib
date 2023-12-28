using System;
// Fourniseur avec tous les détails

namespace NegoSudLib.DTO;

public class FournisseurDetailDTO
{
    public int Id { get; set; }

    public string NomFournisseur { get; set; } = string.Empty;

    public string AdresseFournisseur { get; set; } = string.Empty;

    public string NumTelFournisseur { get; set; } = string.Empty;

    public string EmailFournisseur { get; set; } = string.Empty;

    public virtual ICollection<ProduitReadDTO>? Produits { get; set; } 

    public virtual ICollection<CommandeDTO>? Commandes { get; set; }

}
