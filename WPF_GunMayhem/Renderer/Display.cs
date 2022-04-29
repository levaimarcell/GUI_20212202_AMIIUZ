using System;
using System.Collections.Generic;
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

                drawingContext.DrawRectangle(player1Brush, null, new Rect((area.Width / 2 - 25) + model.Character1.XPosition,
                    0 + model.Character1.YPosition, area.Height / 10, area.Height / 10));
                drawingContext.DrawRectangle(player2Brush, null, new Rect((area.Width / 2 + 25) + model.Character2.XPosition,
                    area.Height / 2 + model.Character2.YPosition, area.Height / 10, area.Height / 10));
           
                foreach (var item in model.Bullets)
                {
                    if (item.Direction)
                    {
                        drawingContext.DrawRectangle(new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bullet.png"), UriKind.RelativeOrAbsolute))),
                        null, new Rect(item.XPosition, item.YPosition + (area.Height / 28), area.Height / 100, area.Height / 100));
                    }
                    else
                    {
                        drawingContext.DrawRectangle(new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bullet.png"), UriKind.RelativeOrAbsolute))),
                        null, new Rect((item.XPosition - area.Height / 40), item.YPosition + (area.Height / 28), area.Height / 100, area.Height / 100));
                    }
                }
            }
        }
    }
}
