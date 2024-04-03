using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel.Factories
{
	public class GestionInventaireViewModelFactory : IViewModelFactory<GestionInventaireViewModel>
	{
		public GestionInventaireViewModel CreateViewModel()
		{
			return new GestionInventaireViewModel();
		}
	}
}
