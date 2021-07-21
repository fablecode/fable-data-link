namespace fabledatalink.ViewModels
{
    public sealed class ConnectionViewModel : WorkspaceViewModel
    {
        public ConnectionViewModel()
            : this("Connection")
        {
        }
        public ConnectionViewModel(string provider)
            : base(provider)
        {
        }
    }
}