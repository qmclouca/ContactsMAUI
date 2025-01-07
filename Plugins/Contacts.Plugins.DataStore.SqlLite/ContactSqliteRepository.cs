using Contacts.UseCases.PluginInterfaces;
using SQLite;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Plugins.DataStore.SqlLite
{
    public class ContactSqliteRepository : IContactRepository
    {
        private SQLiteAsyncConnection _database;
        public ContactSqliteRepository()
        {
            _database = new SQLiteAsyncConnection(Constants._DatabasePath);
            _database.CreateTableAsync<Contact>().Wait();
        }
    
        public Task AddContact(Contact contact)
        {
            return Task.FromResult(AddContactAsync(contact));
        }

        public async Task AddContactAsync(Contact contact)
        {
            await _database.InsertAsync(contact);
        }

        public Task<List<Contact>> GetAllContacts()
        {
            return GetAllContactsAsync();
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await _database.Table<Contact>().ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(Guid contactId)
        {
            return await _database.Table<Contact>().Where(i => i.Id == contactId).FirstOrDefaultAsync();            
        }

        public Task RemoveContact(Contact contact)
        {
            return Task.FromResult(RemoveContactAsync(contact));
        }

        public async Task RemoveContactAsync(Contact contact)
        {
            var actualContact = await GetContactByIdAsync(contact.Id);
            if (actualContact != null && contact.Id.Equals(actualContact.Id))
                await _database.DeleteAsync(contact);
        }

        public Task<List<Contact>> SearchContacts(string filterText)
        {
            return SearchContactsAsync(filterText);
        }

        public async Task<List<Contact>> SearchContactsAsync(string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText))
                return await _database.Table<Contact>().ToListAsync();

            return await this._database.QueryAsync<Contact>(@"
                    SELECT * 
                    FROM Contact 
                    WHERE 
                        Name LIKE ? OR
                        Email LIKE ? OR
                        Phone LIKE ? OR
                        Address LIKE ?",
                        $"{filterText}%", 
                        $"{filterText}%", 
                        $"{filterText}%", 
                        $"{filterText}%");            
        }


        public Task UpdateContact(Contact contact)
        {
            return Task.FromResult(UpdateContactAsync(contact));
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            var rowsAffected = await _database.UpdateAsync(contact);
            if (rowsAffected <= 0)
                throw new InvalidOperationException("A atualização não foi realizada. Nenhuma linha do banco de dados foi afetada.");            
        }
    }
}
