﻿using HandSchool.Models;
using Xamarin.Forms;

namespace HandSchool.Views
{
    public class MessageDetailPage : PopContentPage
	{
		public MessageDetailPage(IMessageItem item)
		{
            Title = "消息详情";
            ToolbarItems.Add(new ToolbarItem() { Text = "删除", Command = item.Delete });
            Content = new StackLayout
            {
                Spacing = 10,
                Padding = new Thickness(20),
                Children = {
                    new Label { Text = item.Title, FontSize = 24, TextColor = Color.Black },
                    new Label { Text = "发件人：" + item.Sender, FontSize = 14 },
                    new Label { Text = "时间：" + item.Time.ToString(), FontSize = 14 },
                    new BoxView { Color=Color.Gray, Margin = new Thickness(0,5,0,5), HeightRequest = 1 },
                    new Label { Text = item.Body, FontSize = 16 }
                }
            };
		}

        public MessageDetailPage(FeedItem item)
        {
            Title = "通知详情";
            ToolbarItems.Add(new ToolbarItem { Text = "详情", Command = new Command(() => Device.OpenUri(new System.Uri(item.Link))) });
            Content = new StackLayout
            {
                Spacing = 10,
                Padding = new Thickness(20),
                Children = {
                    new Label { Text = item.Title, FontSize = 24, TextColor = Color.Black },
                    new Label { Text = "分类：" + item.Category, FontSize = 14 },
                    new Label { Text = "时间：" + item.PubDate, FontSize = 14 },
                    new BoxView { Color=Color.Gray, Margin = new Thickness(0,5,0,5), HeightRequest = 1 },
                    new ScrollView
                    {
                        Content = new Label { Text = item.Description.Replace(' ', '\n'), FontSize = 16, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand },
                        Orientation = ScrollOrientation.Vertical
                    }
                }
            };
        }
	}
}
