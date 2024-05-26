using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Plugins.DataStore.InMemory
{
    public class ContactInMemoryRepository : IContactRepository
    {
        public static List<Contact> _contacts;

        public ContactInMemoryRepository()
        {
            _contacts = new List<Contact>()
            {
                new Contact("John Doe", "111-111-1111", "JohnDoe@teste.com","endereço1"),
                new Contact("Jane Doe", "222-222-2222", "JaneDoe@teste.com","endereço2"),
                new Contact("John Smith", "333-333-3333", "JohnSmith@teste.com","endereço3"),
                new Contact("Jane Smith", "444-444-4444", "JaneSmith@teste.com","endereço4")
            };

        }

        public Task AddContact(Contact contact)
        {
            if(_contacts == null) _contacts = new List<Contact>();
            _contacts.Add(contact);
            return Task.CompletedTask;
        }

        public Task AddContactAsync(Contact contact)
        {
            if (_contacts == null) _contacts = new List<Contact>();
            _contacts.Add(contact);
            return Task.CompletedTask;            
        }

        public Task<List<Contact>> GetAllContacts()
        {
            return Task.FromResult(_contacts);
        }

        public Task<Contact> GetContactByIdAsync(Guid contactId)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id.Equals(contactId));
            return contact != null ? Task.FromResult(contact) : Task.FromResult(new Contact());
        }

        public Task RemoveContact(Contact contact)
        {
            _contacts.Remove(contact);
            return Task.CompletedTask;
        }

        public Task RemoveContactAsync(Contact contact)
        {
            if (contact != null && contact.Id != Guid.Empty)
            {
                _contacts.Remove(contact);
                return Task.CompletedTask;
            }
            else
            {
                return Task.FromException(new ArgumentException("Contact is null or empty"));
            }            
        }

        public Task<List<Contact>> SearchContacts(string filterText)
        {
            if(string.IsNullOrWhiteSpace(filterText))
            {
                return Task.FromResult(_contacts);
            }
            var contactsByName = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            var contactsByPhone = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            var contactsByEmail = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            var contactsByAddress = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            return Task.FromResult(contactsByName.Union(contactsByPhone).Union(contactsByEmail).Union(contactsByAddress).ToList());
        }

        public Task UpdateContact(Contact contact)
        {
            var oldContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (oldContact != null)
            {
                oldContact.Name = contact.Name;
                oldContact.Phone = contact.Phone;
                oldContact.Email = contact.Email;
                oldContact.Address = contact.Address;
            }
            return Task.CompletedTask;            
        }

        public Task UpdateContactAsync(Contact contact)
        {
            if (contact == null || contact.Id == Guid.Empty) return Task.CompletedTask;

            var oldContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (oldContact != null)
            {
                oldContact.Name = contact.Name;
                oldContact.Phone = contact.Phone;
                oldContact.Email = contact.Email;
                oldContact.Address = contact.Address;
            }
            return Task.CompletedTask;
        }
    }
}
