namespace Contacts.Plugins.DataStore.SqlLite
{
    public class Constants
    {
        public const string _DatabaseFileName = "ContactsSqlite.db3";
        public static string _DatabasePath => Path.Combine(FileSystem.AppDataDirectory, _DatabaseFileName);
    }
}
