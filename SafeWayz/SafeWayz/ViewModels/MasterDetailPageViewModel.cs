using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using SafeWayz.Messages;
using SafeWayz.Model.Security;
using System.Collections.ObjectModel;

namespace SafeWayz.ViewModels
{
    public class AppMasterDetailPageViewModel : ViewModelBase
    {
        private ISecurityService _securityService;

        private IEventAggregator _eventAggregator;
        private DelegateCommand<MenuItem> _navigateCommand;
        private ObservableCollection<MenuItem> _menuItems;
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }
        public DelegateCommand<MenuItem> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<MenuItem>(ExecuteNavigateCommand));
        public async void ExecuteNavigateCommand(MenuItem menu)
        {
            if (menu.MenuType == SafeWayz.Enums.MenuTypeEnum.LogOut)
                _securityService.LogOut();
            else
                await NavigationService.NavigateAsync(menu.NavigationPath);
        }
        public AppMasterDetailPageViewModel(INavigationService navigationService, ISecurityService securityService, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            Title = "Main Page";
            _securityService = securityService;
            _eventAggregator = eventAggregator;
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());

            _eventAggregator.GetEvent<LoginMessage>().Subscribe(LoginEvent);

            _eventAggregator.GetEvent<LogOutMessage>().Subscribe(LogOutEvent);
        }
        public void LoginEvent()
        {
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());
            NavigationService.NavigateAsync("NavigationPage/HomePage");
        }
        public void LogOutEvent()
        {
            MenuItems = new ObservableCollection<MenuItem>(_securityService.GetAllowedAccessItems());
            NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }
    }
}
