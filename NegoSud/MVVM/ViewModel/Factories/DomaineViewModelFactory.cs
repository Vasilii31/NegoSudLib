﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegoSud.MVVM.ViewModel.Factories
{
    public class DomaineViewModelFactory : IViewModelFactory<DomaineViewModel>
    {
        public DomaineViewModel CreateViewModel()
        {
            return new DomaineViewModel();
        }
    }

}

