namespace Contacts.UseCases.Interfaces
{
    public interface IDeleteContactUseCase
    {
        Task ExecuteAsync(CoreBusiness.Contact contact);
    }
}