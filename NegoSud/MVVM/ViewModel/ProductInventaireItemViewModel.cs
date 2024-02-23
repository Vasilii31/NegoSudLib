using NegoSud.Core;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
	public class ProductInventaireItemViewModel : ViewModelBase
	{
		public ProduitLightDTO ProduitLightDTO { get; set; }

        private int _qteReelle = 0;
        public int QteReelle
        {
            get { return _qteReelle; }
            set { 
                _qteReelle = value;
                OnPropertyChanged(nameof(QteReelle));
            }
        }

		private int _soldeMvt = 0;
		public int SoldeMvt
		{
			get { return _soldeMvt; }
			set
			{
				//if(QteReelle != 0)
				//{
				//	_soldeMvt = ProduitLightDTO.QteEnStock - QteReelle;
				//}
				//else
				_soldeMvt = value;
				OnPropertyChanged(nameof(SoldeMvt));
			}
		}

		public ICommand ResetValuesCommand { get; set; }

		public bool HasBeenModified = false;

		public ProductInventaireItemViewModel(ProduitLightDTO prod)
        {
            ProduitLightDTO = prod;
			ResetValuesCommand = new RelayCommand(ResetValues);
			
			
        }

		

		private void ResetValues(object obj)
		{
			HasBeenModified = false;
			SoldeMvt = 0;
		}
	}
}
