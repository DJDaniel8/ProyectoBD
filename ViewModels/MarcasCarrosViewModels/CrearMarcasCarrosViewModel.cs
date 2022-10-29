using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.Commands.MarcasCarrosCommands;

namespace ProyectoBD.ViewModels.MarcasCarrosViewModels
{
    public class CrearMarcasCarrosViewModel : ViewModelBase
    {
        public CrearMarcasCarrosViewModel()
        {
            GuardarCommand = new GuardarCommand(this);
            CancelarCommand = new CancelarCommand(this);
            MarcaCarro = new();
        }
        public ICommand CancelarCommand { get; set; }
        public ICommand GuardarCommand { get; }

        private MarcaCarroViewModel _MarcaCarro;
        public MarcaCarroViewModel MarcaCarro
        {
            get
            {
                return _MarcaCarro;
            }
            set
            {
                _MarcaCarro = value;
                OnPropertyChanged(nameof(MarcaCarro));
            }
        }

        public MarcasCarrosViewModel MarcasCarrosViewModel { get; set; }

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
