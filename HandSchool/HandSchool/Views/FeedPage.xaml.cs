﻿using HandSchool.Models;
using HandSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandSchool.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeedPage : ContentPage
    {
        public bool IsPushing { get; set; } = false;
        public FeedPage()
        {
            InitializeComponent();
            BindingContext = FeedViewModel.Instance;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null|IsPushing==true)
                return;
            IsPushing = true;
            await (new MessageDetailPage(e.Item as FeedItem)).ShowAsync(Navigation);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            IsPushing = false;
        }

    }
}