using ProyectoBD.ViewModels.PagosViewModels;
using ProyectoBD.ViewModels.ResidentesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.PagosViewsCommands
{
    public class CancelarCommand : CommandBase
    {
        private CrearPagosViewModel _viewModel;
        public CancelarCommand(CrearPagosViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.PagosViewModel.VerPagosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
        }
    }
}
