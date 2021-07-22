using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace fabledatalink.ViewModels
{
    public sealed class ConnectionViewModel : WorkspaceViewModel, IRecipient<SelectedProviderChangedMessage>
    {
        public ConnectionViewModel()
            : this("Connection")
        {
        }
        public ConnectionViewModel(string provider)
            : base(provider)
        {
            // Register that specific message...
            WeakReferenceMessenger.Default.Register(this);
        }

        public void Receive(SelectedProviderChangedMessage message)
        {
            DataContext = message.DatabaseProvider.WorkSpace;
        }

        public WorkspaceViewModel DataContext { get; set; }
    }

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