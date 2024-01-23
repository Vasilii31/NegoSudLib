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
    [Migration("20240122084248_NegoSud")]
    partial class NegoSud
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

            modelBuilder.Entity("NegoSudLib.DAO.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdresseUtilisateur")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("HMotDePasse")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MailUtilisateur")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomUtilisateur")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("NumClient")
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

                    b.HasKey("Id");

                    b.ToTable("Clients");
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

            modelBuilder.Entity("NegoSudLib.DAO.Employe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdresseUtilisateur")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Gerant")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HMotDePasse")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("MailUtilisateur")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

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

                    b.HasKey("Id");

                    b.ToTable("Employes");
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
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

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

                    b.Property<int>("QteMouvement")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeId");

                    b.ToTable("MouvementStock");

                    b.HasDiscriminator<string>("Discriminator").HasValue("MouvementStock");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("NegoSudLib.DAO.PrixAchat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateFin")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FournisseurId")
                        .HasColumnType("int");

                    b.Property<float>("PrixCarton")
                        .HasColumnType("float");

                    b.Property<float>("PrixUnite")
                        .HasColumnType("float");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FournisseurId");

                    b.HasIndex("ProduitId");

                    b.ToTable("PrixAchats");
                });

            modelBuilder.Entity("NegoSudLib.DAO.PrixVente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateFin")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("PrixCarton")
                        .HasColumnType("float");

                    b.Property<float>("PrixUnite")
                        .HasColumnType("float");

                    b.Property<int>("ProduitId")
                        .HasColumnType("int");

                    b.Property<float>("Promotion")
                        .HasColumnType("float");

                    b.Property<float>("Taxe")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProduitId");

                    b.ToTable("PrixVentes");
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

            modelBuilder.Entity("NegoSudLib.DAO.AutreMouvement", b =>
                {
                    b.HasBaseType("NegoSudLib.DAO.MouvementStock");

                    b.Property<int>("TypeMouvementId")
                        .HasColumnType("int");

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

                    b.HasDiscriminator().HasValue("Vente");
                });

            modelBuilder.Entity("NegoSudLib.DAO.DetailMouvementStock", b =>
                {
                    b.HasOne("NegoSudLib.DAO.MouvementStock", "MouvementsStock")
                        .WithMany("DetailMouvementStocks")
                        .HasForeignKey("MouvementStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegoSudLib.DAO.Produit", "Produit")
                        .WithMany()
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MouvementsStock");

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("NegoSudLib.DAO.MouvementStock", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Employe", "Employe")
                        .WithMany()
                        .HasForeignKey("EmployeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employe");
                });

            modelBuilder.Entity("NegoSudLib.DAO.PrixAchat", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Fournisseur", "Fournisseur")
                        .WithMany()
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegoSudLib.DAO.Produit", "Produit")
                        .WithMany("PrixAchats")
                        .HasForeignKey("ProduitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fournisseur");

                    b.Navigation("Produit");
                });

            modelBuilder.Entity("NegoSudLib.DAO.PrixVente", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Produit", "Produit")
                        .WithMany("PrixVentes")
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

            modelBuilder.Entity("NegoSudLib.DAO.AutreMouvement", b =>
                {
                    b.HasOne("NegoSudLib.DAO.TypeMouvement", "TypeMouvement")
                        .WithMany()
                        .HasForeignKey("TypeMouvementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeMouvement");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Commande", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Fournisseur", "Fournisseur")
                        .WithMany()
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Vente", b =>
                {
                    b.HasOne("NegoSudLib.DAO.Client", "Client")
                        .WithMany("HistoriqueVentes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("NegoSudLib.DAO.Client", b =>
                {
                    b.Navigation("HistoriqueVentes");
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
#pragma warning restore 612, 618
        }
    }
}
