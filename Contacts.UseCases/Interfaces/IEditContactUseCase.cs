using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases.Interfaces
{
    public interface IEditContactUseCase
    {
        Task ExecuteAsync(Contact contact);
    }
}