using fabledatalink.Models;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace fabledatalink.Messages
{
    public class SelectedProviderChangedMessage : ValueChangedMessage<DatabaseProvider>
    {
        public SelectedProviderChangedMessage(DatabaseProvider databaseProvider)
            : base(databaseProvider)
        {
            DatabaseProvider = databaseProvider;
        }

        public DatabaseProvider DatabaseProvider { get; }
    }
}