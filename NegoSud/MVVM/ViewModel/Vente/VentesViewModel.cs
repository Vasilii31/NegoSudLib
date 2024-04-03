using NegoSud.Core;
using NegoSud.Services;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class VentesViewModel : ViewModelBase
    {
        public ObservableCollection<VentePdtItemViewModel> ListeProduits { get; set; } = new();
        public ObservableCollection<ClientDTO> ListeClients { get; set; } = new();
        public ObservableCollection<PanierItemViewModel> Panier { get; set; } = new();

		public ObservableCollection<ConsultVenteItemViewModel> ListeVentes { get; set; } = new();
		public ObservableCollection<ConsultVenteItemViewModel> ListeVentesEnLigne { get; set; } = new();

		private VentesWriteDTO Vente = new VentesWriteDTO();

        private string _recherche;

        public string Recherche
        {
            get { return _recherche; }
            set
            {
                if (value != _recherche)
                {
                    _recherche = value;
                    OnPropertyChanged(nameof(Recherche));
                }
            }
        }

		private List<DetailMouvementStockDTO> _currentListVente = new();

		public List<DetailMouvementStockDTO> CurrentListVente
		{
			get { return _currentListVente; }
			set
			{
				_currentListVente = value;
				OnPropertyChanged(nameof(CurrentListVente));

			}
		}

		private ClientDTO _clientSelectionne;
        public ClientDTO ClientSelectionne
        {
            get { return _clientSelectionne; }
            set
            {
                _clientSelectionne = value;
                OnPropertyChanged(nameof(ClientSelectionne));
            }
        }

        private ClientDTO _clientAjout = new();
        public ClientDTO ClientAjout
        {
            get { return _clientAjout; }
            set
            {
                _clientAjout = value;
                OnPropertyChanged(nameof(ClientAjout));
            }
        }

        private string _nbItemPanier = "Panier";

        public string NbItemPanier
        {
            get { return _nbItemPanier; }
            set
            {
                _nbItemPanier = value;
                OnPropertyChanged(nameof(NbItemPanier));
            }
        }

        private string _commentaire = "";

        public string Commentaire
        {
            get { return _commentaire; }
            set
            {
                _commentaire = value;
                OnPropertyChanged(nameof(Commentaire));
            }
        }
        private float _total;

        public float Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        public Visibility _isPopUpVisible = Visibility.Collapsed;

        public Visibility PanierVisible
        {
            get { return _isPopUpVisible; }
            set
            {
                _isPopUpVisible = value;
                OnPropertyChanged(nameof(PanierVisible));

            }
        }

        public Visibility _AjoutClientVisible = Visibility.Collapsed;

        public Visibility AjoutClientVisible
        {
            get { return _AjoutClientVisible; }
            set
            {
                _AjoutClientVisible = value;
                OnPropertyChanged(nameof(AjoutClientVisible));

            }
        }

		private ProduitLightDTO _currentProduitDTO;
        public ProduitLightDTO CurrentProduitDTO
        {
            get { return _currentProduitDTO; }
            set
            {
                _currentProduitDTO = value;
                OnPropertyChanged(nameof(CurrentProduitDTO));
            }
        }

		public Visibility _venteLocaleVisibility = Visibility.Hidden;

		public Visibility VenteLocaleVisibility
		{
			get { return _venteLocaleVisibility; }
			set
			{
				_venteLocaleVisibility = value;
				OnPropertyChanged(nameof(VenteLocaleVisibility));

			}
		}

		public Visibility _consultVenteVisible = Visibility.Hidden;

		public Visibility ConsultVenteVisible
		{
			get { return _consultVenteVisible; }
			set
			{
				_consultVenteVisible = value;
				OnPropertyChanged(nameof(ConsultVenteVisible));

			}
		}

		public Visibility _venteEnLigneVisibility = Visibility.Hidden;

		public Visibility VenteEnLigneVisibility
		{
			get { return _venteEnLigneVisibility; }
			set
			{
				_venteEnLigneVisibility = value;
				OnPropertyChanged(nameof(VenteEnLigneVisibility));

			}
		}

		private ConsultVenteItemViewModel _currentVente;
		public ConsultVenteItemViewModel CurrentVente
		{
			get { return _currentVente; }
			set
			{
				_currentVente = value;
				OnPropertyChanged(nameof(CurrentVente));

			}
		}

		public ICommand AfficherVenteLocaleCommand { get; set; }
        public ICommand AfficherVenteEnLigneCommand { get; set; }
		public ICommand FermerVenteConsultCommand { get; set; }

		public VentesViewModel()
        {
			CreateListeVentes();
			CreateListeVentesEnLigne();
			GetProductsAll();
            GetClients();

            AfficherVenteLocaleCommand = new RelayCommand(AfficherVenteLocale);
			AfficherVenteEnLigneCommand = new RelayCommand(AfficherVenteEnLigne);
			FermerVenteConsultCommand = new RelayCommand(FermerEcranConsult);
		}

		private void CreateListeVentesEnLigne()
		{
			ListeVentesEnLigne.Clear();

			Task.Run(async () =>
			{
				return await httpClientService.GetVentesEnLigne();

			})
			.ContinueWith(t =>
			{
				foreach (var vente in t.Result)
				{
					var item = new ConsultVenteItemViewModel(vente);
					//item.deleted += Item_deleted;
					//item.modify += Item_modifyPopup;
					item.Ventes.SetTotaux();
					item.ouvrirVenteForm += OuvrirForm;
					ListeVentesEnLigne.Add(item);

				}

			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void FermerEcranConsult(object obj)
		{
			ConsultVenteVisible = Visibility.Hidden;
		}

		private void CreateListeVentes()
		{
			ListeVentes.Clear();

			Task.Run(async () =>
			{
				return await httpClientService.GetVentes();

			})
			.ContinueWith(t =>
			{
				foreach (var vente in t.Result)
				{
					var item = new ConsultVenteItemViewModel(vente);
					//item.deleted += Item_deleted;
					//item.modify += Item_modifyPopup;
					item.Ventes.SetTotaux();
					item.ouvrirVenteForm += OuvrirForm;
					ListeVentes.Add(item);

				}

			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		internal void FermerConsult(object sender, RoutedEventArgs e)
		{
			CurrentVente = null;
			CurrentListVente.Clear();
			ConsultVenteVisible = Visibility.Hidden;
		}

		private void OuvrirForm(object? sender, EventArgs e)
		{
			CurrentVente = (ConsultVenteItemViewModel)sender;
			CurrentListVente = CurrentVente.Ventes.DetailMouvementStocks.ToList();
			ConsultVenteVisible = Visibility.Visible;
		}
		private void AfficherVenteEnLigne(object obj)
		{
			VenteEnLigneVisibility = Visibility.Visible;
			VenteLocaleVisibility = Visibility.Hidden;
		}

		private void AfficherVenteLocale(object obj)
		{
            VenteLocaleVisibility = Visibility.Visible;
            VenteEnLigneVisibility = Visibility.Hidden;
		}

		public ICommand CMD_VoirPanier { get; set; }

        public event EventHandler EH_VoirPanier;



        private void GetProductsAll()
        {
            ListeProduits.Clear();

            Task.Run(async () =>
            {
                return await httpClientService.GetProduitsAll();

            })
            .ContinueWith(t =>
            {
                foreach (var produit in t.Result)
                {
                    var item = new VentePdtItemViewModel(produit);
                    item.EH_AjoutPanier += Item_AjoutPanier;
                    item.EH_VoirPdt += Item_VoirPdt;
                    item.EH_PlusU += Item_PlusU;
                    item.EH_MoinsU += Item_MoinsU;
                    item.EH_PlusC += Item_PlusC;
                    item.EH_MoinsC += Item_MoinsC;
                    ListeProduits.Add(item);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void GetClients()
        {
            ListeClients.Clear();

            Task.Run(async () =>
            {
                return await httpClientService.GetClients();

            })
            .ContinueWith(t =>
            {
                foreach (var client in t.Result)
                {

                    ListeClients.Add(client);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void VoirPanier(object? sender, EventArgs e)
        {
            if (Panier.Count() == 0)
            {

                MessageBox.Show("Le panier est vide !", "Panier vide", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            PanierVisible = Visibility.Visible;
        }
        public void FermerPanier(object? sender, EventArgs e)
        {
            PanierVisible = Visibility.Collapsed;
        }

        // Methodes pour les boutons dans la liste
        private void Item_AjoutPanier(object? sender, EventArgs e)
        {


            VentePdtItemViewModel item = (VentePdtItemViewModel)sender;
            if (item.QteUnite > 0)
            {
                DetailMouvementStockDTO dtMvt = new DetailMouvementStockDTO()
                {
                    ProduitId = item.ProduitLightDTO.Id,
                    Produit = item.ProduitLightDTO,
                    QteProduit = item.QteUnite,
                    PrixApresRistourne = -1,
                    AuCarton = false,
                    SousTotal = item.ProduitLightDTO.PrixVente * item.QteUnite
                };

                AjouterOuModifierDansPanier(dtMvt);
            }
            if (item.QteCarton > 0)
            {
                DetailMouvementStockDTO dtMvt = new DetailMouvementStockDTO()
                {
                    ProduitId = item.ProduitLightDTO.Id,
                    Produit = item.ProduitLightDTO,
                    QteProduit = item.QteCarton,
                    PrixApresRistourne = -1,
                    AuCarton = true,
                    SousTotal = item.ProduitLightDTO.PrixVenteCarton * item.QteCarton
                };
                AjouterOuModifierDansPanier(dtMvt);
            }
            item.AjoutVisible = Visibility.Visible;
            Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(t => item.AjoutVisible = Visibility.Collapsed, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void AjouterOuModifierDansPanier(DetailMouvementStockDTO dtMvt)
        {
            var item = Panier.FirstOrDefault(item => item.DetailMouvementStockDTO.ProduitId == dtMvt.ProduitId && item.DetailMouvementStockDTO.AuCarton == dtMvt.AuCarton);
            if (item == null)
            {
                item = new PanierItemViewModel(dtMvt);
                Panier.Add(item);
                item.EH_SupprimerDuPanier += Item_SupprimerDuPanier;
            }
            else
            {
                item.DetailMouvementStockDTO.QteProduit += dtMvt.QteProduit;
                item.MajQte();
            }
            MajInfoPanier();
        }
        private void MajInfoPanier()
        {
            Total = 0;
            foreach (var item in Panier)
            {
                Total += item.SousTotal;
            }

            NbItemPanier = Panier.Count() == 0 ? "Panier" : "Panier (" + Panier.Count() + ")";

        }

        private void Item_SupprimerDuPanier(object sender, EventArgs e)
        {
            PanierItemViewModel item = (PanierItemViewModel)sender;
            Panier.Remove(item);
            MajInfoPanier();
        }
        private void Item_VoirPdt(object? sender, EventArgs e)
        {

        }
        private void Item_PlusU(object? sender, EventArgs e)
        {
            VentePdtItemViewModel item = (VentePdtItemViewModel)sender;
            item.QteUnite++;
        }
        private void Item_MoinsU(object? sender, EventArgs e)
        {
            VentePdtItemViewModel item = (VentePdtItemViewModel)sender;
            item.QteUnite--;
            if (item.QteUnite < 0) item.QteUnite = 0;
        }
        private void Item_PlusC(object? sender, EventArgs e)
        {
            VentePdtItemViewModel item = (VentePdtItemViewModel)sender;
            item.QteCarton++;
        }
        private void Item_MoinsC(object? sender, EventArgs e)
        {
            VentePdtItemViewModel item = (VentePdtItemViewModel)sender;
            item.QteCarton--;
            if (item.QteCarton < 0) item.QteCarton = 0;
        }


        public async void ValiderPanier(object sender, RoutedEventArgs e)
        {
            Vente.DetailMouvementStocks.Clear();

            foreach (var lgnPanier in Panier)
            {
                Vente.DetailMouvementStocks.Add(lgnPanier.DetailMouvementStockDTO);
            }
            if (ClientSelectionne != null)
            {
                Vente.ClientId = ClientSelectionne.Id;
            }
            else
            {
                MessageBox.Show("Merci de chosir un client", "Choisissez un client", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Vente.Commentaire = Commentaire;

            // TODO chercher comment recup l'id, sinon combo avec liste des employés
            Vente.EmployeId = int.Parse(Application.Current.Properties["EmployeID"].ToString());

            Vente.SetTotaux();

            try
            {

                // Appel de votre méthode AddVente pour ajouter la vente dans la base de données
                VentesDTO venteAjoutee = await httpClientService.AddVente(Vente);
                MessageBox.Show("La vente a été ajoutée avec succès!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                Panier.Clear();
                PanierVisible = Visibility.Collapsed;
                MajInfoPanier();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Un problème est survenu", "Erreur", MessageBoxButton.OK, MessageBoxImage.Information);
                // Vous pouvez logger l'exception ou afficher un message d'erreur à l'utilisateur
            }

        }

        internal void SearchProduits(object sender, RoutedEventArgs e)
        {
            ListeProduits.Clear();
            Task.Run(async () =>
            {
                return await httpClientService.SearchProduits(0, 0, 0, Recherche, null);

            })
                        .ContinueWith(t =>
                        {
                            foreach (var produit in t.Result)
                            {
                                var item = new VentePdtItemViewModel(produit);
                                item.EH_AjoutPanier += Item_AjoutPanier;
                                item.EH_VoirPdt += Item_VoirPdt;
                                item.EH_PlusU += Item_PlusU;
                                item.EH_MoinsU += Item_MoinsU;
                                item.EH_PlusC += Item_PlusC;
                                item.EH_MoinsC += Item_MoinsC;
                                ListeProduits.Add(item);

                            }

                        }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public async void ValiderClient(object sender, RoutedEventArgs e)
        {

            ClientAjout.UserName = ClientAjout.NomUtilisateur + ClientAjout.PrenomUtilisateur + "TMP";
            ClientAjout.MotDePasse = "P@ssw0rd";
            try
            {

                // Appel de votre méthode AddVente pour ajouter la vente dans la base de données
                ClientDTO clientAjoute = await httpClientService.AddClient(ClientAjout);
                MessageBox.Show("Le client a été ajoutée avec succès!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                ClientSelectionne = clientAjoute;
                ListeClients.Add(clientAjoute);
                ClientAjout = new();
                AjoutClientVisible = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Un problème est survenu", "Erreur", MessageBoxButton.OK, MessageBoxImage.Information);
                // Vous pouvez logger l'exception ou afficher un message d'erreur à l'utilisateur
            }
        }


        public void voirClient(object? sender, EventArgs e)
        {
            AjoutClientVisible = Visibility.Visible;
        }
        public void FermerClient(object? sender, EventArgs e)
        {
            AjoutClientVisible = Visibility.Collapsed;
        }
    }
}
