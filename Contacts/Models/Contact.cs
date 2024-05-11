namespace Contacts.Models
{
    public class Contact
    {
        public Contact(string name, string? phone, string? email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Phone = phone;
            Email = email;
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
