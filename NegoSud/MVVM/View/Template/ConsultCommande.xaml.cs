using NegoSud.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Logique d'interaction pour ConsultCommande.xaml
    /// </summary>
    public partial class ConsultCommande : UserControl
    {
        public ConsultCommande()
        {
            InitializeComponent();
        }

        private void FermerConsult_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = (CommandesHistoriqueViewModel)this.DataContext;
            vm.FermerConsult(sender, e);
        }
    }
}
