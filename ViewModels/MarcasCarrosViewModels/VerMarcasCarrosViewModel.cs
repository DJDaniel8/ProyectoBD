using ProyectoBD.Services.DAO;
using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ProyectoBD.Commands.MarcasCarrosCommands;

namespace ProyectoBD.ViewModels.MarcasCarrosViewModels
{
    public class VerMarcasCarrosViewModel : ViewModelBase
    {
        public VerMarcasCarrosViewModel()
        {
            _Marcas = new();
            CrearCommand = new CrearCommand(this);
            CargarDatos();
        }

        private ObservableCollection<MarcaCarroViewModel> _Marcas;
        public IEnumerable<MarcaCarroViewModel> Marcas => _Marcas;

        public ICommand CrearCommand { get; }

        public MarcasCarrosViewModel MarcasCarrosViewModel { get; set; }

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

        private MarcaCarroViewModel _SelectedMarca;
        public MarcaCarroViewModel SelectedMarca
        {
            get
            {
                return _SelectedMarca;
            }
            set
            {
                _SelectedMarca = value;
                OnPropertyChanged(nameof(SelectedMarca));
            }
        }

        public void CargarDatos()
        {
            _Marcas.Clear();
            foreach (var item in MarcaCarroDAO.Get())
            {
                _Marcas.Add(item);
            }
        }
    }
}
