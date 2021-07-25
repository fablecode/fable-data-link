using fabledatalink.Messages;
using fabledatalink.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using MediatR;

namespace fabledatalink.ViewModels
{
    public sealed class ProviderViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private DatabaseProvider _selectedProvider = null!;
        private bool _isNextButtonEnabled;
        private int _selectedProviderIndex;

        public ProviderViewModel(IMediator mediator)
        {
            _mediator = mediator;
            NextCommand = new RelayCommand(OnNextCommand);
        }

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

        public RelayCommand NextCommand { get; }

        private static void OnNextCommand()
        {
            WeakReferenceMessenger.Default.Send(new SelectConnectionViewMessage());
        }
    }
}