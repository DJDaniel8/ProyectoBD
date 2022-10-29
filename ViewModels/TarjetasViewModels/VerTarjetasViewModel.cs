using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.CarrosViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.Commands.TarjetasViewsCommads;

namespace ProyectoBD.ViewModels.TarjetasViewModels
{
    public class VerTarjetasViewModel : ViewModelBase
    {
        public VerTarjetasViewModel()
        {
            _Tarjetas = new();
            CrearCommand = new CrearCommand(this);
            CargarDatos();
        }

        private ObservableCollection<TarjetaViewModel> _Tarjetas;
        public IEnumerable<TarjetaViewModel> Tarjetas => _Tarjetas;

        public ICommand CrearCommand { get; }

        public TarjetasViewModel TarjetasViewModel { get; set; }

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

        private TarjetaViewModel _SelectedTarjeta;
        public TarjetaViewModel SelectedTarjeta
        {
            get
            {
                return _SelectedTarjeta;
            }
            set
            {
                _SelectedTarjeta = value;
                OnPropertyChanged(nameof(SelectedTarjeta));
            }
        }

        public void CargarDatos()
        {
            _Tarjetas.Clear();
            foreach (var item in TarjetaDAO.Get())
            {
                _Tarjetas.Add(item);
            }
        }
    }
}
