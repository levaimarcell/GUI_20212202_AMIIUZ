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
using WPF_GunMayhem.Controller;
using System.Windows.Threading;

namespace WPF_GunMayhem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameController controller;
        GameLogic logic;
        public MainWindow()
        {
            InitializeComponent();  
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new GameLogic();
            display.SetupModel(logic);
            controller = new GameController(logic);

            DispatcherTimer gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(40);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            logic.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
        }

        private void GameTimer_Tick(object? sender, EventArgs e)
        {
            logic.TimeStep();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(logic != null)
            {
                display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
                logic.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            controller.KeyDown(e.Key);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            controller.KeyUp(e.Key);
        }
    }
}
