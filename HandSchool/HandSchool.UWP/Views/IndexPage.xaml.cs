﻿using HandSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace HandSchool.UWP
{
    public sealed partial class IndexPage : ViewPage
    {
        public int TextSize=20;
        public int LineLenth = 500;

        public IndexPage()
        {
            InitializeComponent();
            BindingContext = IndexViewModel.Instance;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await LoginViewModel.RequestAsync(Core.App.Service);
        }
    }
}
