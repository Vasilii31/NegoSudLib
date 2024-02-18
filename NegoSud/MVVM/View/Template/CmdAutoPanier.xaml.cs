using NegoSud.MVVM.ViewModel;
using System.Windows.Controls;

namespace NegoSud.MVVM.View.Template
{
    /// <summary>
    /// Logique d'interaction pour VentesView.xaml
    /// </summary>
    public partial class CmdAutoPanier : UserControl
    {
        public CmdAutoPanier()
        {
            InitializeComponent();
        }

        private void ValiderPanier_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = (HomeViewModel)this.DataContext;
            vm.ValiderPanier(sender, e);
        }
        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = (HomeViewModel)this.DataContext;
            vm.FermerPanier(sender, e);
        }
    }
}
