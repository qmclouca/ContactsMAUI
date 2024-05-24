using Contact = Contacts.CoreBusiness.Contact;
namespace Contacts.UseCases.PluginInterfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> SearchContacts(string filterText);
        Task<List<Contact>> GetAllContacts();
        Task AddContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task RemoveContact(Contact contact);
        Task<Contact> GetContactByIdAsync(Guid contactId);
        Task UpdateContactAsync(Contact contact);
    }
}
