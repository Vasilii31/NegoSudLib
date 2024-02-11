using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NegoSud.MVVM.View.Template
{
    /// <summary>
    /// Logique d'interaction pour ButtonAjouter.xaml
    /// </summary>
    public partial class ButtonNormal : Button
    {
        //evenement personalisé
        public static event EventHandler NormalButtonClick;

        public ButtonNormal()
        {
            InitializeComponent();
        }

        private void ButtonNormal_Click(object sender, RoutedEventArgs e)
        {

            NormalButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonNorm.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#300117"));
        }

        private void ButtonAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonNorm.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#460A26"));
        }
    }


}
