using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.Commands.TiposPagosViewsCommands;

namespace ProyectoBD.ViewModels.TiposPagosViewModels
{
    public class VerTiposPagosViewModel : ViewModelBase
    {
        public VerTiposPagosViewModel()
        {
            _TiposPagos = new();
            CrearCommand = new CrearCommand(this);
            CargarDatos();
        }

        private ObservableCollection<TipoPagoViewModel> _TiposPagos;
        public IEnumerable<TipoPagoViewModel> TiposPagos => _TiposPagos;

        public ICommand CrearCommand { get; }

        public TiposPagosViewModel TiposPagosViewModel { get; set; }

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

        private TipoPagoViewModel _SelectedTipo;
        public TipoPagoViewModel SelectedTipo
        {
            get
            {
                return _SelectedTipo;
            }
            set
            {
                _SelectedTipo = value;
                OnPropertyChanged(nameof(SelectedTipo));
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
