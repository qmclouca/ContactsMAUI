using Contacts.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.Models.Contact;
namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();		
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SearchBar.Text = string.Empty;
        LoadContacts();
    }


    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null)
		{            
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).Id}");
        }		
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }  
  
    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem!.CommandParameter as Contact;
        ContactRepository.RemoveContact(contact!);
        LoadContacts();
    }

    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetAllContacts());
        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender!).Text));
        listContacts.ItemsSource = contacts;
    }
    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {       
        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender!).Text));
        listContacts.ItemsSource = contacts;
    }
}