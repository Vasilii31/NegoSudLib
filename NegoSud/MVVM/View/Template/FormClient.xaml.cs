using NegoSud.MVVM.ViewModel;
using System.Windows.Controls;

namespace NegoSud.MVVM.View.Template
{
    /// <summary>
    /// Logique d'interaction pour FormClient.xaml
    /// </summary>
    public partial class FormClient : UserControl
    {
        public FormClient()
        {
            InitializeComponent();
        }

        private void ValiderClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = (VentesViewModel)this.DataContext;
            vm.ValiderClient(sender, e);
        }
        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = (VentesViewModel)this.DataContext;
            vm.FermerClient(sender, e);
        }
    }
}
