using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SafeWayz.Models;
using SafeWayz.Services;
using SafeWayz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SafeWayz.ViewModels
{
    public class AddNewIncidentReportViewModel : ViewModelBase
    {
        //PRIVATE PROPERTIES
        /////////////////////////////////////////////////////////////////////////////

        private string _selectedArea;
        private string _selectedIncident;
        private readonly IDatabase _database;
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
            _reportNewIncident ?? (_reportNewIncident = new DelegateCommand(async () => await ReportNewIncidentCommand()));


        //METHODS COME HERE
        /////////////////////////////////////////////////////////////////////////////
        public AddNewIncidentReportViewModel(INavigationService navigationService, IDatabase database)
            : base(navigationService)
        {
            _database = database;

            var areas = new PopulateThePickers();
            NewIncidentReport = new IncidentReport();

            //THIS IS HOW WE POPULATE THE OPTIONS FOR BOTHE DROPDOWN PICKER
            AreasList = areas.GetTheAreasAndAddToList(AreasList);
            IncidentsList = areas.GetTheIncidentsAndAddToList(IncidentsList);
        }

        private async Task ReportNewIncidentCommand()
        {
            //I ONLY COMMENTED THIS OUT TO MOVE TO THE NEXT PAGE QUICKER, WHEN YOU UNCOMMENT IT, IT SHOULD BE FINE
            await _database.SaveIncidentReportAsync(NewIncidentReport);

            //THIS WAS JUST TO TEST WHETHER TTHE DATA IS ACTUALLY BEING SAVED 
            var allIncidentsFromDb = await _database.GetAllIncidentReportInformationData();

            await NavigationService.NavigateAsync("NavigationPage/AllCommunityPosts");
        }
    }
}
