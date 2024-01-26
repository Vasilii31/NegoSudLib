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
    /// Logique d'interaction pour ButtonModifier.xaml
    /// </summary>
    public partial class ButtonModifier : Button
    {
        public static event EventHandler ModifierButtonClick;
        public ButtonModifier()
        {
            InitializeComponent();
        }

        private void ButtonPencil_Click(object sender, RoutedEventArgs e)
        {
            ModifierButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonPencil.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#300117"));
        }

        private void ButtonAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonPencil.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#460A26"));
        }
    }
}
