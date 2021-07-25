using Microsoft.Extensions.DependencyInjection;

namespace fabledatalink.ViewModels
{
    public sealed class ViewModelLocator
    {
        public FableDataLinkViewModel FableDataLinkViewModel => App.ServiceProvider.GetRequiredService<FableDataLinkViewModel>();
        public ProviderViewModel ProviderViewModel => App.ServiceProvider.GetRequiredService<ProviderViewModel>();
    }
}