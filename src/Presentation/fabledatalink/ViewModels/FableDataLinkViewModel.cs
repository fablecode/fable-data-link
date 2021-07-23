using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace fabledatalink.ViewModels
{
    public sealed class FableDataLinkViewModel: WorkspaceViewModel, IRecipient<SelectedProviderChangedMessage>
    {
        private DatabaseProvider _selectedProvider;

        public FableDataLinkViewModel()
        {
            // Register that specific message...
            WeakReferenceMessenger.Default.Register(this);

            // Register the receiver in a module
            WeakReferenceMessenger.Default.Register<FableDataLinkViewModel, SelectedDatabaseProviderRequestMessage>(this, (r, m) =>
            {
                // Assume that "CurrentUser" is a private member in our viewmodel.
                // As before, we're accessing it through the recipient passed as
                // input to the handler, to avoid capturing "this" in the delegate.
                m.Reply(r.SelectedProvider);
            });

        }

        public ObservableCollection<WorkspaceViewModel> WorkSpaces => new()
        {
            new ProviderViewModel(),
            new ConnectionViewModel()
        };

        public DatabaseProvider SelectedProvider
        {
            get => _selectedProvider;
            set => SetProperty(ref _selectedProvider, value);
        }


        public void Receive(SelectedProviderChangedMessage message)
        {
            SelectedProvider = message.DatabaseProvider;
        }
    }
}