using Contacts.Models;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.Models.Contact;

namespace Contacts.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private CoreBusiness.Contact contact;

    private readonly IViewContactUseCase _viewContactUseCase;
    private readonly IEditContactUseCase _editContactUseCase;

    public EditContactPage(IViewContactUseCase viewContactUseCase, IEditContactUseCase editContactUseCase)
	{
		InitializeComponent();
        _viewContactUseCase = viewContactUseCase;
        _editContactUseCase = editContactUseCase;
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }


    public string ContactId
    {
        set
        {            
            _viewContactUseCase.ExecuteAsync(Guid.Parse(value)).GetAwaiter().GetResult();
            if(contact != null)
            {
                contactCtrl.Name = contact.Name;
                contactCtrl.Phone = contact.Phone;
                contactCtrl.Email = contact.Email;
                contactCtrl.Address = contact.Address;
            }
        }
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
       
        contact.Name = contactCtrl.Name;
        contact.Phone = contactCtrl.Phone;
        contact.Email = contactCtrl.Email;
        contact.Address = contactCtrl.Address;

        await _editContactUseCase.ExecuteAsync(contact.Id);        
        await Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}