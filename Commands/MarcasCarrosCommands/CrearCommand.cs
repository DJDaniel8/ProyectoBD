using ProyectoBD.ViewModels.MarcasCarrosViewModels;
using ProyectoBD.ViewModels.ResidentesViewModels;
using ProyectoBD.Views.MarcasCarrosViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBD.Commands.MarcasCarrosCommands
{
    public class CrearCommand : CommandBase
    {
        private VerMarcasCarrosViewModel _viewModel;

        public CrearCommand(VerMarcasCarrosViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
            _viewModel.MarcasCarrosViewModel.CrearMarcasCarrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
        }
    }
}
