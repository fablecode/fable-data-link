namespace fabledatalink.ViewModels
{
    public sealed class ProviderViewModel : WorkspaceViewModel
    {
        public ProviderViewModel()
            : this("Provider")
        {
        }
        public ProviderViewModel(string provider)
            : base(provider)
        {
        }
    }
}