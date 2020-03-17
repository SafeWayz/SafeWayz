using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SafeWayz.Messages;
using SafeWayz.Model;
using SafeWayz.Model.Security;
using SafeWayz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SafeWayz.ViewModels
{
    public class LogInPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private IEventAggregator _eventAggregator;

        private ISecurityService _securityService;

        private IPageDialogService _pageDialogService;


        private UserModel _person;
        public UserModel Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }
        private readonly IDatabase _database;

        private DelegateCommand _loginCompleteCommand;
        public DelegateCommand LoginCompleteCommand =>
            _loginCompleteCommand ?? (_loginCompleteCommand = new DelegateCommand(ExecuteLoginCompleteCommand));

        async void ExecuteLoginCompleteCommand()
        {
            if (_person.Email == null && _person.Password == null || _person.Email == null || _person.Password == null)
            {
                await _pageDialogService.DisplayAlertAsync("Try Again", "Please enter your details", "Ok");
            }
            else
            {
                var loginResult = await _securityService.Login(_person.Email, _person.Password);

                if (loginResult)
                {
                    _eventAggregator.GetEvent<LoginMessage>().Publish();
                    await _pageDialogService.DisplayAlertAsync("Welcome", "Successful Login", "Ok");

                }
            }
        }
        public LogInPageViewModel(INavigationService navigationService, IDatabase database, ISecurityService securityService, IEventAggregator eventAggregator, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _securityService = securityService;
            _database = database;
            _eventAggregator = eventAggregator;
            Title = "Login Page";
            _navigationService = navigationService;
            Person = new UserModel();
        }
    }
}
