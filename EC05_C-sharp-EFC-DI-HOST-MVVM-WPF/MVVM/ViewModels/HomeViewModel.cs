using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Helpers;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.ViewModels
{
    internal partial class HomeViewModel : ObservableObject
    {
        private NavigationStore _navigationStore;


        public ICommand NavigateToCreateCase { get; }
        public ICommand NavigateToListCase { get; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            NavigateToCreateCase = new NavigateCommand<CreateCaseViewModel>(navigationStore, () => new CreateCaseViewModel(_navigationStore));
            NavigateToListCase = new NavigateCommand<ListCaseViewModel>(navigationStore, () => new ListCaseViewModel(_navigationStore));
        }
    }
}
