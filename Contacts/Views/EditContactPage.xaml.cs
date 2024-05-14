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
                entryName.Text = contact.Name;
                entryPhone.Text = contact.Phone;
                entryEmail.Text = contact.Email;
                entryAddress.Text = contact.Address;
            }
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        contact.Name = entryName.Text;
        contact.Phone = entryPhone.Text;
        contact.Email = entryEmail.Text;
        contact.Address = entryAddress.Text;

        ContactRepository.UpdateContact(contact);
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }
}