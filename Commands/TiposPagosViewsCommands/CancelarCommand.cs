using ProyectoBD.ViewModels.CarrosViewModels;
using ProyectoBD.ViewModels.TiposPagosViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.TiposPagosViewsCommands
{
    public class CancelarCommand : CommandBase
    {
        private CrearTiposPagosViewModel _viewModel;
        public CancelarCommand(CrearTiposPagosViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.TiposPagosViewModel.VerTiposPagosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
        }
    }
}
