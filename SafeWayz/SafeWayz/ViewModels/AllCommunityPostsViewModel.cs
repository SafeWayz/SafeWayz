using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SafeWayz.Model;
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
    public class AllCommunityPostsViewModel : ViewModelBase
    {
        //PRIVATE PROPERTIES
        /////////////////////////////////////////////////////////////////////////////
        private readonly IDatabase _database;
        private DelegateCommand _upvoteThisPost;
        private DelegateCommand<IncidentReport> _viewIndividualPost;

        private IList<IncidentReport> _incidentsFromDB;

        private IncidentReport _incidentFromDB;
        private UserModel _userModelFromDB;


        //PUBLIC PROPERTIES
        /////////////////////////////////////////////////////////////////////////////
        //public DelegateCommand UpvoteThisPost =>
        //    _upvoteThisPost ?? (_upvoteThisPost = new DelegateCommand<IncidentReport>(async() => await UpvoteThisPostCommand()));
        //public DelegateCommand<IncidentReport> ViewIndividualPost =>
        //    _viewIndividualPost ?? (_viewIndividualPost = new DelegateCommand<IncidentReport>(ViewIndividualPostCommandAsync));
        
        public IList<IncidentReport> IncidentsFromDB
        {
            get { return _incidentsFromDB; }
            set { SetProperty(ref _incidentsFromDB, value); }
        }
        public IncidentReport IncidentFromDB
        {
            get { return _incidentFromDB; }
            set { SetProperty(ref _incidentFromDB, value); }
        }
        public UserModel UserModelFromDB
        {
            get { return _userModelFromDB; }
            set { SetProperty(ref _userModelFromDB, value); }
        }

        //METHODS COME HERE
        /////////////////////////////////////////////////////////////////////////////
        public AllCommunityPostsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            //THIS IS JUST A WAY TO CALL AN ASYNC METHOD IN A CONSTRUCTOR WITHOUT MAKING THE CONSTRUCTOR ASYNC
            new Action(async () => await GetAndDisplaySavedIncidents())();
        }


        public async Task GetAndDisplaySavedIncidents()
        {
            //HERE ALL WE DO IS GET THE DATA FROM THE DATABASE, THE LIST VIEW IN THE XAML DOES THE REST
            var dbConnection = new SafeWayZDatabase();
            IncidentsFromDB = await _database.GetAllIncidentReportInformationData();
        }

        private async Task UpvoteThisPostCommand(IncidentReport incidentReport)
        {
            var currentIncidentReport = incidentReport;

            //WE WANNA INCREASE THE AMOUNT OF UPVOTES AND SAVE THAT NEW VALUE
            IncidentFromDB = await _database.GetIncidentById(currentIncidentReport.ID);
            IncidentFromDB.UpvotesAmount = IncidentFromDB.UpvotesAmount++;
            //METHOD TO UPDATE THIS CURRENT INCIDENT IS MISSING

            //WE WANNA INCREASE THE AMOUNT OF POINTS THE USER HAS AND SAVE THAT NEW VALUE
            //HOW DO WE GET THIS CURRENT USER?

            //MY IDEA IS IN THE UserModel WE SHOULD HAVE A LoggedIn PROPERTY, WHICH DEFAULTS TO FALSE... SO THAT WHEN THE USER LOGS IN AFTER DOING ALL THE CHECKS
            //WE GO TO THE DATABASE AND CHANGE THE VALUE OF THE LoggedIn PROPERTY TO TRUE, THAT WAY WE COULD TO THIS HERE
            //CurrentUserModelFromDB = await dbConnection.GetCurrentUserThatIsLoggedIn(); => THIS METHOD IS BASICALLY LOOPING THROUGH THEDB AND LOOKING FOR A LoggedIn PROPERTY THAT IS TRUE
            //BASIXALLY THE GetPeopleById METHOD BUT FOR LOGGED IN

            UserModelFromDB = await _database.GetPeopleById(currentIncidentReport.ID);
            UserModelFromDB.Point = UserModelFromDB.Point + 10;
            //METHOD TO UPDATE THIS CURRENT USERS POINT IS MISSING

        }

        private async Task ViewIndividualPostCommandAsync(IncidentReport incidentReport)
        {
            var currentIncidentReport = incidentReport;
            IncidentFromDB = await _database.GetIncidentById(currentIncidentReport.ID);
            //NAVIGATE TO THE NEXT PAGE WITH THE CURRENT INCIDENT
            //HOW WE DO THAT?
        }

    }
}
