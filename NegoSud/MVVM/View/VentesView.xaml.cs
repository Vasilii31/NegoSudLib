using NegoSud.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace NegoSud.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour VentesView.xaml
    /// </summary>
    public partial class VentesView : UserControl
    {
        public VentesView()
        {
            InitializeComponent();
        }

        private void VoirPanier_Click(object sender, RoutedEventArgs e)
        {
            var vm = (VentesViewModel)this.DataContext;
            vm.VoirPanier(sender, e);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var vm = (VentesViewModel)this.DataContext;
            vm.SearchProduits(sender, e);
        }
    }
}
