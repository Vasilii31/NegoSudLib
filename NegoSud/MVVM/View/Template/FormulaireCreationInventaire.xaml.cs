using NegoSud.MVVM.ViewModel;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NegoSud.MVVM.View.Template
{
	/// <summary>
	/// Logique d'interaction pour FormulaireCreationInventaire.xaml
	/// </summary>
	public partial class FormulaireCreationInventaire : UserControl
	{
		private readonly Regex _regex = new Regex("[^0-9.-]+");
		public FormulaireCreationInventaire()
		{
			InitializeComponent();
		}

		private void textChangedEventHandler(object sender, TextChangedEventArgs args)
		{

			var item = (TextBox)sender;

			ProductInventaireItemViewModel product = (ProductInventaireItemViewModel)item.DataContext;

			if (_regex.IsMatch(item.Text) || item.Text == "")
			{
				product.SoldeMvt = 0;
				product.QteReelle = 0;
				return;
			}

		
			product.QteReelle = Int32.Parse(item.Text);
			//if (product.QteReelle != 0)
			//{
			product.SoldeMvt = product.QteReelle - product.ProduitLightDTO.QteEnStock;
			product.HasBeenModified = true;
			//}
			//else
			//{
			//	product.SoldeMvt = 0;
			//}
		}
	}
}
