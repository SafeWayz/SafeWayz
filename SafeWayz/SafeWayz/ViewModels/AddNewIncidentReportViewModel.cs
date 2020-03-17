using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SafeWayz.Models;
using SafeWayz.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SafeWayz.ViewModels
{
    public class AddNewIncidentReportViewModel : ViewModelBase
    {
        //PRIVATE PROPERTIES
        /////////////////////////////////////////////////////////////////////////////

        private string _selectedArea;
        private string _selectedIncident;
        private string _userIncidentDescription;

        private IncidentReport _newIncidentReport;
        
        private DelegateCommand _reportNewIncident;

        private ObservableCollection<string> _areasList;
        private ObservableCollection<string> _incidentsList;

        //PUBLIC PROPERTIES
        /////////////////////////////////////////////////////////////////////////////

        public IncidentReport NewIncidentReport
        {
            get { return _newIncidentReport; }
            set { SetProperty(ref _newIncidentReport, value); }
        }
        public string SelectedArea
        {
            get { return _selectedArea; }
            set { SetProperty(ref _selectedArea, value); }
        }
        public string SelectedIncident
        {
            get { return _selectedIncident; }
            set { SetProperty(ref _selectedIncident, value); }
        }
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

        public DelegateCommand ReportNewIncident =>
            _reportNewIncident ?? (_reportNewIncident = new DelegateCommand(ReportNewIncidentCommand));


        //METHODS COME HERE
        /////////////////////////////////////////////////////////////////////////////
        public AddNewIncidentReportViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            var areas = new PopulateThePickers();

            AreasList = areas.GetTheAreasAndAddToList(AreasList);
            IncidentsList = areas.GetTheIncidentsAndAddToList(IncidentsList);
        }

        private void ReportNewIncidentCommand()
        {
            var newReport = NewIncidentReport;
            IncidentReport newIncident = new IncidentReport()
            {
                Area = SelectedArea,
                Incident = SelectedIncident,
                IncidentDescription = UserIncidentDescription,
                UpvotesAmount = 0
            };

            var dbconection = new SafeWayZDatabase();
            dbconection.SaveIncidentReportAsync(newIncident);


        }
    }
}
