using Contacts.ViewModels;

namespace Contacts.Views_Mvvm;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage_Mvvm_Page : ContentPage
{   
    private readonly ContactViewModel _contactViewModel;
    public EditContactPage_Mvvm_Page(ContactViewModel contactViewModel)
	{
		InitializeComponent();
        _contactViewModel = contactViewModel;
        this.BindingContext = _contactViewModel;
	}

    public string ContactId
    {
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && Guid.TryParse(value, out Guid contactId))
            {
                LoadContact(contactId);
            }
          
        }
    }

    private async void LoadContact(Guid contactId)
    {
        await _contactViewModel.LoadContact(contactId);
    }
}