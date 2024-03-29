﻿using NegoSud.Core;
using NegoSudLib.DAO;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class ItemInventaireViewModel : MouvementInventaireItem
    {
        public ProduitLightDTO ProduitLightDTO { get; set; }

        public ObservableCollection<TypeMouvement> ListeTypesMouvements { get; set; }

        //private TypeMouvement typeMouvementSelectionne;

        //public TypeMouvement TypeMouvementSelectionne
        //{
        //    get { return typeMouvementSelectionne; }
        //    set
        //    {
        //        if (typeMouvementSelectionne != value)
        //        {
        //            typeMouvementSelectionne = value;
        //            OnPropertyChanged(nameof(TypeMouvement));
        //        }
        //    }
        //}
        private int _qteChangementStock = 0;
        public int QteChangementStock
        {
            get { return _qteChangementStock; }
            set
            {
                if (_qteChangementStock != value)
                {
                    _qteChangementStock = value;
                    OnPropertyChanged(nameof(QteChangementStock));
                }
            }
        }

        public string SoldeStock { get { return "Solde Stock : " + ProduitLightDTO.QteEnStock + " + " + QteChangementStock + " = " + (ProduitLightDTO.QteEnStock + QteChangementStock).ToString(); } }

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
        //public int QteStock { get; set; }
        //public int PrixC { get; set; }
        public ItemInventaireViewModel(ProduitLightDTO produit)
        {
            //ListeTypesMouvements = l;
            ProduitLightDTO = produit;
            //PrixU = ProduitLightDTO.QteEnStock;
            //PrixC = ProduitLightDTO.QteCarton + " bouteilles " + ProduitLightDTO.PrixVenteCarton + " €";
            CMD_AjoutPanier = new RelayCommand(AjoutPanier);
            CMD_VoirPdt = new RelayCommand(VoirPDT);
            CMD_PlusU = new RelayCommand(PlusU);
            CMD_MoinsU = new RelayCommand(MoinsU);
            CMD_PlusC = new RelayCommand(PlusC);
            CMD_MoinsC = new RelayCommand(MoinsC);
        }

        public ItemInventaireViewModel(ItemInventaireViewModel i)
        {
            ListeTypesMouvements = i.ListeTypesMouvements;
            ProduitLightDTO = i.ProduitLightDTO;
            QteChangementStock = i.QteChangementStock;
            //TypeMouvementSelectionne = i.TypeMouvementSelectionne;
            DeleteFromListCommand = new RelayCommand(DeleteFromList);



        }

        private void DeleteFromList(object obj)
        {
            base.invoke_DeleteFromListe(this);
        }

        public void ResetItem()
        {
            //this.TypeMouvementSelectionne = null;
            this.QteChangementStock = 0;
        }

        public void AjoutPanier(object obk)
        {
            base.invoke_AjoutPanier(this);
        }
        public void VoirPDT(object obk)
        {
            base.invoke_VoirPDT(this);
        }
        public void PlusU(object obk)
        {
            base.invoke_PlusU(this);
        }
        public void MoinsU(object obk)
        {
            base.invoke_MoinsU(this);
        }
        public void PlusC(object obk)
        {
            base.invoke_PlusC(this);
        }
        public void MoinsC(object obk)
        {
            base.invoke_MoinsC(this);
        }
    }
}
