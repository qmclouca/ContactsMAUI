namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
		List<Contact> contacts = new List<Contact>() { 
			new Contact { Name = "John Doe", Phone="111-111-1111", Email="JohnDoe@teste.com" },
			new Contact { Name = "Jane Doe", Phone = "222-222-2222", Email = "JaneDoe@teste.com" },
			new Contact { Name = "John Smith", Phone = "333-333-3333", Email = "JohnSmith@teste.com" },
			new Contact { Name = "Jane Smith", Phone = "444-444-4444", Email = "JaneSmith@teste.com" },
		};
		listContacts.ItemsSource = contacts;
	}    

	public class Contact
	{
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
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