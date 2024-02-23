using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NegoSudLib.DAO;

namespace NegoSudLib.NegosudDbContext
{
    public class NegoSudDBContext(DbContextOptions<NegoSudDBContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Domaine> Domaines { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<DetailMouvementStock> DetailsMouvementStock { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<AutreMouvement> AutreMouvements { get; set; }
        public DbSet<PrixAchat> PrixAchats { get; set; }
        public DbSet<PrixVente> PrixVentes { get; set; }
        public DbSet<Prix> Prix { get; set; }
        public DbSet<Vente> Ventes { get; set; }
        public DbSet<TypeMouvement> TypesMouvement { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<MouvementStock> MouvementStocks { get; set; }
        public DbSet<Inventaire> Inventaires { get; set; }
        public DbSet<LigneInventaire> LignesInventaires { get; set; }

    }



    public class NegoSudDBContextFactory : IDesignTimeDbContextFactory<NegoSudDBContext>
    {
        public NegoSudDBContext CreateDbContext(string[] args)
        {
            var connexionString = "server=localhost;port=3306;userid=root;password=;database=NegoSuddb;";
            var optionsBuilder = new DbContextOptionsBuilder<NegoSudDBContext>();
            optionsBuilder.UseMySql(connexionString, ServerVersion.AutoDetect(connexionString));

            return new NegoSudDBContext(optionsBuilder.Options);
        }
    }

}
