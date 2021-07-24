using System.Collections.ObjectModel;
using fabledatalink.Messages;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace fabledatalink.ViewModels
{
    public sealed class FableDataLinkViewModel: ObservableRecipient
    {
        private int _selectedWorkspaceIndex;
        private bool _isConnectionViewEnabled;

        public FableDataLinkViewModel()
        {
            // Using a method group...
            Messenger.Register<FableDataLinkViewModel, SelectedProviderChangedMessage>(this, (r, m) => r.Receive(m));
            Messenger.Register<FableDataLinkViewModel, SelectConnectionViewMessage>(this, (r, m) => r.ReceiveSelectConnectionViewMessage());
        }

        private void ReceiveSelectConnectionViewMessage()
        {
            SelectedWorkspaceIndex = 1;
        }

        public int SelectedWorkspaceIndex
        {
            get => _selectedWorkspaceIndex;
            set => SetProperty(ref _selectedWorkspaceIndex, value);
        }

        public bool IsConnectionViewEnabled
        {
            get => _isConnectionViewEnabled;
            set => SetProperty(ref _isConnectionViewEnabled, value);
        }

        public void Receive(SelectedProviderChangedMessage message)
        {
            IsConnectionViewEnabled = message.DatabaseProvider != null;
        }
    }
}