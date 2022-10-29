using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.MarcasCarrosCommands
{
    public class CancelarCommand : CommandBase
    {
        private CrearMarcasCarrosViewModel _viewModel;
        public CancelarCommand(CrearMarcasCarrosViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.MarcasCarrosViewModel.VerMarcasCarrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
        }
    }
}
