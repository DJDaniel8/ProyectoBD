using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.TarjetasViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.ViewModels.TiposPagosViewModels;
using ProyectoBD.Commands.PagosViewsCommands;

namespace ProyectoBD.ViewModels.PagosViewModels
{
    public class CrearPagosViewModel : ViewModelBase
    {
            public CrearPagosViewModel()
            {
                GuardarCommand = new GuardarCommand(this);
                CancelarCommand = new CancelarCommand(this);
                Pago = new();
                _TiposPagos = new();
                CargarDatos();
            }
            public ICommand CancelarCommand { get; set; }
            public ICommand GuardarCommand { get; }

            private ObservableCollection<TipoPagoViewModel> _TiposPagos;
            public IEnumerable<TipoPagoViewModel> TiposPagos => _TiposPagos;

            private PagoViewModel _Pago;
            public PagoViewModel Pago
            {
                get
                {
                    return _Pago;
                }
                set
                {
                    _Pago = value;
                    OnPropertyChanged(nameof(Pago));
                }
            }

            public PagosViewModel PagosViewModel { get; set; }

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

            private TipoPagoViewModel _SelectedTipoPago;
            public TipoPagoViewModel SelectedTipoPago
            {
                get
                {
                    return _SelectedTipoPago;
                }
                set
                {
                    _SelectedTipoPago = value;
                    OnPropertyChanged(nameof(SelectedTipoPago));
                }
            }

            public void CargarDatos()
            {
                _TiposPagos.Clear();
                foreach (var item in TipoPagoDAO.Get())
                {
                    _TiposPagos.Add(item);
                }
            }
        }

}
