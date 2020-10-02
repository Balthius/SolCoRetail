using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using SRMDesktopUI.EventModels;
using SRMDesktopUI.Library.Api;
using SRMDesktopUI.Library.Models;

namespace SRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {

        
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private ILoggedInUserModel _user;
        private IApiHelper _apiHelper;
        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, ILoggedInUserModel user, IApiHelper apiHelper)
        {
            _events = events;
            _salesVM = salesVM;
            _user = user;
            _apiHelper = apiHelper;

            _events.Subscribe(this);
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public bool IsLoggedIn
        {
            get   
            {
                bool output = false;
                    if (string.IsNullOrWhiteSpace(_user.Token) == false)
                    {
                        output = true;
                    }

                return output;
            }
        }

        public void ExitApplication()
        {
            TryClose();
        }

        public void userManagement()
        {
            ActivateItem(IoC.Get<UserDisplayViewModel>());

        }


        public void LogOut()
        {
            _user.ResetUserModel();
            _apiHelper.LoggOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
