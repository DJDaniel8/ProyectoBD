using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.TiposPagosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.TiposPagosViewsCommands
{
    public class CrearCommand : CommandBase
    {
        private VerTiposPagosViewModel _viewModel;

        public CrearCommand(VerTiposPagosViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.TiposPagosViewModel.CrearTiposPagosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
        }
    }
}
