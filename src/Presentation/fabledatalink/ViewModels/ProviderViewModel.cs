using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace fabledatalink.ViewModels
{
    public sealed class ProviderViewModel : WorkspaceViewModel
    {
        private DatabaseProvider _selectedProvider;
        private bool _isNextButtonEnabled;

        public ProviderViewModel()
            : this("Provider")
        {
        }
        public ProviderViewModel(string provider)
            : base(provider)
        {
        }

        public ObservableCollection<DatabaseProvider> DatabaseProviders => new()
        {
            new DatabaseProvider("Microsoft SQL Server", new SqlServerConnectionViewModel()),
            new DatabaseProvider("SQLite", new SqlLiteConnectionViewModel()),
            new DatabaseProvider("MySQL", new MySqlConnectionViewModel())
        };

        public DatabaseProvider SelectedProvider
        {
            get => WeakReferenceMessenger.Default.Send<SelectedDatabaseProviderRequestMessage>();
            set
            {
                SetProperty(ref _selectedProvider, value);

                if(value != null)
                {
                    // Send a message from some other module
                    WeakReferenceMessenger.Default.Send(new SelectedProviderChangedMessage(value));
                    IsNextButtonEnabled = true;
                }
            }
        }

        public bool IsNextButtonEnabled
        {
            get => _isNextButtonEnabled;
            set => SetProperty(ref _isNextButtonEnabled, value);
        }
    }

    public sealed class MySqlConnectionViewModel : WorkspaceViewModel
    {
    }

    public sealed class SqlLiteConnectionViewModel : WorkspaceViewModel
    {
    }

    public sealed class SqlServerConnectionViewModel : WorkspaceViewModel
    {
    }

    public record DatabaseProvider(string Name, WorkspaceViewModel WorkSpace);
}