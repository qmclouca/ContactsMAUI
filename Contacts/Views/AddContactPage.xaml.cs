using Contacts.UseCases.Interfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Views;

public partial class AddContactPage : ContentPage
{
    private readonly IAddContactUseCase _addContactUseCase;

    public AddContactPage(IAddContactUseCase addContactUseCase)
	{
		InitializeComponent();
        _addContactUseCase = addContactUseCase;
    }  

    private async void contactCtrl_OnSave(object sender, EventArgs e)
    {
        await _addContactUseCase.ExecuteAsync(new Contact(contactCtrl.Name, contactCtrl.Phone, contactCtrl.Email, contactCtrl.Address));         
        await Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
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