using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.UseCases.Interfaces;
using Contacts.Views_Mvvm;
using System.Diagnostics;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private Contact contact;
        private readonly IViewContactUseCase _viewContactUseCase;
        private readonly IEditContactUseCase _editContactUseCase;
        private readonly IAddContactUseCase _addContactUseCase;

        public bool IsNameProvided { get; set; }
        public bool IsEmailProvided { get; set; }
        public bool IsEmailFormatValid {get; set; }

        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        public ContactViewModel(
            IViewContactUseCase viewContactUseCase, 
            IEditContactUseCase editContactUseCase,
            IAddContactUseCase addContactUseCase)
        {
            Contact = new Contact();
            _viewContactUseCase = viewContactUseCase;
            _editContactUseCase = editContactUseCase;
            _addContactUseCase = addContactUseCase;
        }

        public async Task LoadContact(Guid id)
        {
            Contact = await _viewContactUseCase.ExecuteAsync(id);
        }

        [RelayCommand]
        public async Task GotoEditContact(Guid contactId)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage_Mvvm_Page)}?id={contactId}");            
        }

        [RelayCommand]
        public async Task EditContact()
        {
            if (await ValidateContact())
            {
                await _editContactUseCase.ExecuteAsync(Contact.Id);
                await Shell.Current.GoToAsync($"{nameof(Contacts_Mvvm_Page)}");
            }
        }

        [RelayCommand]
        public async Task AddContact()
        {
            if (await ValidateContact())
            {
                await _addContactUseCase.ExecuteAsync(Contact);
                await Shell.Current.GoToAsync($"{nameof(Contacts_Mvvm_Page)}");
            }            
        }

        [RelayCommand]
        public async Task BackToContacts()
        {          
            await Shell.Current.GoToAsync($"{nameof(Contacts_Mvvm_Page)}");  
        }

        private async Task<bool> ValidateContact()
        {
            if (!this.IsNameProvided)
            {
                await Application.Current!.MainPage!.DisplayAlert("Error", "Name is required", "OK");
                return false;
            }

            if (!this.IsEmailProvided)
            {
                await Application.Current!.MainPage!.DisplayAlert("Error", "Email is required", "OK");
                return false;
            }

            if (!this.IsEmailFormatValid)
            {
                await Application.Current!.MainPage!.DisplayAlert("Error", "Email format is invalid", "OK");
                return false;
            }

            return true;
        }   
    }
}
