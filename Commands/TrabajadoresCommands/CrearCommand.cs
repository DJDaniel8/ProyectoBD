using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.TrabajadoresCommands
{
    public class CrearCommand : CommandBase
    {

        private VerEmpleadosViewModel _viewModel;

        public CrearCommand(VerEmpleadosViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.TrabajadoresViewModel.CrearEmpleadosViewModel.ControlVisibility = System.Windows.Visibility.Visible; 
        }
    }
}
