namespace Contacts.UseCases.PluginInterfaces
{
    public interface IEditContactUseCase
    {
        Task ExecuteAsync(Guid contactId);
    }
}