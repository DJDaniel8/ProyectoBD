using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.Commands.TiposPagosViewsCommands;

namespace ProyectoBD.ViewModels.TiposPagosViewModels
{
    public class CrearTiposPagosViewModel : ViewModelBase
    {
        public CrearTiposPagosViewModel()
        {
            GuardarCommand = new GuardarCommand(this);
            CancelarCommand = new CancelarCommand(this);
            TipoPago = new();
        }
        public ICommand CancelarCommand { get; set; }
        public ICommand GuardarCommand { get; }

        private TipoPagoViewModel _TipoPago;
        public TipoPagoViewModel TipoPago
        {
            get
            {
                return _TipoPago;
            }
            set
            {
                _TipoPago = value;
                OnPropertyChanged(nameof(TipoPago));
            }
        }

        public TiposPagosViewModel TiposPagosViewModel { get; set; }

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
