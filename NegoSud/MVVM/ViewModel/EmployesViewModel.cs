using MaterialDesignThemes.Wpf;
using NegoSud.Core;
using NegoSud.MVVM.View.Template;
using NegoSud.Services;
using NegoSudLib.DTO;
using NegoSudLib.DTO.Read;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace NegoSud.MVVM.ViewModel
{
    public class EmployesViewModel : ViewModelBase
    {
        private EmployeDTO _currentEmployeDTO;
        public EmployeDTO CurrentEmployeDTO
        {
            get { return _currentEmployeDTO; }
            set
            {
                _currentEmployeDTO = value;
                OnPropertyChanged(nameof(CurrentEmployeDTO));
            }
        }
        public ObservableCollection<EmployeItemViewModel> ListeEmployes { get; set; } = new();
        public int NombreEmployes { get => ListeEmployes.Count(); }

        public Visibility _isPopUpVisible = Visibility.Collapsed;

        public Visibility IsPopUpVisible
        {
            get { return _isPopUpVisible; }
            set
            {
                _isPopUpVisible = value;
                OnPropertyChanged(nameof(IsPopUpVisible));

            }
        }

        public ICommand ValidateFormCommand { get; set; }
        public ICommand ExitFormCommand { get; set; }

        public EmployesViewModel()
        {
            GetEmployes();
            ValidateFormCommand = new RelayCommand(ValidateForm);
            ExitFormCommand = new RelayCommand(ExitForm);
        }

        private void ExitForm(object obj)
        {
            CurrentEmployeDTO = null;
            IsPopUpVisible = Visibility.Collapsed;
        }

        private void ValidateForm(object obj)
        {
            var ob = CurrentEmployeDTO;
            Task.Run(async () =>
            {
                return await httpClientService.GetEmployes();

            });
            return;
        }

        private void GetEmployes()
        {
            ListeEmployes.Clear();
            OnPropertyChanged(nameof(NombreEmployes));

            Task.Run(async () =>
            {
                return await httpClientService.GetEmployes();

            })
            .ContinueWith(t =>
            {
                foreach (var employe in t.Result)
                {
                    var item = new EmployeItemViewModel(employe);
                    item.deleted += Item_deleted;
                    item.modify += Item_modifyPopup;
                    ListeEmployes.Add(item);

                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void Item_modifyPopup(object? sender, EventArgs e)
        {
            if (IsPopUpVisible == Visibility.Collapsed)
            {
                IsPopUpVisible = Visibility.Visible;
                if (sender != null)
                {
                    CurrentEmployeDTO = (EmployeDTO)sender;
                }

            }
        }

        private void Item_deleted(object? sender, EventArgs e)
        {
            EmployeItemViewModel item = (EmployeItemViewModel)sender;
            ListeEmployes.Remove(item);
        }
    }
}
