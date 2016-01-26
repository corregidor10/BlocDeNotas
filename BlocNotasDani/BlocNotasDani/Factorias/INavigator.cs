using System;
using System.Threading.Tasks;
using BlocNotasDani.ViewModel.Base;

namespace BlocNotasDani.Factorias
{
    public interface INavigator
    {
        Task<IViewModel> PopAsync();

        Task<IViewModel> PopModalAsync();

        Task PopToRootAsync();

        Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel;

        Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel;

        Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;
    }
}