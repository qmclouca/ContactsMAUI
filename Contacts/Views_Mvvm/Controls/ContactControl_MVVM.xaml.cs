using System.Runtime.CompilerServices;

namespace Contacts.Views_Mvvm.Controls;

public partial class ContactControl_MVVM : ContentView
{
    public bool IsForEdit { get; set; }
    public bool IsForAdd { get; set; }
    public ContactControl_MVVM()
	{
		InitializeComponent();
	}

    override protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (IsForAdd && !IsForEdit)
        {
            btnSave.SetBinding(Button.CommandProperty, new Binding("AddContactCommand"));
        }
        else if (IsForEdit && !IsForAdd)
        {
            btnSave.SetBinding(Button.CommandProperty, new Binding("EditContactCommand"));
        }
    }
}