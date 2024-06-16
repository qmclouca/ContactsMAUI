using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.UseCases.Interfaces;
using Contacts.Views_Mvvm;
using System.Collections.ObjectModel;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        private readonly IViewContactsUseCase _viewContactsUseCase;
        private readonly IDeleteContactUseCase _deleteContactUseCase;
        private readonly IEditContactUseCase _editContactUseCase;

        public ObservableCollection<Contact> Contacts { get; set; }
        public Contact SelectedContact { get; set; }
        public ContactsViewModel(
            IViewContactsUseCase viewContactsUseCase, 
            IDeleteContactUseCase deleteContactUseCase,
            IEditContactUseCase editContactUseCase)
        {
            _viewContactsUseCase = viewContactsUseCase;
            _deleteContactUseCase = deleteContactUseCase;
            _editContactUseCase = editContactUseCase; 
            this.Contacts = new ObservableCollection<Contact>();            
        }

        public async Task LoadContactsAsync()
        {
            this.Contacts.Clear();

            var contacts = await _viewContactsUseCase.ExecuteAsync(null);
            if (contacts != null && contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    Contacts.Add(contact);
                }
            }
        }

        [RelayCommand]
        public async Task DeleteContact(Guid id)
        {
            await LoadContactsAsync();
            var contactToDelete = this.Contacts.FirstOrDefault(x => x.Id.Equals(id));
            if (contactToDelete != null) await _deleteContactUseCase.ExecuteAsync(contactToDelete);
            else throw new Exception("Contact not found");
            await LoadContactsAsync();
        }

        [RelayCommand]
        public async Task GotoEditContact(Guid contactId)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage_Mvvm_Page)}?Id={contactId}");
            //await _editContactUseCase.ExecuteAsync(contactId);
            //await LoadContactsAsync();
        }

        [RelayCommand]
        public async Task GetContact(Guid id)
        {
            await LoadContactsAsync();
            var actualContact = this.Contacts.FirstOrDefault(x => x.Id.Equals(id));
            if (actualContact != null) this.SelectedContact = actualContact;
            else throw new Exception("Contact not found");
            await LoadContactsAsync();
        }
    }
}
