using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.FacturasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.FacturasViewsCommands
{
    public class CrearCommand : CommandBase
    {
        private VerFacturasViewModel _viewModel;

        public CrearCommand(VerFacturasViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.FacturasViewModel.CrearFacturasViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.FacturasViewModel.CrearFacturasViewModel.CargarDatos();
        }
    }
}
