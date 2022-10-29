using ProyectoBD.ViewModels.ResidentesViewModels;
using ProyectoBD.ViewModels.TrabajadoresViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.ResidentesViewCommands
{
    public class CancelarCommand : CommandBase
    {
        private CrearResidentesViewModel _viewModel;
        public CancelarCommand(CrearResidentesViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.ResidentesViewModel.VerResidentesViewModel.ControlVisibility = System.Windows.Visibility.Visible;
        }
    }
}
