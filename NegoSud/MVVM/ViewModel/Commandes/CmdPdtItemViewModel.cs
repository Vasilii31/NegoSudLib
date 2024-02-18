using NegoSud.Core;
using NegoSudLib.DTO.Read;
using System.Windows;

namespace NegoSud.MVVM.ViewModel
{
    public class CmdPdtItemViewModel : VenteItem
    {
        public ProduitLightDTO ProduitLightDTO { get; set; }

        private int _qteUnite;

        public int QteUnite
        {
            get { return _qteUnite; }
            set
            {
                if (_qteUnite != value)
                {
                    _qteUnite = value;
                    OnPropertyChanged(nameof(QteUnite));
                }
            }
        }
        private int _qteCarton;

        public int QteCarton
        {
            get { return _qteCarton; }
            set
            {
                if (_qteCarton != value)
                {
                    _qteCarton = value;
                    OnPropertyChanged(nameof(QteCarton));
                }
            }
        }

        private Visibility _ajoutVisible = Visibility.Collapsed;

        public Visibility AjoutVisible
        {
            get { return _ajoutVisible; }
            set
            {
                if (_ajoutVisible != value)
                {
                    _ajoutVisible = value;
                    OnPropertyChanged(nameof(AjoutVisible));
                }
            }
        }
        public string PrixU { get; set; }
        public string PrixC { get; set; }
        public CmdPdtItemViewModel(ProduitLightDTO produit)
        {
            ProduitLightDTO = produit;
            PrixU = ProduitLightDTO.PrixAchat + " €";
            PrixC = ProduitLightDTO.QteCarton + " bouteilles " + ProduitLightDTO.PrixAchatCarton + " €";
            CMD_AjoutPanier = new RelayCommand(AjoutPanier);
            CMD_VoirPdt = new RelayCommand(VoirPDT);
            CMD_PlusU = new RelayCommand(PlusU);
            CMD_MoinsU = new RelayCommand(MoinsU);
            CMD_PlusC = new RelayCommand(PlusC);
            CMD_MoinsC = new RelayCommand(MoinsC);
        }

        public void AjoutPanier(object obk)
        {
            invoke_AjoutPanier(this);
        }
        public void VoirPDT(object obk)
        {
            invoke_VoirPDT(this);
        }
        public void PlusU(object obk)
        {
            invoke_PlusU(this);
        }
        public void MoinsU(object obk)
        {
            invoke_MoinsU(this);
        }
        public void PlusC(object obk)
        {
            invoke_PlusC(this);
        }
        public void MoinsC(object obk)
        {
            invoke_MoinsC(this);
        }

    }
}
