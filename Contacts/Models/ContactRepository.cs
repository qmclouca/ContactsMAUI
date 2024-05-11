﻿namespace Contacts.Models
{
    public static class ContactRepository
    {
        public static List<Contact> contacts = new List<Contact>()
        {
            new Contact("John Doe", "111-111-1111", "JohnDoe@teste.com"),
            new Contact("Jane Doe", "222-222-2222", "JaneDoe@teste.com"),
            new Contact("John Smith", "333-333-3333", "JohnSmith@teste.com"),
            new Contact("Jane Smith", "444-444-4444", "JaneSmith@teste.com")
        };

        public static void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }
        public static void RemoveContact(Contact contact) { contacts.Remove(contact); }

        public static void UpdateContact(Contact contact)
        {
            var oldContact = contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (oldContact != null)
            {
                oldContact.Name = contact.Name;
                oldContact.Phone = contact.Phone;
                oldContact.Email = contact.Email;
            }
        }

        public static Contact GetContactById(Guid id) => contacts.FirstOrDefault(c => c.Id == id);

        public static IEnumerable<Contact> GetAllContacts()
        {
            return contacts;
        }

        public static IEnumerable<Contact> GetContacts(string name)
        {
            return contacts.Where(c => c.Name.Contains(name));
        }


    }
}