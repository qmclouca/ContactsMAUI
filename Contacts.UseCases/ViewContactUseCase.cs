using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases
{
    public class ViewContactUseCase : IViewContactUseCase
    {
        private readonly IContactRepository _contactRepository;
        public ViewContactUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<Contact> ExecuteAsync(Guid contactId)
        {
            return await _contactRepository.GetContactByIdAsync(contactId);
        }
    }
}