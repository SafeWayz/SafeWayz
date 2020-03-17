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
        private DelegateCommand ReportNewIncident { get; set; }

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

        /////////////////////////////////////////////////////////////////////////////
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            var areas = new PopulateThePickers();
            AreasList = areas.GetTheAreasAndAddToList(AreasList);
            IncidentsList = areas.GetTheIncidentsAndAddToList(IncidentsList);

            ReportNewIncident = new DelegateCommand(ReportNewIncidentCommand);
        }

        private void ReportNewIncidentCommand()
        {
            throw new NotImplementedException();
        }
    }
}
