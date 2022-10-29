using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.TarjetasViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.Commands.PagosViewsCommands;

namespace ProyectoBD.ViewModels.PagosViewModels
{
    public class VerPagosViewModel : ViewModelBase
    {
        public VerPagosViewModel()
        {
            _Pagos = new();
            CrearCommand = new CrearCommand(this);
            CargarDatos();
        }

        private ObservableCollection<PagoViewModel> _Pagos;
        public IEnumerable<PagoViewModel> Pagos => _Pagos;

        public ICommand CrearCommand { get; }

        public PagosViewModel PagosViewModel { get; set; }

        private Visibility _ControlVisibility = Visibility.Visible;
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

        private PagoViewModel _SelectedPago;
        public PagoViewModel SelectedPago
        {
            get
            {
                return _SelectedPago;
            }
            set
            {
                _SelectedPago = value;
                OnPropertyChanged(nameof(SelectedPago));
            }
        }

        public void CargarDatos()
        {
            _Pagos.Clear();
            foreach (var item in PagoDAO.Get())
            {
                _Pagos.Add(item);
            }
        }
    }
}
