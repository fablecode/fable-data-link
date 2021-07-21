using System.Collections.ObjectModel;

namespace fabledatalink.ViewModels
{
    public sealed class FableDataLinkViewModel: WorkspaceViewModel
    {
        public ObservableCollection<WorkspaceViewModel> WorkSpaces => new()
        {
            new ProviderViewModel(),
            new ConnectionViewModel()
        };
    }
}