namespace Contacts.Models
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
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
    }
}
