using NegoSud.MVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace NegoSud.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour VentesView.xaml
    /// </summary>
    public partial class CmdView : UserControl
    {
        public CmdView()
        {
            InitializeComponent();
        }

        private void VoirPanier_Click(object sender, RoutedEventArgs e)
        {
            var vm = (CmdViewModel)this.DataContext;
            vm.VoirPanier(sender, e);
        }
    }
}
