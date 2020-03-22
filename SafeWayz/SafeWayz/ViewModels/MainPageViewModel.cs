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
        private string _userIncidentDescription;

        private DelegateCommand _excecuteNavigate;
        private DelegateCommand _navigateToNextPage;

        private ObservableCollection<string> _areasList;
        private ObservableCollection<string> _incidentsList;
        
        /////////////////////////////////////////////////////////////////////////////
        public ObservableCollection<string> AreasList
        {
            get { return _areasList; }
            set { SetProperty(ref _areasList, value); }
        }
        public ObservableCollection<string> IncidentsList
        {
            get { return _incidentsList; }
            set { SetProperty(ref _incidentsList, value); }
        }
        public string UserIncidentDescription
        {
            get { return _userIncidentDescription; }
            set { SetProperty(ref _userIncidentDescription, value); }
        }

        public DelegateCommand NavigateCommand =>
            _excecuteNavigate ?? (_excecuteNavigate = new DelegateCommand(ExcecuteNavigateCommand));
        public DelegateCommand NavigateToNextPage =>
            _navigateToNextPage ?? (_navigateToNextPage = new DelegateCommand(NavigateToNextPageCommand));

        /////////////////////////////////////////////////////////////////////////////
        //public DelegateCommand NavigateCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            var areas = new PopulateThePickers();
            //THIS IS HOW WE POPULATE THE OPTIONS FOR BOTHE DROPDOWN PICKERS
            AreasList = areas.GetTheAreasAndAddToList(AreasList);
            IncidentsList = areas.GetTheIncidentsAndAddToList(IncidentsList);
        }

        private void ExcecuteNavigateCommand()
        {
            NavigationService.NavigateAsync("NavigationPage/AddNewIncidentReport");
        }


        private void NavigateToNextPageCommand()
        {
            NavigationService.NavigateAsync("NavigationPage/AddNewIncidentReport");
        }
        
    }
}
