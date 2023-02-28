using CommunityToolkit.Mvvm.ComponentModel;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }

}
