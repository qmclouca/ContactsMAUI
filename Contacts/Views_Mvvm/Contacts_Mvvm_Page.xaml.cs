using Contacts.ViewModels;
using System.Collections.ObjectModel;

namespace Contacts.Views_Mvvm;

public partial class Contacts_Mvvm_Page : ContentPage
{
    private readonly ContactsViewModel _contactsViewModel;

    public Contacts_Mvvm_Page(ContactsViewModel contactsViewModel)
	{
		InitializeComponent();
        _contactsViewModel = contactsViewModel;
        this.BindingContext = contactsViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _contactsViewModel.LoadContactsAsync();
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        //var contacts = new ObservableCollection<Contact>(await _viewContactsUseCase.ExecuteAsync(((SearchBar)sender!).Text));
        //listContacts.ItemsSource = contacts;
    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        //var contacts = new ObservableCollection<Contact>(await _viewContactsUseCase.ExecuteAsync(((SearchBar)sender!).Text));
        //listContacts.ItemsSource = contacts;
    }
}