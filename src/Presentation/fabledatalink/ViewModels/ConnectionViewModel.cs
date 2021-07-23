using System;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace fabledatalink.ViewModels
{
    public sealed class ConnectionViewModel : WorkspaceViewModel
    {
        private WorkspaceViewModel? _selectedDatabaseProvider;

        public ConnectionViewModel()
            : this("Connection")
        {
        }
        public ConnectionViewModel(string provider)
            : base(provider)
        {
        }


        public WorkspaceViewModel SelectedDatabaseProvider
        {
            get => GetSelectedDatabaseProvider() ?? throw new ArgumentNullException(nameof(SelectedDatabaseProvider), $"{nameof(ConnectionViewModel)} -> {nameof(SelectedDatabaseProvider)}: Database provider not selected.");
            set => SetProperty(ref _selectedDatabaseProvider, value);
        }

        private static WorkspaceViewModel? GetSelectedDatabaseProvider()
        {
            // Request selected database provider
            var databaseProvider = WeakReferenceMessenger.Default.Send<SelectedDatabaseProviderRequestMessage>();

            if (databaseProvider.HasReceivedResponse && databaseProvider.Response != null)
            {
                return databaseProvider.Response.WorkSpace;
            }

            return null;
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