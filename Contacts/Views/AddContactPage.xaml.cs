using Contacts.Models;
using Contact = Contacts.Models.Contact;

namespace Contacts.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}  

    private void contactCtrl_OnSave(object sender, EventArgs e)
    {
        ContactRepository.AddContact(
            new Contact(
                contactCtrl.Name, 
                contactCtrl.Phone, 
                contactCtrl.Email, 
                contactCtrl.Address));
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}