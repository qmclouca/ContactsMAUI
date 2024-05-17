using Contacts.Models;
using Contact = Contacts.Models.Contact;

namespace Contacts.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }


    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(Guid.Parse(value));
            if(contact != null)
            {
                contactCtrl.Name = contact.Name;
                contactCtrl.Phone = contact.Phone;
                contactCtrl.Email = contact.Email;
                contactCtrl.Address = contact.Address;
            }
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
       
        contact.Name = contactCtrl.Name;
        contact.Phone = contactCtrl.Phone;
        contact.Email = contactCtrl.Email;
        contact.Address = contactCtrl.Address;

        ContactRepository.UpdateContact(contact);
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}