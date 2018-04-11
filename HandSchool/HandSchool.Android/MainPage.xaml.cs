﻿using HandSchool.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandSchool.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
    {
		public MainPage()
		{
			InitializeComponent();

            Outline.PrimaryListView.ItemSelected += MasterPageItemSelected;
            Outline.SecondaryListView.ItemSelected += MasterPageItemSelected;
            
            Detail = NavigationViewModel.Instance.PrimaryItems[0].DestPage;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(App.Current.Service.NeedLogin && !App.Current.Service.IsLogin)
            {
                LoginViewModel.RequestAsync(App.Current.Service);
            }
        }

        private async void MasterPageItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MasterPageItem item)
            {
                Detail = item.DestPage;
                
                (sender as ListView).SelectedItem = null;

                NavigationViewModel.Instance.PrimaryItems.ForEach((one) => one.Selected = false);
                NavigationViewModel.Instance.SecondaryItems.ForEach((one) => one.Selected = false);

                item.Selected = true;

                // Funny fucky question: why this makes fluency?
                await Task.Delay(200);
                IsPresented = false;
            }
        }
    }
}