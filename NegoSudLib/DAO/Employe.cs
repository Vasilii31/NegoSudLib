namespace NegoSudLib.DAO
{
    public class Employe : Utilisateur
    {
        public virtual IEnumerable<Vente>? HistoriqueVentes { get; set; }
        public virtual IEnumerable<Commande>? HistoriqueCommandes { get; set; }
        public virtual IEnumerable<AutreMouvement>? HistoriqueAutreMouvements { get; set; }

    }
}