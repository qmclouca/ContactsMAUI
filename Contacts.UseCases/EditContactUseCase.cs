using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases
{
    public class EditContactUseCase : IEditContactUseCase
    {
        private readonly IContactRepository _contactRepository;

        public EditContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task ExecuteAsync(Contact contact)
        {
            Contact contactToUpdate = await _contactRepository.GetContactByIdAsync(contact.Id);
            if (contactToUpdate == null)
                return;
            Contact newContact = new Contact(contact.Id, contact.Name, contact.Phone, contact.Email, contact.Address);

            await _contactRepository.UpdateContactAsync(newContact);
        }
    }
}
