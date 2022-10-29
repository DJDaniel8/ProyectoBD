using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.Commands.ResidentesViewCommands;

namespace ProyectoBD.ViewModels.ResidentesViewModels
{
    public class CrearResidentesViewModel : ViewModelBase
    {
        public CrearResidentesViewModel()
        {
            GuardarCommand = new GuardarCommand(this);
            CancelarCommand = new CancelarCommand(this);
            Residente = new();
        }
        public ICommand CancelarCommand { get; set; }
        public ICommand GuardarCommand { get; }

        private ResidenteViewModel _Residente;
        public ResidenteViewModel Residente
        {
            get
            {
                return _Residente;
            }
            set
            {
                _Residente = value;
                OnPropertyChanged(nameof(Residente));
            }
        }

        public ResidentesViewModel ResidentesViewModel { get; set; }

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
