using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeWayz.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand NavigateCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            NavigateCommand = new DelegateCommand(ExcecuteNavigateCommand);
        }

        private void ExcecuteNavigateCommand()
        {
            NavigationService.NavigateAsync("NavigationPage/AddNewIncidentReport");
        }
    }
}
