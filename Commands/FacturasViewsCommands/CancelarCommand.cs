using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.FacturasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.FacturasViewsCommands
{
    public class CancelarCommand : CommandBase
    {
        private CrearFacturasViewModel _viewModel;
        public CancelarCommand(CrearFacturasViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.FacturasViewModel.VerFacturasViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel._Detalles.Clear();
        }
    }
}
