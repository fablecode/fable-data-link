using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace fabledatalink.ViewModels
{
    public sealed class ProviderViewModel : ObservableObject
    {
        private DatabaseProvider _selectedProvider;
        private bool _isNextButtonEnabled;
        private int _selectedProviderIndex;

        public ObservableCollection<DatabaseProvider> DatabaseProviders => new()
        {
            new DatabaseProvider("Microsoft SQL Server", new SqlServerConnectionViewModel()),
            new DatabaseProvider("SQLite", new SqlLiteConnectionViewModel()),
            new DatabaseProvider("MySQL", new MySqlConnectionViewModel())
        };

        public int SelectedProviderIndex
        {
            get => _selectedProviderIndex;
            set => SetProperty(ref _selectedProviderIndex, value);
        }

        public DatabaseProvider SelectedProvider
        {
            get => _selectedProvider;
            set
            {
                SetProperty(ref _selectedProvider, value);

                if (value != null)
                {
                    WeakReferenceMessenger.Default.Send(new SelectedProviderChangedMessage(value));
                    IsNextButtonEnabled = true;
                }
                else
                {
                    IsNextButtonEnabled = false;
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