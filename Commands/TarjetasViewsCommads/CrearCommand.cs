using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.TarjetasViewModels;
using ProyectoBD.Views.TarjetasViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.TarjetasViewsCommads
{
    public class CrearCommand : CommandBase
    {
        private VerTarjetasViewModel _viewModel;

        public CrearCommand(VerTarjetasViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.TarjetasViewModel.CrearTarjetaViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.TarjetasViewModel.CrearTarjetaViewModel.CargarDatos();
        }
    }
}
