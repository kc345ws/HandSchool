﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using HandSchool.Internal;
using HandSchool.ViewModels;
using HandSchool.Views;
using Xamarin.Forms;

namespace HandSchool
{
	public partial class App : Application
	{
        public App()
        {
            InitializeComponent();
            var loaded = Core.Initialize();
            MainPage = NavigationViewModel.GetMainPage();
        }
        
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
#if !_UWP_
            (Application.Current.MainPage as MainPage).Detail = new ContentPage();
               
#endif

            // Handle when your app sleeps
        }

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
    }
}
