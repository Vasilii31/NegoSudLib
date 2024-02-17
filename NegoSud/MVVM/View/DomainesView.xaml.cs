using NegoSud.MVVM.View.Template;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NegoSud.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour Domaines.xaml
    /// </summary>
    public partial class DomainesView : UserControl
    {
        public DomainesView()
        {
            InitializeComponent();

            // Écouter l'événement AjouterButtonClick du bouton Ajouter
            ButtonAjouter.AjouterButtonClick += ButtonAjouter_Click;
            ButtonConsultation.ConsultationButtonClick += ButtonView_Click;
        }

        private void ButtonAjouter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ajout d'un domaine");

        }

        private void ButtonView_Click(object sender, EventArgs e)
        {
            
        }
    }
}
