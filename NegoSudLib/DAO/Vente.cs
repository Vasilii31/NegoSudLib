using System.ComponentModel.DataAnnotations.Schema;

namespace NegoSudLib.DAO
{
    public class Vente : MouvementStock
    {
        public string NumFacture { get; set; } = string.Empty;

        [ForeignKey(nameof(Employe))]
        public int EmployeId { get; set; }
        public Employe Employe { get; set; } = null!;

        [ForeignKey(nameof(Client))] 
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}