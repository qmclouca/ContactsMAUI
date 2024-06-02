using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.UseCases.Interfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        private readonly IViewContactsUseCase _viewContactsUseCase;
        private readonly IDeleteContactUseCase _deleteContactUseCase;

        public ObservableCollection<Contact> Contacts { get; set; }
        public ContactsViewModel(IViewContactsUseCase viewContactsUseCase, IDeleteContactUseCase deleteContactUseCase)
        {
            _viewContactsUseCase = viewContactsUseCase;
            _deleteContactUseCase = deleteContactUseCase;
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
    }
}
