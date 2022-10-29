using ProyectoBD.Commands.TrabajadoresCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProyectoBD.ViewModels.TrabajadoresViewModels
{
    public class CrearEmpleadosViewModel : ViewModelBase
    {

        public CrearEmpleadosViewModel()
        {
            GuardarCommand = new GuardarCommand(this);
            CancelarCommand = new CancelarCommand(this);
            Empleado = new();
        }
        public ICommand CancelarCommand { get; set; }
        public ICommand GuardarCommand { get; }

        private EmpleadosViewModel _Empleado;
        public EmpleadosViewModel Empleado
        {
            get
            {
                return _Empleado;
            }
            set
            {
                _Empleado = value;
                OnPropertyChanged(nameof(Empleado));
            }
        }
        public TrabajadoresViewModel TrabajadoresViewModel { get; set; }

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
