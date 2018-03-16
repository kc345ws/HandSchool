﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HandSchool.Views
{
    // Thanks to 山宏岳
    public class PopContentPage : ContentPage
	{
        public PopContentPage()
        {
            Disappearing += Page_Disappearing;
        }

        private bool IsModal = false;
        
        private Task ContinueTask { get; } = new Task(() => { });

        public Task ShowAsync(INavigation navigation = null)
        {
            if(navigation is null)
            {
                App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(this));
                IsModal = true;
            }
            else
            {
                navigation.PushAsync(this);
            }
            return ContinueTask;
        }

        public async Task Close()
        {
            if (IsModal)
                await Navigation.PopModalAsync();
            else
                await Navigation.PopAsync();
        }

        private bool _destoried;

        private void Page_Disappearing(object sender, EventArgs e)
        {
            if (_destoried)
            {
                return;
            }
            _destoried = true;
            Disappearing -= Page_Disappearing;

            ContinueTask?.Start();
        }
    }
}