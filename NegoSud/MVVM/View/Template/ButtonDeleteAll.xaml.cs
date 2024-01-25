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
    /// Logique d'interaction pour ButtonDelete.xaml
    /// </summary>
    public partial class ButtonDeleteAll : UserControl
    {
        public static event EventHandler DeleteAllButtonClick;
        public ButtonDeleteAll()
        {
            InitializeComponent();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteAllButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonDelete.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#300117"));
        }

        private void ButtonAdd_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonDelete.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#460A26"));
        }
    }
}
