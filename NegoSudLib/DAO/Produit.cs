using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.DAO
{
    public class Produit
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int QteEnStock { get; set; }

        [StringLength(30)]
        public string NomProduit { get; set; } = string.Empty;

        [StringLength(100)]
        public string DescriptionProduit { get; set; } = string.Empty;
        public int SeuilCommandeMin { get; set; }
        public int CommandeMin { get; set; }
        //Qte carton Varchar ou Int ?
        public int QteCarton { get; set; }

        [StringLength(80)]
        public string PhotoProduitPath { get; set; } = string.Empty;
        public bool AlaVente { get; set; }

        [ForeignKey(nameof(Domaine))]
        public int DomaineId { get; set; }
        public Domaine? Domaine { get; set; }

        [ForeignKey(nameof(Categorie))]
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; } = null!;

        [ForeignKey(nameof(PrixAchat))]
        public int PrixAchatId { get; set; }
        public Categorie PrixAchat { get; set; } = null!;
        
        [ForeignKey(nameof(PrixVente))]
        public int PrixVenteId { get; set; }
        public Categorie PrixVente { get; set; } = null!;



    }
}
