using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Contacts.CoreBusiness
{
    public class Contact
    {
        public Contact(string name, string? phone, string? email, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
        }
        public Contact()
        {
            
        }

        [Required]
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Phone { get; set; } = string.Empty;
        [Required]
        public string? Email { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;

        public static implicit operator ObservableCollection<object>(Contact v)
        {
            throw new NotImplementedException();
        }
    }
}
