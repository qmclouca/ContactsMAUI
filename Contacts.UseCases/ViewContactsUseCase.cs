using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.CoreBusiness.Contact;
namespace Contacts.UseCases
{
    public class ViewContactsUseCase : IViewContactsUseCase
    {
        private readonly IContactRepository _contactRepository;
        public ViewContactsUseCase(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<List<Contact>> ExecuteAsync(string filterText)
        {
            return await _contactRepository.SearchContacts(filterText);
        }
    }
}
