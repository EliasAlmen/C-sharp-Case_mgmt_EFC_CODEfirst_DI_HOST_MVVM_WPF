using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Helpers;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;

        public ICommand NavigateToCreateCase { get; }
        public ICommand NavigateToListCase { get; }
        public ICommand NavigateToHome { get; }

        [RelayCommand]
        private void Exit()
            => Application.Current.Shutdown();

        public MainViewModel(NavigationStore navigationStore, CaseService caseService)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateToCreateCase = new NavigateCommand<CreateCaseViewModel>(navigationStore, () => new CreateCaseViewModel(_navigationStore));
            NavigateToListCase = new NavigateCommand<ListCaseViewModel>(navigationStore, () => new ListCaseViewModel(_navigationStore));
            NavigateToHome = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(_navigationStore));
        }


        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }

}
