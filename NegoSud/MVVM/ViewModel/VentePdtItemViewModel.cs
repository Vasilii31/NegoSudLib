using NegoSud.Core;
using NegoSudLib.DTO.Read;

namespace NegoSud.MVVM.ViewModel
{
    public class VentePdtItemViewModel : VenteItem
    {
        public ProduitLightDTO ProduitLightDTO { get; set; }

        public int QteUnite { get; set; }
        public int QteCarton { get; set; }
        public string PrixU { get; set; }
        public string PrixC { get; set; }
        public VentePdtItemViewModel(ProduitLightDTO produit)
        {
            ProduitLightDTO = produit;
            PrixU = ProduitLightDTO.PrixVente + " €";
            PrixC = ProduitLightDTO.QteCarton + " bouteilles " + ProduitLightDTO.PrixVenteCarton + " €";
            CMD_AjoutPanier = new RelayCommand(ajoutPanier);
            CMD_VoirPdt = new RelayCommand(voirPDT);
            CMD_plusU = new RelayCommand(plusU);
            CMD_moinsU = new RelayCommand(MoinsU);
            CMD_plusC = new RelayCommand(plusC);
            CMD_moinsC = new RelayCommand(moinsC);
        }

        public void ajoutPanier(object obk)
        {
            base.invoke_AjoutPanier(this);
        }
        public void voirPDT(object obk)
        {
            base.invoke_voirPDT(this);
        }
        public void plusU(object obk)
        {
            base.invoke_plusU(this);
        }
        public void MoinsU(object obk)
        {
            base.invoke_moinsU(this);
        }
        public void plusC(object obk)
        {
            base.invoke_plusC(this);
        }
        public void moinsC(object obk)
        {
            base.invoke_moinsC(this);
        }

    }
}
