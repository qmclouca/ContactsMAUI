using Contacts.ViewModels;

namespace Contacts.Views;

public partial class TestPage1 : ContentPage
{
	private ContactViewModel viewModel;
	public TestPage1()
	{
		InitializeComponent();
		viewModel = new ContactViewModel();
		this.BindingContext = viewModel;
	}
}