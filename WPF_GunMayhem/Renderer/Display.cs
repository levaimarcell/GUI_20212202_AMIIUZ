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
        }
        public Brush BackgroundBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "background.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush CharacterBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "character1.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if(area.Width > 0 && area.Height > 0)
            {
                drawingContext.DrawRectangle(BackgroundBrush, null, new Rect(0, 0, area.Width, area.Height));


                drawingContext.DrawRectangle(CharacterBrush, null, new Rect(area.Width / 2, area.Height / 2, 50, 50));
            }
        }
    }
}
