using Contacts.Models;
using Contact = Contacts.Models.Contact;
namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
		List<Contact> contacts = ContactRepository.GetAllContacts().ToList();
	
		listContacts.ItemsSource = contacts;
	}    
	

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null)
		{
            DisplayAlert("Selected", "Contact selected", "OK");
			await Shell.Current.GoToAsync(nameof(EditContactPage));
        }		
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }
}