using NegoSud.Core;
using NegoSud.Services;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using NegoSudLib.DTO.Write;
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
	public class GestionInventaireViewModel : ViewModelBase
	{
		public ObservableCollection<ItemInventaireHistoriqueViewModel> ListeInventaireHistorique { get; set; } = new();
		public ObservableCollection<ProductInventaireItemViewModel> ListeProduits { get; set;} = new();

		private ItemInventaireHistoriqueViewModel _inventaireEnCours;
		public ItemInventaireHistoriqueViewModel InventaireEnCours
		{
			get { return _inventaireEnCours; }
			set
			{
				_inventaireEnCours = value;
				OnPropertyChanged(nameof(InventaireEnCours));
			}
		}

		private ItemInventaireHistoriqueDetailsViewModel _inventaireConsultEnCours;
		public ItemInventaireHistoriqueDetailsViewModel InventaireConsultEnCours
		{
			get { return _inventaireConsultEnCours; }
			set
			{
				_inventaireConsultEnCours = value;
				OnPropertyChanged(nameof(InventaireConsultEnCours));
			}
		}

		private Visibility _noInventaireEnCoursVisibility;
		public Visibility NoInventaireEnCoursVisibility
		{
			get { return _noInventaireEnCoursVisibility; }
			set
			{
				_noInventaireEnCoursVisibility = value;
				OnPropertyChanged(nameof(NoInventaireEnCoursVisibility));
			}
		}

		private Visibility _inventaireEnCoursVisibility;
		public Visibility InventaireEnCoursVisibility
		{
			get { return _inventaireEnCoursVisibility; }
			set
			{
				_inventaireEnCoursVisibility = value;
				OnPropertyChanged(nameof(InventaireEnCoursVisibility));
			}
		}

		private Visibility _formulaireInventaireVisibility = Visibility.Hidden;
		public Visibility FormulaireInventaireVisibility
		{
			get { return _formulaireInventaireVisibility; }
			set
			{
				_formulaireInventaireVisibility = value;
				OnPropertyChanged(nameof(FormulaireInventaireVisibility));
			}
		}

		private Visibility _consultationInventaireHistoriqueVisibility = Visibility.Hidden;
		public Visibility ConsultationInventaireHistoriqueVisibility
		{
			get { return _consultationInventaireHistoriqueVisibility; }
			set
			{
				_consultationInventaireHistoriqueVisibility = value;
				OnPropertyChanged(nameof(ConsultationInventaireHistoriqueVisibility));
			}
		}

		public ICommand NouvelInventaireCommand { get; set; }
		public ICommand TerminerInventaireCommand { get; set; }
		public ICommand AnnulerInventaireCommand { get; set; }
		public ICommand Retour { get; set; }
		public ICommand ImprimerInventaire { get; set; }

		public GestionInventaireViewModel()
        {
			GetInventaireEnCours();
			GetListeInventaireHistorique();
			NouvelInventaireCommand = new RelayCommand(OuvrirNouvelInventaireForm);
			TerminerInventaireCommand = new RelayCommand(TerminerInventaire);
			AnnulerInventaireCommand = new RelayCommand(AnnulerInventaire);
			ImprimerInventaire = new RelayCommand(ImprimerInventaireHisto);
			Retour = new RelayCommand(FermerConsultHisto);
		}

		private void ImprimerInventaireHisto(object obj)
		{
			MessageBox.Show("Bientôt disponible ;)", "Imprimer l'inventaire");
		}

		private void FermerConsultHisto(object obj)
		{
			InventaireConsultEnCours = null;
			ConsultationInventaireHistoriqueVisibility = Visibility.Hidden;
		}

		private void AnnulerInventaire(object obj)
		{
			MessageBoxResult dialogResult = MessageBox.Show("En annulant, vous allez perdre toutes vos modifications en cours.\n\n Voulez vous continuer ?", "Attention !", MessageBoxButton.YesNo);
			if (dialogResult == MessageBoxResult.Yes)
			{
				ListeProduits.Clear();
				FormulaireInventaireVisibility = Visibility.Hidden;
            }
			else if (dialogResult == MessageBoxResult.No)
			{
				return;
			}
		}

		private void Inventaire_Consult(object? sender, EventArgs e)
		{
			ItemInventaireHistoriqueViewModel item = (ItemInventaireHistoriqueViewModel)sender;

			Task.Run(async () =>
			{
				return await httpClientService.GetInventaire(item.inventaire.Id);

			})
			.ContinueWith(t =>
			{

				if (t.Result.Id != 0)
				{
					InventaireConsultEnCours= new ItemInventaireHistoriqueDetailsViewModel(t.Result);
					ConsultationInventaireHistoriqueVisibility = Visibility.Visible;
				}
				else
				{
					MessageBox.Show("Une erreur est survenue, impossible de consulter l'inventaire", "Erreur");
				}
				


			}, TaskScheduler.FromCurrentSynchronizationContext());

		}

		private void OuvrirNouvelInventaireForm(object obj)
		{
			GetProduits();
			FormulaireInventaireVisibility = Visibility.Visible;
		}

		private void TerminerInventaire(object obj)
		{
			if (!VerifierIntegritéInventaire())
				return;
			Inventaire inventaire = new Inventaire
			{
				IsValidated = true,
				DateInventaire = DateTime.Now,
				LigneInventaires = new List<LigneInventaire>()
				
			};

			foreach(ProductInventaireItemViewModel item  in ListeProduits)
			{
				inventaire.LigneInventaires.Add(new LigneInventaire
				{
					QuantiteAvantInventaire = item.ProduitLightDTO.QteEnStock,
					QuantiteApresInventaire = item.QteReelle,
					IdProduit = item.ProduitLightDTO.Id
				});
			}

			Task.Run(async () =>
			{

				return await httpClientService.CreateNewInventaire(inventaire);

			}).ContinueWith(t =>
			{
				if (t.Result == null)
				{
					MessageBox.Show("Une erreur est survenue.");
				}
				else
				{
					MessageBox.Show("Votre inventaire a bien été enregistré.");
					GetInventaireEnCours();
					GetListeInventaireHistorique();
					FormulaireInventaireVisibility = Visibility.Hidden;
					
					//ResetSelections();
					//GetProductsAll();
				}

				//CurrentProduitDTO = null;
				//IsPopUpVisible = Visibility.Collapsed;

			}, TaskScheduler.FromCurrentSynchronizationContext());

		}

		private bool VerifierIntegritéInventaire()
		{
			string list = "Les produits suivants n'ont pas encore été inventoriés :\n\n";
			bool isIntegre = true;
			foreach (var prod in ListeProduits)
			{
				if(!prod.HasBeenModified)
				{
					list += prod.ProduitLightDTO.NomProduit + "\n";
					isIntegre = false;
				}
			}
			list += "\nTraitez tout les produits pour terminer l'inventaire\n";
			if (!isIntegre)
				MessageBox.Show(list, "Gestion d'inventaire");

			return isIntegre;
		}

		private void GetProduits()
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
					var item = new ProductInventaireItemViewModel(produit);
					ListeProduits.Add(item);

				}

			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void GetListeInventaireHistorique()
		{
			ListeInventaireHistorique.Clear();

			Task.Run(async () =>
			{
				return await httpClientService.GetInventaireHistorique();

			})
			.ContinueWith(t =>
			{
				foreach (var inventaireHisto in t.Result)
				{
					var item = new ItemInventaireHistoriqueViewModel(inventaireHisto);
					item.consult += Inventaire_Consult;
					//item.modify += Item_modifyPopup;
					ListeInventaireHistorique.Add(item);
				}

			}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void GetInventaireEnCours()
		{
			InventaireEnCours = new ItemInventaireHistoriqueViewModel(new Inventaire());

			Task.Run(async () =>
			{
				return await httpClientService.GetInventaireEnCours();

			})
			.ContinueWith(t =>
			{

				if(t.Result.Any())
				{
					InventaireEnCours = new ItemInventaireHistoriqueViewModel(t.Result.FirstOrDefault());
					InventaireEnCoursVisibility = Visibility.Visible;
					NoInventaireEnCoursVisibility = Visibility.Hidden;
				}
				else
				{
					InventaireEnCoursVisibility = Visibility.Hidden;
					NoInventaireEnCoursVisibility = Visibility.Visible;
				}
					

			}, TaskScheduler.FromCurrentSynchronizationContext());
		}
	}
}
