using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Models;
using Contact = Contacts.Models.Contact;

namespace Contacts.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private Contact contact;

        //implementation of TwoWay binding using CommunityToolkit.Mvvm.ComponentModel
        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        public ContactViewModel() {
            Contact = new Contact();
        }

        public void LoadContact(Guid id)
        {   
            //TODO: Tirar essa parte de teste
            IEnumerable<Contact> contacts = ContactRepository.GetAllContacts();
            Contact = contacts.First();
            //Contact = ContactRepository.GetContactById(id);
        }   

        [RelayCommand]
        public void SaveContact()
        {
            ContactRepository.AddContact(Contact);
        }
    }
}
