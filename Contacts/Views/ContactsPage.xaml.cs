using Contacts.UseCases.Interfaces;
using System.Collections.ObjectModel;
using Contact = Contacts.CoreBusiness.Contact;
namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
    private readonly IViewContactsUseCase _viewContactsUseCase;
    private readonly IDeleteContactUseCase _deleteContactUseCase;

    public ContactsPage(IViewContactsUseCase viewContactsUseCase, IDeleteContactUseCase deleteContactUseCase)
	{
		InitializeComponent();
        this._viewContactsUseCase = viewContactsUseCase;
        this._deleteContactUseCase = deleteContactUseCase;
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

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem!.CommandParameter as Contact;
        await _deleteContactUseCase.ExecuteAsync(contact!);
        LoadContacts();
    }

    private async void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(await _viewContactsUseCase.ExecuteAsync(string.Empty));
        listContacts.ItemsSource = contacts;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {        
        var contacts = new ObservableCollection<Contact>(await _viewContactsUseCase.ExecuteAsync(((SearchBar)sender!).Text));
        listContacts.ItemsSource = contacts;
    }
    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {   
        var contacts = new ObservableCollection<Contact>(await _viewContactsUseCase.ExecuteAsync(((SearchBar)sender!).Text));
        listContacts.ItemsSource = contacts;
    }

    private void btnTest_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(TestPage1));
    }
}