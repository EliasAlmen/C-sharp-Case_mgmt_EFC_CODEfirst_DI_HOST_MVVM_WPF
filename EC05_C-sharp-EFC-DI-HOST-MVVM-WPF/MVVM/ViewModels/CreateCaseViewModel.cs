using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Helpers;
using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Services;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        [ObservableProperty]
        private string firstName = string.Empty;

        [ObservableProperty]
        private string tb_firstName = "First name";

        [ObservableProperty]
        private string lastName = string.Empty;

        [ObservableProperty]
        private string tb_lastName = "Last name";

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string tb_email = "Email";

        [ObservableProperty]
        private string phoneNumber = string.Empty;

        [ObservableProperty]
        private string tb_phoneNumber = "Phone number";

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private string tb_description = "Case description";

        [ObservableProperty]
        private string tb_Description_text = "Max 500 characters";

        [ObservableProperty]
        private string tb_severity = "Severity level";

        [ObservableProperty]
        private string tb_status = "Case status";

        // Add contact to list. If-statement to check that all fields are filled in.
        [RelayCommand]
        private void Add()
        {
            if (
                FirstName == string.Empty || 
                LastName == string.Empty || 
                Email == string.Empty || 
                PhoneNumber == string.Empty || 
                Description == string.Empty

                )
            {
                MessageBox.Show("Please fill in all text fields.");
            }
            else
            {
                // Takes input and returns Uppercase string. Nice to have.
                var FirstNameUpper = InputHelper.ToUpperFirstLetter(FirstName);
                var LastNameUpper = InputHelper.ToUpperFirstLetter(LastName);
                var EmailUpper = InputHelper.ToUpperFirstLetter(Email);

                //fileService.AddToList(new ContactModel { FirstName = FirstNameUpper, LastName = LastNameUpper, Email = EmailUpper, PhoneNumber = PhoneNumber, Address = AddressUpper });

                // Clear fields after contact was added.
                FirstName = string.Empty;
                LastName = string.Empty;
                Email = string.Empty;
                PhoneNumber = string.Empty;
                Description = "Max 500 characters";

                // Confirmation MessageBox
                MessageBox.Show($"{FirstNameUpper}\n{LastNameUpper}\n\nAdded.");

            }
        }
    }
}
