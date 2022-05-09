using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPF_GunMayhem.Logic;

namespace WPF_GunMayhem.Renderer
{
    internal class Display : FrameworkElement
    {
        Size area;
        IGameModel model;

        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
        }
        public Brush BackgroundBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "background.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if(model != null && area.Width > 50 && area.Height > 50)
            {
                drawingContext.DrawRectangle(BackgroundBrush, null, new Rect(0, 0, area.Width, area.Height));

                foreach (var item in model.Platforms)
                {

                    drawingContext.DrawRectangle(new SolidColorBrush(Color.FromRgb(88, 49, 1)),
                    null, new Rect(item.XPosition, item.YPosition, item.Width, item.Height));

                }

                ImageBrush brush = new ImageBrush();
                ImageBrush player1Brush = new ImageBrush();
                ImageBrush player2Brush = new ImageBrush();

                if (model.Character1.Direction == true)
                {
                    player1Brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "character1.png"), UriKind.RelativeOrAbsolute)));
                }
                else
                {
                    player1Brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "character1_left.png"), UriKind.RelativeOrAbsolute)));
                }

                if (model.Character2.Direction == true)
                {
                    player2Brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "character1.png"), UriKind.RelativeOrAbsolute)));
                }
                else
                {
                    player2Brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "character1_left.png"), UriKind.RelativeOrAbsolute)));
                }

                drawingContext.DrawRectangle(player1Brush, null, new Rect(model.Character1.XPosition, model.Character1.YPosition, area.Height / 10, area.Height / 10));
                drawingContext.DrawRectangle(player2Brush, null, new Rect(model.Character2.XPosition, model.Character2.YPosition, area.Height / 10, area.Height / 10));
           
                foreach (var item in model.Bullets)
                {
                    if (item.Direction)
                    {
                        drawingContext.DrawRectangle(new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bullet.png"), UriKind.RelativeOrAbsolute))),
                        null, new Rect(item.XPosition + area.Height / 12, item.YPosition + (area.Height / 28), area.Height / 100, area.Height / 100));
                    }
                    else
                    {
                        drawingContext.DrawRectangle(new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bullet.png"), UriKind.RelativeOrAbsolute))),
                        null, new Rect(item.XPosition, item.YPosition + (area.Height / 28), area.Height / 100, area.Height / 100));
                    }
                }

                drawingContext.DrawRectangle(new SolidColorBrush(Color.FromRgb(33,158,188)),null, new Rect(0, 0, area.Width / 6, area.Height / 10));
                drawingContext.DrawRectangle(new SolidColorBrush(Color.FromRgb(33, 158, 188)), null, new Rect(area.Width - area.Width / 6, 0, area.Width -  area.Width / 6, area.Height / 10));

                string firstText = "Player1: " + model.Character1.Life.ToString() + " life";
                drawingContext.DrawText(new FormattedText(firstText, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), area.Width / 60, Brushes.White), new Point(10, 10));
                string secondText = "Player2: " + model.Character2.Life.ToString() + " life";
                drawingContext.DrawText(new FormattedText(secondText, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), area.Width / 60, Brushes.White),
                    new Point(area.Width - area.Width / 6 + 10, 10));
            }
        }
    }
}
