﻿using HandSchool.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HandSchool.Models
{
    public class CurriculumLabel : StackLayout
    {
        public CurriculumItem Context { get; }
        public Span Title = new Span { FontAttributes = FontAttributes.Bold, ForegroundColor = Color.White };
        public Span At = new Span { Text = " @ ", ForegroundColor = Color.FromRgba(255, 255, 255, 160) };
        public Span Where = new Span { ForegroundColor = Color.FromRgba(255, 255, 255, 220) };

        public CurriculumLabel(CurriculumItem value)
        {
            Context = value;
            Padding = new Thickness(3);
            Children.Add(new Label {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FormattedText = new FormattedString { Spans = { Title, At, Where } },
                VerticalOptions = HorizontalOptions = LayoutOptions.CenterAndExpand
            });
            Update();
            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await ItemTapped()),
                NumberOfTapsRequired = 2
            });
        }

        public void Update()
        {
            Grid.SetColumn(this, Context.WeekDay);
            Grid.SetRow(this, Context.DayBegin);
            Grid.SetRowSpan(this, Context.DayEnd - Context.DayBegin + 1);
            Title.Text = Context.Name;
            Where.Text = Context.Classroom;
            BackgroundColor = GetColor();
        }

        private async Task ItemTapped()
        {
            var p = new CurriculumPage(Context);
            await p.ShowAsync(Navigation);
        }

        public Color GetColor()
        {
            return Color.LimeGreen;
        }
    }
}
