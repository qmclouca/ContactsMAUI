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

        public async Task ExecuteAsync(Guid contactId)
        {
            Contact contact = await _contactRepository.GetContactByIdAsync(contactId);
            await _contactRepository.UpdateContactAsync(contact);
        }
    }
}
