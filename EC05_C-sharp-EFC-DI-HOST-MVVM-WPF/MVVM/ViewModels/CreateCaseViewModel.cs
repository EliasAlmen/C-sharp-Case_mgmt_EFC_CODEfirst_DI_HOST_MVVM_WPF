﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    internal partial class CreateCaseViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;


        public ICommand NavigateToHome { get; }


        public CreateCaseViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            NavigateToHome = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(_navigationStore));
        }
    }
}
