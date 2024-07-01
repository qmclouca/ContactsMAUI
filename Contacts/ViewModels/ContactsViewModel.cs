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

        private string filterText;
        public string FilterText
        {
            get => filterText;
            set
            {
                SetProperty(ref filterText, value);
                LoadContacts(filterText);
            }
        }

        private Contact selectedContact;
        public Contact SelectedContact
        {
            get => selectedContact;
            set
            {
                SetProperty(ref selectedContact, value);
                // Notify that validation properties may have changed
                OnPropertyChanged(nameof(IsNameProvided));
                OnPropertyChanged(nameof(IsEmailProvided));
                OnPropertyChanged(nameof(IsEmailFormatValid));
            }
        }

        public bool IsNameProvided => !string.IsNullOrWhiteSpace(SelectedContact?.Name);
        public bool IsEmailProvided => !string.IsNullOrWhiteSpace(SelectedContact?.Email);
        public bool IsEmailFormatValid => SelectedContact?.Email != null && SelectedContact.Email.Contains("@");

        public ContactsViewModel(
            IViewContactsUseCase viewContactsUseCase,
            IDeleteContactUseCase deleteContactUseCase,
            IEditContactUseCase editContactUseCase)
        {
            _viewContactsUseCase = viewContactsUseCase;
            _deleteContactUseCase = deleteContactUseCase;
            _editContactUseCase = editContactUseCase;
            Contacts = new ObservableCollection<Contact>();
        }

        private async void LoadContacts(string filterText)
        {
            await LoadContactsAsync(filterText);
        }

        public async Task LoadContactsAsync(string? filterText = null)
        {
            Contacts.Clear();

            var contacts = await _viewContactsUseCase.ExecuteAsync(filterText);
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
            var contactToDelete = Contacts.FirstOrDefault(x => x.Id.Equals(id));
            if (contactToDelete != null)
            {
                await _deleteContactUseCase.ExecuteAsync(contactToDelete);
                Contacts.Remove(contactToDelete);
            }
            else throw new Exception("Contact not found");
        }

        [RelayCommand]
        public async Task GotoEditContact(Guid contactId)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage_Mvvm_Page)}?Id={contactId}");
        }

        [RelayCommand]
        public async Task GetContact(Guid id)
        {
            var actualContact = Contacts.FirstOrDefault(x => x.Id.Equals(id));
            if (actualContact != null) SelectedContact = actualContact;
            else throw new Exception("Contact not found");
        }

        [RelayCommand]
        public async Task GotoAddContact()
        {
            await Shell.Current.GoToAsync(nameof(AddContact_Mvvm_Page));
        }

        [RelayCommand]
        public async Task BackToContacts()
        {            
            await Shell.Current.GoToAsync("..");
        }
    }
}
