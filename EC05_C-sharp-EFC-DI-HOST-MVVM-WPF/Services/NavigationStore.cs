using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Services
{
    internal class NavigationStore
    {
        public event Action? CurrentViewModelChanged;

        private ObservableObject? _currentViewModel;

        
        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel!;
            set 
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            } 
        }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
