using fabledatalink.Messages;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace fabledatalink.ViewModels
{
    public sealed class ConnectionViewModel : ObservableRecipient
    {
        private WorkspaceViewModel? _selectedDatabaseProvider;

        public ConnectionViewModel()
        {
            Messenger.Register<ConnectionViewModel, SelectedProviderChangedMessage>(this, (r, m) => r.Receive(m));
        }

        public WorkspaceViewModel SelectedDatabaseProvider
        {
            get => _selectedDatabaseProvider!;
            set => SetProperty(ref _selectedDatabaseProvider, value);
        }

        public void Receive(SelectedProviderChangedMessage message)
        {
            SelectedDatabaseProvider = message.DatabaseProvider.WorkSpace;
        }
    }
}