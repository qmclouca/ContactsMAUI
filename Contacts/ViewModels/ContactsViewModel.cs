using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.UseCases.Interfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.ViewModels
{
    public class ContactsViewModel
    {
        private readonly IViewContactsUseCase _viewContactsUseCase;

        public ObservableCollection<Contact> Contacts { get; set; }
        public ContactsViewModel(IViewContactsUseCase viewContactsUseCase)
        {
            _viewContactsUseCase = viewContactsUseCase;
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
    }
}
