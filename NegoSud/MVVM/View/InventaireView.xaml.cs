using NegoSud.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace NegoSud.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour InventaireView.xaml
    /// </summary>
    public partial class InventaireView : UserControl
    {
        public InventaireView()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var vm = (InventaireViewModel)this.DataContext;
            vm.SearchProduits(sender, e);
        }
    }
}
