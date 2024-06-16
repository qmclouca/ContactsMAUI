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

        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        public ContactViewModel(IViewContactUseCase viewContactUseCase, IEditContactUseCase editContactUseCase)
        {
            Contact = new Contact();
            _viewContactUseCase = viewContactUseCase;
            _editContactUseCase = editContactUseCase;
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
            await _editContactUseCase.ExecuteAsync(Contact.Id);           
            await Shell.Current.GoToAsync($"{nameof(Contacts_Mvvm_Page)}");            
        }

        [RelayCommand]
        public async Task BackToContacts()
        {          
            await Shell.Current.GoToAsync($"{nameof(Contacts_Mvvm_Page)}");  
        }
    }
}
