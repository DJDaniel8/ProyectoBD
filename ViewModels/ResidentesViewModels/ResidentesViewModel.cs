using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.ViewModels.ResidentesViewModels
{
    public class ResidentesViewModel : ViewModelBase
    {
        public ResidentesViewModel()
        {
            VerResidentesViewModel = new();
            VerResidentesViewModel.ResidentesViewModel = this;
            CrearResidentesViewModel = new();
            CrearResidentesViewModel.ResidentesViewModel = this;
        }

        public VerResidentesViewModel VerResidentesViewModel { get; set; }
        public CrearResidentesViewModel CrearResidentesViewModel { get; set; }

        private Visibility _ControlVisibility = Visibility.Collapsed;
        public Visibility ControlVisibility
        {
            get
            {
                return _ControlVisibility;
            }
            set
            {
                _ControlVisibility = value;
                OnPropertyChanged(nameof(ControlVisibility));
            }
        }
    }
}
