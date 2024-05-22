using CommunityToolkit.Maui;
using Contacts.Plugins.DataStore.InMemory;
using Contacts.UseCases;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contacts.Views;
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
            builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
            builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();

            #endregion dependency injection registration

            #region navigation registration (default constructors registration)
            builder.Services.AddSingleton<ContactsPage>();
            #endregion navigation registration (default constructors registration)

            return builder.Build();
        }
    }
}
