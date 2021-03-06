﻿using HandSchool.Models;
using HandSchool.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HandSchool.UWP
{
    public sealed partial class GradePointPage : ViewPage
    {
        public GradePointPage()
        {
            InitializeComponent();
            BindingContext = GradePointViewModel.Instance;
        }

        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is IGradeItem iGi)
            {
                var info = string.Format(
                    "名称：{0}\n类型：{1}\n学期：{2}\n发布日期：{3}\n" +
                    "学分：{4}\n分数：{5}\n绩点：{6}\n通过：{7}\n重修：{8}",
                    iGi.Name, iGi.Type, iGi.Term, iGi.Date.ToString(),
                    iGi.Credit, iGi.Score, iGi.Point, iGi.Pass ? "是" : "否", iGi.ReSelect ? "是" : "否");

                foreach (var key in iGi.Attach.Keys)
                {
                    info += "\n" + key + "：" + iGi.Attach.Get((string)key);
                }

                await Internal.Helper.ShowMessage("成绩详情", info, "确定");
            }
        }

        private async void GPAButton_Click(object sender, RoutedEventArgs e)
        {
            var gpa = await GradePointViewModel.Instance.ExcuteLoadGPACommand();
            await Internal.Helper.ShowMessage("学分绩点统计", gpa, "确定");
        }
    }
}
