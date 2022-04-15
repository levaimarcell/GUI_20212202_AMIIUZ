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

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if(model != null && area.Width > 50 && area.Height > 50)
            {
                drawingContext.DrawRectangle(BackgroundBrush, null, new Rect(0, 0, area.Width, area.Height));


                double rectWidth = area.Width / model.GameMatrix.GetLength(1);
                double rectHeight = area.Height / model.GameMatrix.GetLength(0);


                for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                    {
                        ImageBrush brush = new ImageBrush();
                        switch (model.GameMatrix[i, j])
                        {
                            case CharacterLogic.Items.platform:
                                    brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "platform_block.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case CharacterLogic.Items.wall:
                                break;
                            case CharacterLogic.Items.player:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "character1.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case CharacterLogic.Items.end:
                                break;
                            case CharacterLogic.Items.air:
                                break;
                            default:
                                break;
                        }

                        drawingContext.DrawRectangle(brush
                                    , new Pen(Brushes.Black, 0),
                                    new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight)
                                    );
                    }
                }
            }
        }
    }
}
