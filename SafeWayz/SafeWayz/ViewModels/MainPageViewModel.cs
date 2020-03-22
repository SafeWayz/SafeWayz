using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SafeWayz.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //PRIVATE PROPERTIES        
        /////////////////////////////////////////////////////////////////////////////
        private DelegateCommand _navigateToNextPage;
        
        //PUBLIC PROPERTIES        
        /////////////////////////////////////////////////////////////////////////////
        public DelegateCommand NavigateToNextPage =>
            _navigateToNextPage ?? (_navigateToNextPage = new DelegateCommand(NavigateToNextPageCommand));
        //METHODS
        /////////////////////////////////////////////////////////////////////////////
        //public DelegateCommand NavigateCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        private void NavigateToNextPageCommand()
        {
            NavigationService.NavigateAsync("NavigationPage/AddNewIncidentReport");
        }
        
    }
}
