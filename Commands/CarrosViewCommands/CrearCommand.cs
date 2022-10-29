using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.CarrosViewCommands
{
    public class CrearCommand : CommandBase
    {
        private VerCarrosViewModel _viewModel;

        public CrearCommand(VerCarrosViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.CarrosViewModel.CrearCarrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.CarrosViewModel.CrearCarrosViewModel.CargarDatos();
        }
    }
}
