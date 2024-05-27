using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Models;
using Contact = Contacts.Models.Contact;

namespace Contacts.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        public Contact Contact { get; set; }

        public ContactViewModel(Contact contact)
        {
            Contact = ContactRepository.GetAllContacts().First();
        }        

        [RelayCommand]
        public void SaveContact()
        {
            ContactRepository.AddContact(Contact);
        }
    }
}
