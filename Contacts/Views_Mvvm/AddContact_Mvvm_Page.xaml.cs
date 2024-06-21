using Contacts.ViewModels;

namespace Contacts.Views_Mvvm;

public partial class AddContact_Mvvm_Page : ContentPage
{
	private readonly ContactViewModel _contactViewModel;
    public AddContact_Mvvm_Page(ContactViewModel contactViewModel)
	{
		InitializeComponent();
        _contactViewModel = contactViewModel;
        this.BindingContext = _contactViewModel;
    }

    private async void SaveContact_Clicked(object sender, EventArgs e)
    {
        //await _contactViewModel.AddContact();
    }
}