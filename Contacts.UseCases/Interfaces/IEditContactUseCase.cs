namespace Contacts.UseCases.Interfaces
{
    public interface IEditContactUseCase
    {
        Task ExecuteAsync(Guid contactId);
    }
}