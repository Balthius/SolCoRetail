﻿using Caliburn.Micro;
using SRMDesktopUI.Library.Api;
using SRMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SRMDesktopUI.ViewModels
{
    public class UserDisplayViewModel : Screen
    {
        StatusInfoViewModel _status;
        IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;
        BindingList<UserModel> _users;

        public BindingList<UserModel> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }
        private UserModel _selectedUser;

        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                SelectedUserName = value.Email;
                UserRoles = new BindingList<string>(value.Roles.Select(x => x.Value).ToList());
                LoadRoles();
                NotifyOfPropertyChange(() => SelectedUser);
            }
        }

        private string _selectedUserName;

        public string SelectedUserName
        {
            get { return _selectedUserName; }
            set { 
                _selectedUserName = value;

                NotifyOfPropertyChange(() => SelectedUserName);
            }
        }

        private string _selectedUserRole;

        public string SelectedUserRole
        {
            get { return _selectedUserRole; }
            set
            {
                _selectedUserRole = value;

                NotifyOfPropertyChange(() => SelectedUserRole);
            }
        }
         
        private string _selectedAvailableRole;

        public string SelectedAvailableRole
        {
            get { return _selectedAvailableRole; }
            set
            {
                _selectedAvailableRole = value;

                NotifyOfPropertyChange(() => SelectedAvailableRole);
            }
        }


        private BindingList<string> _UserRoles = new BindingList<string>();

        public BindingList<string> UserRoles
        {
            get { return _UserRoles; }
            set
            {

                _UserRoles = value;
                NotifyOfPropertyChange(() => UserRoles);
            }
        }
        private BindingList<string> _availableRoles = new BindingList<string>();

        public BindingList<string> AvailableRoles
        {
            get { return _availableRoles; }
            set
            {
                _availableRoles = value;
                NotifyOfPropertyChange(() => AvailableRoles);
            }
        }


        public UserDisplayViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
        }


        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadUsers();
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

                //var info = IoC.Get<StatusInfoViewModel>(); creates a new copy rather than overwriting the one copy in the constructor. its an option
                if (ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Unauth", "Ya goofed");
                    _window.ShowDialog(_status, null, settings);
                }
                else
                {

                    _status.UpdateMessage("Fatal Exception", ex.Message);
                    _window.ShowDialog(_status, null, settings);
                }
                TryClose();
            }
        }
        private async Task LoadUsers()
        {
            var userList = await _userEndpoint.GetAll();
            Users = new BindingList<UserModel>(userList);
        }

        private async Task LoadRoles()
        {
            var roles = await _userEndpoint.GetAllRoles();
            foreach (var role in roles)
            {
                if (UserRoles.IndexOf(role.Value) < 0)
                {
                    AvailableRoles.Add(role.Value);
                }
            }
        }

        public async void AddSelectedRole()
        {
            await _userEndpoint.AddUserToRole(SelectedUser.Id, SelectedAvailableRole);

            UserRoles.Add(SelectedAvailableRole);
            AvailableRoles.Remove(SelectedAvailableRole);
        }
        public async void RemoveSelectedRole()
        {
            await _userEndpoint.RemoveUserFromRole(SelectedUser.Id, SelectedUserRole);

            UserRoles.Remove(SelectedAvailableRole);
            AvailableRoles.Add(SelectedAvailableRole);
        }
    }
}