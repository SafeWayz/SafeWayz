using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SafeWayz.ViewModels
{
    public class AllCommunityPostsViewModel : ViewModelBase
    {
        public AllCommunityPostsViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
    }
}
