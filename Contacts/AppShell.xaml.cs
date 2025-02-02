﻿using Contacts.Views;
using Contacts.Views_Mvvm;

namespace Contacts
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(TestPage1), typeof(TestPage1));
            Routing.RegisterRoute(nameof(Contacts_Mvvm_Page), typeof(Contacts_Mvvm_Page));
            Routing.RegisterRoute(nameof(EditContactPage_Mvvm_Page), typeof(EditContactPage_Mvvm_Page));
            Routing.RegisterRoute(nameof(AddContact_Mvvm_Page), typeof(AddContact_Mvvm_Page));
        }
    }
}