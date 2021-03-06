﻿using HandSchool.Internal;
using HandSchool.Models;
using HandSchool.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HandSchool.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; set; }
        public ILoginField Form { get; }
#if __UWP__
        public UWP.LoginDialog Page { get; set; }
#else
        public LoginPage Page { get; set; }
#endif
        
        private LoginViewModel(ILoginField form)
        {
            Form = form;
        }

        public static async Task<bool> RequestAsync(ILoginField form)
        {
            var viewModel = new LoginViewModel(form);
            viewModel.LoginCommand = new Command(viewModel.Login);
#if __UWP__
            viewModel.Page = new UWP.LoginDialog(viewModel);
            await viewModel.Page.ShowAsync();
#else
            viewModel.Page = new LoginPage(viewModel);
            await viewModel.Page.ShowAsync();
#endif
            return form.IsLogin;
        }
        
        async void Login()
        {
            if (IsBusy)
            {
                Page.Response(this, new LoginStateEventArgs(LoginState.Processing));
                return;
            }

            IsBusy = true;

            var callback = Helper.ShowLoadingAlert("正在登录……");
            Form.LoginStateChanged += Page.Response;

            try
            {
                await Form.Login();
            }
            finally
            {
                IsBusy = false;
                callback.Invoke();
                Form.LoginStateChanged -= Page.Response;
            }
        }
    }
}
