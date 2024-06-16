using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Models;
using Contacts.UseCases.Interfaces;
using Contacts.Views_Mvvm;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private Contact contact;
        private readonly IViewContactUseCase _viewContactUseCase;
        
        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        public ContactViewModel(IViewContactUseCase viewContactUseCase) 
        {
            Contact = new Contact();
            _viewContactUseCase = viewContactUseCase;            
        }

        public async Task LoadContact(Guid id)
        {               
            Contact = await _viewContactUseCase.ExecuteAsync(id);            
        }

        [RelayCommand]
        public async Task EditContact(Guid contactId)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage_Mvvm_Page)}?Id={contactId}");
            //await _editContactUseCase.ExecuteAsync(contactId);
            //await LoadContactsAsync();
        }

        [RelayCommand]
        public async Task GotoEditContact(Guid contactId)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage_Mvvm_Page)}?id={contactId}");
            //await _editContactUseCase.ExecuteAsync(contactId);
            //await LoadContactsAsync();
        }

        //[RelayCommand]
        //public void SaveContact()
        //{
        //    ContactRepository.AddContact(Contact);
        //}
    }
}
