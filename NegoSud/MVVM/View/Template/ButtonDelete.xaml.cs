using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NegoSud.MVVM.View.Template
{
    /// <summary>
    /// Logique d'interaction pour ButtonDelete.xaml
    /// </summary>
    public partial class ButtonDelete : Button
    {
        public static event EventHandler DeleteButtonClick;
        public ButtonDelete()
        {
            InitializeComponent();
        }

        private void ButtonLess_Click(object sender, RoutedEventArgs e)
        {
            DeleteButtonClick?.Invoke(this, EventArgs.Empty);
        }
        private void ButtonAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonLess.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#300117"));
        }

        private void ButtonAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonLess.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#460A26"));
        }
    }
}
