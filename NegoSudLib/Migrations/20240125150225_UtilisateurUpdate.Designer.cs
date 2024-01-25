﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NegoSudLib.NegosudDbContext;

#nullable disable

namespace NegoSudLib.Migrations
{
    [DbContext(typeof(NegoSudDBContext))]
    [Migration("20240125150225_UtilisateurUpdate")]
    partial class UtilisateurUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NegoSudLib.DAO.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomCategorie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NegoSudLib.DAO.DetailMouvementStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AuCarton")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MouvementStockId")
                        .HasColumnType("int");

                    b.Property<float>("PrixApresRistourne")
                        .HasColumnType("float");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int");

                    b.Property<int>("QteProduit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MouvementStockId");

                    b.HasIndex("ProduitId");

                    b.ToTable("DetailsMouvementStock");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Domaine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomDomaine")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Domaines");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Fournisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdresseFournisseur")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EmailFournisseur")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NomFournisseur")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NumTelFournisseur")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("NegoSudLib.DAO.MouvementStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateMouvement")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("varchar(21)");

                    b.Property<int>("EmployeId")
                        .HasColumnType("int");

                    b.Property<bool>("EntreeOuSortie")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("MouvementStocks");

                    b.HasDiscriminator<string>("Discriminator").HasValue("MouvementStock");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("NegoSudLib.DAO.Prix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateFin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<float>("PrixCarton")
                        .HasColumnType("float");

                    b.Property<float>("PrixUnite")
                        .HasColumnType("float");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Prix");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Prix");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("NegoSudLib.DAO.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AlaVente")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<int>("CommandeMin")
                        .HasColumnType("int");

                    b.Property<int>("ContenanceCl")
                        .HasColumnType("int");

                    b.Property<float>("DegreeAlcool")
                        .HasColumnType("float");

                    b.Property<string>("DescriptionProduit")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("DomaineId")
                        .HasColumnType("int");

                    b.Property<int>("Millesime")
                        .HasColumnType("int");

                    b.Property<string>("NomProduit")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("PhotoProduitPath")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("QteCarton")
                        .HasColumnType("int");

                    b.Property<int>("QteEnStock")
                        .HasColumnType("int");

                    b.Property<int>("SeuilCommandeMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("DomaineId");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("NegoSudLib.DAO.TypeMouvement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomTypeMouvement")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TypesMouvement");
                });

            modelBuilder.Entity("NegoSudLib.DAO.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("NegoSudLib.DAO.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdresseUtilisateur")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("NomUtilisateur")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("NumTelUtilisateur")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("PrenomUtilisateur")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Utilisateurs");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Utilisateur");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("NegoSudLib.DAO.AutreMouvement", b =>
                {
                    b.HasBaseType("NegoSudLib.DAO.MouvementStock");

                    b.Property<int>("TypeMouvementId")
                        .HasColumnType("int");

                    b.HasIndex("EmployeId");

                    b.HasIndex("TypeMouvementId");

                    b.HasDiscriminator().HasValue("AutreMouvement");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Commande", b =>
                {
                    b.HasBaseType("NegoSudLib.DAO.MouvementStock");

                    b.Property<int>("FournisseurId")
                        .HasColumnType("int");

                    b.Property<string>("NumCommande")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("StatutCommande")
                        .HasColumnType("int");

                    b.HasIndex("EmployeId");

                    b.HasIndex("FournisseurId");

                    b.HasDiscriminator().HasValue("Commande");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Vente", b =>
                {
                    b.HasBaseType("NegoSudLib.DAO.MouvementStock");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("NumFacture")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeId");

                    b.HasDiscriminator().HasValue("Vente");
                });

            modelBuilder.Entity("NegoSudLib.DAO.PrixAchat", b =>
                {
                    b.HasBaseType("NegoSudLib.DAO.Prix");

                    b.Property<int>("FournisseurId")
                        .HasColumnType("int");

                    b.HasIndex("FournisseurId");

                    b.HasIndex("ProduitId");

                    b.HasDiscriminator().HasValue("PrixAchat");
                });

            modelBuilder.Entity("NegoSudLib.DAO.PrixVente", b =>
                {
                    b.HasBaseType("NegoSudLib.DAO.Prix");

                    b.Property<float>("Promotion")
                        .HasColumnType("float");

                    b.Property<float>("Taxe")
                        .HasColumnType("float");

                    b.HasIndex("ProduitId");

                    b.HasDiscriminator().HasValue("PrixVente");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Client", b =>
                {
                    b.HasBaseType("NegoSudLib.DAO.Utilisateur");

                    b.Property<string>("NumClient")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Employe", b =>
                {
                    b.HasBaseType("NegoSudLib.DAO.Utilisateur");

                    b.HasDiscriminator().HasValue("Employe");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NegoSudLib.DAO.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NegoSudLib.DAO.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegoSudLib.DAO.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NegoSudLib.DAO.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NegoSudLib.DAO.DetailMouvementStock", b =>
                {
                    b.HasOne("NegoSudLib.DAO.MouvementStock", null)
                        .WithMany("DetailMouvementStocks")
                        .HasForeignKey("MouvementStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegoSudLib.DAO.Produit", "Produit")
                        .WithMany()
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Produit", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegoSudLib.DAO.Domaine", "Domaine")
                        .WithMany()
                        .HasForeignKey("DomaineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Domaine");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Utilisateur", b =>
                {
                    b.HasOne("NegoSudLib.DAO.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NegoSudLib.DAO.AutreMouvement", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Employe", "Employe")
                        .WithMany("HistoriqueAutreMouvements")
                        .HasForeignKey("EmployeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegoSudLib.DAO.TypeMouvement", "TypeMouvement")
                        .WithMany()
                        .HasForeignKey("TypeMouvementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employe");

                    b.Navigation("TypeMouvement");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Commande", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Employe", "Employe")
                        .WithMany("HistoriqueCommandes")
                        .HasForeignKey("EmployeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegoSudLib.DAO.Fournisseur", "Fournisseur")
                        .WithMany()
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employe");

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Vente", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Client", "Client")
                        .WithMany("HistoriqueVentes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegoSudLib.DAO.Employe", "Employe")
                        .WithMany("HistoriqueVentes")
                        .HasForeignKey("EmployeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employe");
                });

            modelBuilder.Entity("NegoSudLib.DAO.PrixAchat", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Fournisseur", "Fournisseur")
                        .WithMany()
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegoSudLib.DAO.Produit", null)
                        .WithMany("PrixAchats")
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("NegoSudLib.DAO.PrixVente", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Produit", null)
                        .WithMany("PrixVentes")
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NegoSudLib.DAO.MouvementStock", b =>
                {
                    b.Navigation("DetailMouvementStocks");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Produit", b =>
                {
                    b.Navigation("PrixAchats");

                    b.Navigation("PrixVentes");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Client", b =>
                {
                    b.Navigation("HistoriqueVentes");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Employe", b =>
                {
                    b.Navigation("HistoriqueAutreMouvements");

                    b.Navigation("HistoriqueCommandes");

                    b.Navigation("HistoriqueVentes");
                });
#pragma warning restore 612, 618
        }
    }
}
