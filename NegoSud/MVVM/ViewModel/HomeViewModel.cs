using Microsoft.EntityFrameworkCore.Query;
using NegoSud.Core;
using NegoSud.MVVM.View.Template;
using NegoSud.Services;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.write;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<ProductsItemViewModel> ItemsLow { get; set; } = new();
        public ICommand GenerateOrdersCommand { get; set; }
        public ICommand RetourCommand { get; set; }
        public ICommand ValidateCommandeAutoCommand { get; set; }

        public Visibility _ouvrirCmdAutoVisibility = Visibility.Hidden;

        public Visibility OuvrirCmdAutoVisibility
        {
            get { return _ouvrirCmdAutoVisibility; }
            set
            {
                _ouvrirCmdAutoVisibility = value;
                OnPropertyChanged(nameof(OuvrirCmdAutoVisibility));

            }
        }

        public Visibility _ouvrirPanierCmdAutoVisibility = Visibility.Hidden;

        public Visibility OuvrirPanierCmdAutoVisibility
        {
            get { return _ouvrirPanierCmdAutoVisibility; }
            set
            {
                _ouvrirPanierCmdAutoVisibility = value;
                OnPropertyChanged(nameof(OuvrirPanierCmdAutoVisibility));

            }
        }
        private CommandeAutoViewModel _currentCommandeAuto;

        public CommandeAutoViewModel CurrentCommandeAuto
        {
            get { return _currentCommandeAuto; }
            set
            {
                _currentCommandeAuto = value;
                OnPropertyChanged(nameof(CurrentCommandeAuto));

            }
        }

        public ObservableCollection<CommandeAutoViewModel> CommandesAuto { get; set; } = new();
        //public List<ObservableCollection<PanierItemViewModel>> CommandesAuto { get; set; } = new();
        //private List<CommandeWriteDTO> CommandesAuto { get; set; } = new();

        public HomeViewModel()
        {
            GetListItemsLow();
            GenerateOrdersCommand = new RelayCommand(GenerateOrders);
            RetourCommand = new RelayCommand(CloseAutoOrders);
            ValidateCommandeAutoCommand = new RelayCommand(PostCommandeAuto);
        }

        private void PostCommandeAuto(object obj)
        {
            CommandeWriteDTO command = new CommandeWriteDTO()
            {
                DateMouvement = DateTime.Now,
                Commentaire = CurrentCommandeAuto.CommentaireAAjouter,
                FournisseurId = CurrentCommandeAuto.CommandeToPush.FournisseurId,
                EmployeId = int.Parse(Application.Current.Properties["EmployeID"].ToString()),
                StatutCommande = Statuts.ENVOYE
            };
            foreach (var item in CurrentCommandeAuto.ListToOrder)
            {
                if (item.QteUnite > 0)
                {
                    DetailMouvementStockDTO dtMvt = new DetailMouvementStockDTO()
                    {
                        ProduitId = item.ProduitLightDTO.Id,
                        Produit = item.ProduitLightDTO,
                        QteProduit = item.QteUnite,
                        PrixApresRistourne = -1,
                        AuCarton = false,
                        SousTotal = item.ProduitLightDTO.PrixAchat * item.QteUnite
                    };
                    command.DetailMouvementStocks.Add(dtMvt);

                }

            }

            Task.Run(async () =>
            {

                return await httpClientService.AddCommande(command);

            }).ContinueWith(t =>
            {
                if (t.Result == null)
                {
                    MessageBox.Show("Un problème est survenu", "Erreur", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("La commande a été ajoutée avec succès!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                    CurrentCommandeAuto = null;
                    GetListItemsLow();
                    GenerateOrders(new Object());
                    OuvrirPanierCmdAutoVisibility = Visibility.Hidden;
                }


            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void CloseAutoOrders(object obj)
        {
            CommandesAuto.Clear();
            OuvrirCmdAutoVisibility = Visibility.Hidden;
        }

        private void GenerateOrders(object obj)
        {
            CommandesAuto.Clear();
            foreach (var prod in ItemsLow)
            {
                //var test = CommandesAuto.Where(p => p.FournisseurId == prod.ProduitLightDTO.IdFournisseur).Any();
                if (!CommandesAuto.Where(p => p.CommandeToPush.FournisseurId == prod.ProduitLightDTO.IdFournisseur).Any())
                {
                    var item = new CommandeAutoViewModel(new CommandeWriteDTO()
                    {
                        DateMouvement = DateTime.Now,
                        EmployeId = int.Parse(Application.Current.Properties["EmployeID"].ToString()),
                        FournisseurId = prod.ProduitLightDTO.IdFournisseur,
                        StatutCommande = Statuts.AVALIDER

                    });
                    item.NomFournisseur = prod.ProduitLightDTO.Fournisseur;

                    item.ouvrirCommandeForm += Item_ouvrirCommandeForm;
                    CommandesAuto.Add(item);

                }
            }

            foreach (var commandeAuto in CommandesAuto)
            {
                IEnumerable<ProductsItemViewModel> listTemp = ItemsLow.Where(p => p.ProduitLightDTO.IdFournisseur == commandeAuto.CommandeToPush.FournisseurId).ToList();
                foreach (var prod in listTemp)
                {
                    commandeAuto.Total += prod.ProduitLightDTO.PrixAchat * prod.ProduitLightDTO.SeuilCommandeMin;
                    var pdtItem = new CmdPdtItemViewModel(prod.ProduitLightDTO);
                    pdtItem.QteUnite = prod.ProduitLightDTO.SeuilCommandeMin;
                    pdtItem.SetSousTotal();
                    //pdtItem.EH_AjoutPanier += Item_AjoutPanier;
                    pdtItem.EH_VoirPdt += Item_VoirPdt;
                    pdtItem.EH_PlusU += Item_PlusU;
                    pdtItem.EH_MoinsU += Item_MoinsU;
                    pdtItem.EH_PlusC += Item_PlusC;
                    pdtItem.EH_MoinsC += Item_MoinsC;
                    pdtItem.EH_DeleteCommandeAuto += DeleteItem;
                    commandeAuto.ListToOrder.Add(pdtItem);

                    //commandeAuto.CommandeToPush.DetailMouvementStocks.Add(new DetailMouvementStockDTO()
                    //{
                    //    ProduitId = prod.ProduitLightDTO.Id,
                    //    Produit = prod.ProduitLightDTO,
                    //    QteProduit = prod.ProduitLightDTO.SeuilCommandeMin,//(prod.ProduitLightDTO.QteEnStock + prod.ProduitLightDTO.CommandeMin <= prod.ProduitLightDTO.SeuilCommandeMin) ? : prod.ProduitLightDTO.CommandeMin
                    //    PrixApresRistourne = -1,
                    //    AuCarton = false,
                    //    SousTotal = prod.ProduitLightDTO.PrixAchat * prod.ProduitLightDTO.SeuilCommandeMin
                    //});
                }

            }

            OuvrirCmdAutoVisibility = Visibility.Visible;
        }

        private void DeleteItem(object? sender, EventArgs e)
        {
            CmdPdtItemViewModel p = (CmdPdtItemViewModel)sender;
            CurrentCommandeAuto.ListToOrder.Remove(p);
            CurrentCommandeAuto.RecalculateTotal();
            MessageBox.Show(CurrentCommandeAuto.CommandeToPush.DetailMouvementStocks.Count().ToString());
        }

        private void Item_ouvrirCommandeForm(object? sender, EventArgs e)
        {
            CurrentCommandeAuto = (CommandeAutoViewModel)sender;
            OuvrirPanierCmdAutoVisibility = Visibility.Visible;
        }

        private void Item_VoirPdt(object? sender, EventArgs e)
        {

        }
        private void Item_PlusU(object? sender, EventArgs e)
        {
            CmdPdtItemViewModel item = (CmdPdtItemViewModel)sender;

            item.QteUnite++;
            item.SetSousTotal();
            CurrentCommandeAuto.RecalculateTotal();
        }
        private void Item_MoinsU(object? sender, EventArgs e)
        {
            CmdPdtItemViewModel item = (CmdPdtItemViewModel)sender;
            item.QteUnite--;
            item.SetSousTotal();
            CurrentCommandeAuto.RecalculateTotal();
            if (item.QteUnite < 0) item.QteUnite = 0;
        }
        private void Item_PlusC(object? sender, EventArgs e)
        {
            CmdPdtItemViewModel item = (CmdPdtItemViewModel)sender;
            item.QteCarton++;
        }
        private void Item_MoinsC(object? sender, EventArgs e)
        {
            CmdPdtItemViewModel item = (CmdPdtItemViewModel)sender;
            item.QteCarton--;
            if (item.QteCarton < 0) item.QteCarton = 0;
        }



        //        //on trouve le nombre de fournisseur différent dans la liste d'items, ce sera notre nombre total de commandes
        //        List<int> fournisseursId = new List<int>();

        //    foreach (var prod in ItemsLow)
        //    {
        //        if (!fournisseursId.Contains(prod.ProduitLightDTO.IdFournisseur))
        //        {
        //            fournisseursId.Add(prod.ProduitLightDTO.IdFournisseur);
        //        }

        //    }

        //    // pour chaque fournisseur on créé une nouvelle commande
        //    foreach (var fournisseur in fournisseursId)
        //    {
        //        //List<DetailMouvementStockDTO> listeCommande = new List<DetailMouvementStockDTO>();
        //        foreach (var prod in ItemsLow)
        //        {
        //            if(prod.ProduitLightDTO.IdFournisseur == fournisseur)
        //            {
        //                listeCommande.Add(new DetailMouvementStockDTO()
        //                {
        //                    ProduitId = prod.ProduitLightDTO.Id,
        //                    Produit = prod.ProduitLightDTO,
        //                    QteProduit = prod.ProduitLightDTO.SeuilCommandeMin,//(prod.ProduitLightDTO.QteEnStock + prod.ProduitLightDTO.CommandeMin <= prod.ProduitLightDTO.SeuilCommandeMin) ? : prod.ProduitLightDTO.CommandeMin
        //                    PrixApresRistourne = -1,
        //                    AuCarton = false,
        //                    SousTotal = prod.ProduitLightDTO.PrixAchat * prod.ProduitLightDTO.SeuilCommandeMin
        //                });
        //            }
        //        }
        //    }

        //}


        //private void AjouterOuModifierDansPanier(DetailMouvementStockDTO dtMvt)
        //{
        //    var item = Panier.FirstOrDefault(item => item.DetailMouvementStockDTO.ProduitId == dtMvt.ProduitId && item.DetailMouvementStockDTO.AuCarton == dtMvt.AuCarton);
        //    if (item == null)
        //    {
        //        item = new PanierItemViewModel(dtMvt);
        //        Panier.Add(item);
        //        item.EH_SupprimerDuPanier += Item_SupprimerDuPanier;
        //    }
        //    else
        //    {
        //        item.DetailMouvementStockDTO.QteProduit += dtMvt.QteProduit;
        //        item.MajQte();
        //    }
        //    MajInfoPanier();
        //}
        internal void ValiderPanier(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ajout en base a implementer");
        }

        internal void FermerPanier(object sender, RoutedEventArgs e)
        {
            CurrentCommandeAuto = null;
            OuvrirPanierCmdAutoVisibility = Visibility.Hidden;

        }

        private void GetListItemsLow()
        {
            ItemsLow.Clear();

            Task.Run(async () =>
            {
                return await httpClientService.GetProductsLow();

            })
            .ContinueWith(t =>
            {
                foreach (var product in t.Result)
                {
                    var item = new ProductsItemViewModel(product);
                    //item.deleted += Item_deleted;
                    //item.modify += Item_modifyPopup;

                    //item.ouvrirVenteForm += OuvrirForm;
                    ItemsLow.Add(item);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
