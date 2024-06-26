﻿using CommunityToolkit.Maui;
using Contacts.Plugins.DataStore.SqlLite;
using Contacts.UseCases;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contacts.ViewModels;
using Contacts.Views_Mvvm;
using Microsoft.Extensions.Logging;

namespace Contacts
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            #region dependency injection registration
            builder.Services.AddSingleton<IContactRepository, ContactSqliteRepository>();
            //builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
            builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();       
            builder.Services.AddTransient<IEditContactUseCase, EditContactUseCase>();
            builder.Services.AddTransient<IAddContactUseCase, AddContactUseCase>();
            builder.Services.AddTransient<IDeleteContactUseCase, DeleteContactUseCase>();        
            #endregion dependency injection registration

            #region navigation registration (default constructors registration)
            builder.Services.AddSingleton<ContactsViewModel>();
            builder.Services.AddSingleton<Contacts_Mvvm_Page>();
            builder.Services.AddSingleton<EditContactPage_Mvvm_Page>();
            builder.Services.AddSingleton<AddContact_Mvvm_Page>();
            #endregion navigation registration (default constructors registration)

            return builder.Build();
        }
    }
}
