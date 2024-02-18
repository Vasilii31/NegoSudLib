using NegoSud.MVVM.ViewModel;
using System.Windows.Controls;

namespace NegoSud.MVVM.View.Template
{
    /// <summary>
    /// Logique d'interaction pour FormClient.xaml
    /// </summary>
    public partial class FormCategorie : UserControl
    {
        public FormCategorie()
        {
            InitializeComponent();
        }

        private void ValiderClient_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = (CategoriesViewModel)this.DataContext;
            vm.ValiderCat(sender, e);
        }
        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = (CategoriesViewModel)this.DataContext;
            vm.Retour(sender, e);
        }
    }
}
