﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
            CharacterLogic logic = new CharacterLogic();
            display.SetupModel(logic);
            controller = new GameController(logic);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));

            DispatcherTimer gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(100);
            gameTimer.Start();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            controller.KeyDown(e.Key);
            display.InvalidateVisual();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            controller.KeyUp(e.Key);
            display.InvalidateVisual();
        }
    }
}
