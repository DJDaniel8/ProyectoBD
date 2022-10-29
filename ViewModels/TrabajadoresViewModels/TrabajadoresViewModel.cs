using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoBD.ViewModels.TrabajadoresViewModels
{
    public class TrabajadoresViewModel : ViewModelBase
    {
        public TrabajadoresViewModel()
        {
            CrearEmpleadosViewModel = new();
            CrearEmpleadosViewModel.TrabajadoresViewModel = this;
            VerEmpleadosViewModel = new();
            VerEmpleadosViewModel.TrabajadoresViewModel = this;
        }

        public CrearEmpleadosViewModel CrearEmpleadosViewModel { get; set; }
        public VerEmpleadosViewModel VerEmpleadosViewModel { get; set; }

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
