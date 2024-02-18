using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NegoSud.MVVM.View.Template
{
    /// <summary>
    /// Logique d'interaction pour ButtonAjouter.xaml
    /// </summary>
    public partial class ButtonAjouterAuPanier : Button
    {
        //evenement personalisé
        public static event EventHandler AjouterButtonClick;

        public ButtonAjouterAuPanier()
        {
            InitializeComponent();
        }

        private void ButtonAddToCart_Click(object sender, RoutedEventArgs e)
        {
            AjouterButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonAddToCart.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#300117"));
        }

        private void ButtonAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonAddToCart.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#460A26"));
        }
    }


}
