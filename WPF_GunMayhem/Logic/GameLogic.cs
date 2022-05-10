using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GunMayhem.Logic
{
    internal class GameLogic : IGameModel
    {

        public enum Items
        {
            player, air, platform, wall, end
        }

        public enum Controls
        {
            Left, Right, Up, Down, Shoot
        }

        public Player Character1 { get; set; }
        public Player Character2 { get; set; }
        public List<Bullet> Bullets { get; set; }
        public List<Platform> Platforms { get; set; }

        public event EventHandler Changed;
        public event EventHandler GameOver;
        Size area;
       
        public void SetupSizes(Size area)
        {
            this.area = area;
            Platforms = new List<Platform>();
            SetupPlatfroms();
            SetupCharacters();
        }

        public GameLogic()
        {
        }

        public void SetupCharacters()
        {
            Character1 = new Player(area.Width / 4, 0, true);
            Character2 = new Player(area.Width - area.Width / 4 - area.Height / 10, 0, false);
            Bullets = new List<Bullet>();
        }

        public void ControlCharacter1()
        {
            if (Character1.Left)
            {
                Character1.MoveLeft(area);
            }
            if (Character1.Right)
            {
                Character1.MoveRigth(area);
            }
            if (Character1.Jump)
            {
                if (Character1.JumpCount <= 2)
                {
                    Character1.Fall = false;
                    bool jumping = Character1.JumpMove(area);
                    if (!jumping)
                    {
                        Character1.Jump = false;
                        Character1.Fall = true;
                    }
                }
                else
                {
                    Character1.Jump = false;
                }
            }
            if (Character1.Down)
            {
                Character1.Fall = false;
                bool down = Character1.DownMove(area);
                if (!down)
                {
                    Character1.Down = false;
                    Character1.Fall = true;
                }
            }
            if (Character1.Fall)
            {
                Character1.FallMove(area, Platforms);
                if(Character1.Life < 0)
                {
                    GameOver?.Invoke(this, null);
                }
            }
            if (Character1.Shoot)
            {
                if (Character1.Direction)
                {
                    Bullets.Add(new Bullet(Character1.XPosition ,Character1.YPosition, new Vector(area.Height / 50, 0), true, 1));
                }
                else
                {
                    Bullets.Add(new Bullet(Character1.XPosition, Character1.YPosition, new Vector(-area.Height / 50, 0), false, 1));
                }
                Character1.Shoot = false;
            }
        }

        public void ControlCharacter2()
        {
            if (Character2.Left)
            {
                Character2.MoveLeft(area);
            }
            if (Character2.Right)
            {
                Character2.MoveRigth(area);
            }
            if (Character2.Jump)
            {
                if (Character2.JumpCount <= 2)
                {
                    Character2.Fall = false;
                    bool jumping = Character2.JumpMove(area);
                    if (!jumping)
                    {
                        Character2.Jump = false;
                        Character2.Fall = true;
                    }
                }
                else
                {
                    Character2.Jump = false;
                }
            }
            if (Character2.Down)
            {
                Character2.Fall = false;
                bool down = Character2.DownMove(area);
                if (!down)
                {
                    Character2.Down = false;
                    Character2.Fall = true;
                }
            }
            if (Character2.Fall)
            {
                Character2.FallMove(area, Platforms);
                if (Character2.Life < 0)
                {
                    GameOver?.Invoke(this, null);
                }
            }
            if (Character2.Shoot)
            {
                if (Character2.Direction)
                {
                    Bullets.Add(new Bullet(Character2.XPosition, Character2.YPosition, new Vector(area.Height / 50, 0), true, 2));
                }
                else
                {
                    Bullets.Add(new Bullet(Character2.XPosition, Character2.YPosition, new Vector(-area.Height / 50, 0), false, 2));
                }
                Character2.Shoot = false;
            }
        }

        public void TimeStep()
        {
            ControlCharacter1();
            ControlCharacter2();

            for (int i = 0; i < Bullets.Count; i++)
            {
                bool inside = Bullets[i].Move(area);
                if (!inside)
                {
                    Bullets.RemoveAt(i);
                }
                else
                {
                    Rect bulletRect = new Rect(Bullets[i].XPosition, Bullets[i].YPosition, 4, 4);
                    Rect character1Rect = new Rect(Character1.XPosition, Character1.YPosition, area.Height / 10, area.Height / 10);
                    Rect character2Rect = new Rect(Character2.XPosition, Character2.YPosition, area.Height / 10, area.Height / 10);
                    if (bulletRect.IntersectsWith(character1Rect) && Bullets[i].Character != 1)
                    {
                        if (Bullets[i].Direction)
                        {
                            Character1.XPosition += area.Width / 10;
                        }
                        else
                        {
                            Character1.XPosition -= area.Width / 10;
                        }
                        Bullets.RemoveAt(i);
                        Character1.Fall = true;
                    }
                    if (bulletRect.IntersectsWith(character2Rect) && Bullets[i].Character != 2)
                    {
                        if (Bullets[i].Direction)
                        {
                            Character2.XPosition += area.Width / 10;
                        }
                        else
                        {
                            Character2.XPosition -= area.Width / 10;
                        }
                        Bullets.RemoveAt(i);
                        Character2.Fall = true;
                    }
                }
            }

            Changed?.Invoke(this, null);
        }

        public void SetupPlatfroms()
        {
            double areaWidthMiddle = area.Width / 2;
            double areaHeightMiddle = area.Height / 2 - area.Height / 60;
            double layerHeight = area.Height / 6;
            double platformHeight = area.Height / 30;

            Platforms.Add(new Platform(areaWidthMiddle - area.Width / 6, areaHeightMiddle, area.Width / 3, platformHeight));

            Platforms.Add(new Platform(areaWidthMiddle - area.Width / 20, areaHeightMiddle - layerHeight, area.Width / 10, platformHeight));

            Platforms.Add(new Platform(areaWidthMiddle - area.Width / 3, areaHeightMiddle - layerHeight, area.Width / 6, platformHeight));

            Platforms.Add(new Platform(areaWidthMiddle + area.Width / 3 - area.Width / 6, areaHeightMiddle - layerHeight, area.Width / 6, platformHeight));

            Platforms.Add(new Platform(areaWidthMiddle - area.Width / 3, areaHeightMiddle + layerHeight, area.Width / 6, platformHeight));

            Platforms.Add(new Platform(areaWidthMiddle + area.Width / 3 - area.Width / 6, areaHeightMiddle + layerHeight, area.Width / 6, platformHeight));

            Platforms.Add(new Platform(areaWidthMiddle - area.Width / 6, areaHeightMiddle + layerHeight * 2, area.Width / 3, platformHeight));
        }
    }
}
