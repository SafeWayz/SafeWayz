using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SafeWayz.Models;
using SafeWayz.Services;
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
        private DelegateCommand _upvoteThisPost;

        private IList<IncidentReport> _incidentsFromDB;


        //PUBLIC PROPERTIES
        /////////////////////////////////////////////////////////////////////////////
        public DelegateCommand UpvoteThisPost =>
            _upvoteThisPost ?? (_upvoteThisPost = new DelegateCommand(async () => await UpvoteThisPostCommand()));


        public IList<IncidentReport> IncidentsFromDB
        {
            get { return _incidentsFromDB; }
            set { SetProperty(ref _incidentsFromDB, value); }
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
            var dbConnection = new SafeWayZDatabase();
            IncidentsFromDB = await dbConnection.GetAllIncidentReportInformationData();
        }

        private Task UpvoteThisPostCommand()
        {
            throw new NotImplementedException();
        }


    }
}
