using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases.Interfaces
{
    public interface IViewContactUseCase
    {
        Task<Contact> ExecuteAsync(Guid contactId);
    }
}