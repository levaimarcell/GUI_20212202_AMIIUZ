using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_GunMayhem.Logic;

namespace WPF_GunMayhem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CharacterLogic logic;
        public MainWindow()
        {
            InitializeComponent();
            logic = new CharacterLogic();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                logic.Control(CharacterLogic.Controls.Left);
            }
            else if(e.Key == Key.Right)
            {
                logic.Control(CharacterLogic.Controls.Right);
            }
            else if (e.Key == Key.Up)
            {
                logic.Control(CharacterLogic.Controls.Up);
            }
            else if(e.Key == Key.Down)
            {
                logic.Control(CharacterLogic.Controls.Down);
            }
            else if(e.Key== Key.Space)
            {
                logic.Control(CharacterLogic.Controls.Shoot);
            }
        }
    }
}
