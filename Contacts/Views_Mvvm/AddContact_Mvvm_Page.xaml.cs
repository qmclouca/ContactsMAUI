using Contacts.ViewModels;
using System.Collections.ObjectModel;

namespace Contacts.Views_Mvvm;

public partial class AddContact_Mvvm_Page : ContentPage
{
	private readonly ContactsViewModel _contactViewModel;
    public AddContact_Mvvm_Page(ContactsViewModel contactViewModel)
	{
		InitializeComponent();
        _contactViewModel = contactViewModel;
        this.BindingContext = _contactViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _contactViewModel.Contacts = new ObservableCollection<CoreBusiness.Contact>();
    }
}