using ProyectoBD.ViewModels.PagosViewModels;
using ProyectoBD.Views.PagosViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.PagosViewsCommands
{
    public class CrearCommand : CommandBase
    {
        private VerPagosViewModel _viewModel;

        public CrearCommand(VerPagosViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.PagosViewModel.CrearPagosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
            _viewModel.PagosViewModel.CrearPagosViewModel.CargarDatos();
        }
    }
}
