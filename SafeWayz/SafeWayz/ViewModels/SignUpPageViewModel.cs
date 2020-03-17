using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using SafeWayz.Messages;
using SafeWayz.Model;
using SafeWayz.Services;
using SafeWayz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SafeWayz.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        private readonly IDatabase _database;
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        private UserModel _person;
        public UserModel Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }

        private DelegateCommand _signUpCommand;
        public DelegateCommand SignUpCommand =>
            _signUpCommand ?? (_signUpCommand = new DelegateCommand(ExecuteSignUpCommand));

        async void ExecuteSignUpCommand()
        {
            var userProfile = new UserModel();

            _eventAggregator.GetEvent<SignUpMessage>().Publish();
            await _database.SaveItemAsync(Person);
        
        }

        public SignUpPageViewModel(INavigationService navigationService, IDatabase database, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            _eventAggregator = eventAggregator;
            navigationService = _navigationService;
            _database = database;
            Person = new UserModel();
        }
    }
}
