using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.TrabajadoresCommands
{
    public class CancelarCommand : CommandBase
    {
        private CrearEmpleadosViewModel _viewModel;
        public CancelarCommand(CrearEmpleadosViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.TrabajadoresViewModel.VerEmpleadosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
        }
    }
}
