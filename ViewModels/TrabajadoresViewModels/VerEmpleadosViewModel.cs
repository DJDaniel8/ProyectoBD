using ProyectoBD.Commands.TrabajadoresCommands;
using ProyectoBD.Services.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProyectoBD.ViewModels.TrabajadoresViewModels
{
    public class VerEmpleadosViewModel : ViewModelBase
    {
        public VerEmpleadosViewModel()
        {
            _Empleados = new();
            CrearCommand = new CrearCommand(this);
            CargarDatos();
        }

        private ObservableCollection<EmpleadosViewModel> _Empleados;
        public IEnumerable<EmpleadosViewModel> Empleados => _Empleados;

        public ICommand CrearCommand { get;}

        public TrabajadoresViewModel TrabajadoresViewModel { get; set; }

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

        private EmpleadosViewModel _SelectedEmpleado;
        public EmpleadosViewModel SelectedEmpledado
        {
            get
            {
                return _SelectedEmpleado;
            }
            set
            {
                _SelectedEmpleado = value;
                OnPropertyChanged(nameof(SelectedEmpledado));
            }
        }

        public void CargarDatos()
        {
            _Empleados.Clear();
            foreach (var item in EmpleadoDAO.Get())
            {
                _Empleados.Add(item);
            }
        }
    }
}
