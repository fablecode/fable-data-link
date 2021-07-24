using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace fabledatalink.ViewModels
{
    public sealed class ConnectionViewModel : ObservableRecipient
    {
        private WorkspaceViewModel? _selectedDatabaseProvider;
        private bool _isEnabled;

        public ConnectionViewModel()
        {
            // Using a method group...
            Messenger.Register<ConnectionViewModel, SelectedProviderChangedMessage>(this, (r, m) => r.Receive(m));
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public WorkspaceViewModel SelectedDatabaseProvider
        {
            get => _selectedDatabaseProvider;
            set => SetProperty(ref _selectedDatabaseProvider, value);
        }

        public void Receive(SelectedProviderChangedMessage message)
        {
            SelectedDatabaseProvider = message.DatabaseProvider.WorkSpace;
        }
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

    public class SelectedDatabaseProviderRequestMessage : RequestMessage<DatabaseProvider>
    {
    }
}