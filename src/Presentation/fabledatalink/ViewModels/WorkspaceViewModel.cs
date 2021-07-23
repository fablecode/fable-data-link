using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace fabledatalink.ViewModels
{
    public abstract class WorkspaceViewModel : ObservableObject
    {
        private string _displayName;

        protected WorkspaceViewModel()
        {
        }

        protected WorkspaceViewModel(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }
    }
}