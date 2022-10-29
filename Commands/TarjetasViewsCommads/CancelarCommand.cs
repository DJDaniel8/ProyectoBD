using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.TarjetasViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.TarjetasViewsCommads
{
    public class CancelarCommand : CommandBase
    {
        private CrearTarjetaViewModel _viewModel;
        public CancelarCommand(CrearTarjetaViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.TarjetasViewModel.VerTarjetasViewModel.ControlVisibility = System.Windows.Visibility.Visible;
        }
    }
}
