using Microsoft.EntityFrameworkCore;
using NegoSudLib.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSudLib.NegosudDbContext
{
    public class NegoSudDBContext : DbContext
    {
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Domaine> Domaines { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<DetailMouvementStock> DetailsMouvementStock { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<AutreMouvement> AutreMouvements{ get; set; }
        public DbSet<PrixAchat> PrixAchats { get; set; }
        public DbSet<PrixVente> PrixVentes { get; set; }
        public DbSet<Prix> Prix{ get; set; }
        public DbSet<Vente> Ventes { get; set; }
        public DbSet<TypeMouvement> TypesMouvement { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<MouvementStock> MouvementStocks { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;port=3306;userid=root;password=;database=NegoSudDB;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

    }
}
