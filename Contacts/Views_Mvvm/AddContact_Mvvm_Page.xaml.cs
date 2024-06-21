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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _contactViewModel.Contact = new CoreBusiness.Contact();

    }
}