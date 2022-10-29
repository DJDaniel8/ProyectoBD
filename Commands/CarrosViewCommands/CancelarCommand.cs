using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.CarrosViewCommands
{
    public class CancelarCommand : CommandBase
    {
        private CrearCarrosViewModel _viewModel;
        public CancelarCommand(CrearCarrosViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.CarrosViewModel.VerCarrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
        }
    }
}
