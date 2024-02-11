using NegoSud.Core;
using NegoSudLib.DTO.Read;

namespace NegoSud.MVVM.ViewModel
{
    public class PanierItemViewModel : PanierItem
    {
        public DetailMouvementStockDTO DetailMouvementStockDTO { get; set; }

        private string _qte;

        public string Qte
        {
            get { return _qte; }
            set
            {
                if (_qte != value)
                {
                    _qte = value;
                    OnPropertyChanged(nameof(Qte));
                }
            }
        }
        private float _sousTotal;

        public float SousTotal
        {
            get { return _sousTotal; }
            set
            {
                if (_sousTotal != value)
                {
                    _sousTotal = value;
                    OnPropertyChanged(nameof(SousTotal));
                }
            }
        }


        public PanierItemViewModel(DetailMouvementStockDTO DtMvtStock)
        {
            DetailMouvementStockDTO = DtMvtStock;
            MajQte();
            CMD_SupprimerDuPanier = new RelayCommand(SupprimerDuPanier);
        }

        public void SupprimerDuPanier(object obk)
        {
            base.invoke_SupprimerDuPanier(this);
        }

        public void MajQte()
        {
            if (DetailMouvementStockDTO.AuCarton)
            {
                Qte = DetailMouvementStockDTO.QteProduit + " carton(s)";
                SousTotal = DetailMouvementStockDTO.QteProduit * DetailMouvementStockDTO.Produit.PrixVenteCarton;
            }
            else
            {
                Qte = DetailMouvementStockDTO.QteProduit + " bouteille(s)";
                SousTotal = DetailMouvementStockDTO.QteProduit * DetailMouvementStockDTO.Produit.PrixVente;
            }
        }

    }
}
