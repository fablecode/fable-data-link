using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace fabledatalink.ViewModels
{
    public sealed class FableDataLinkViewModel: ObservableRecipient
    {
        private WorkspaceViewModel _selectedWorkspace;
        private int _selectedWorkspaceIndex;
        private bool _isConnectionViewEnabled;

        public FableDataLinkViewModel()
        {
            // Using a method group...
            Messenger.Register<FableDataLinkViewModel, SelectedProviderChangedMessage>(this, (r, m) => r.Receive(m));
        }

        public ObservableCollection<WorkspaceViewModel> WorkSpaces { get; }

        public WorkspaceViewModel SelectedWorkspace
        {
            get => _selectedWorkspace;
            set => SetProperty(ref _selectedWorkspace, value);
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