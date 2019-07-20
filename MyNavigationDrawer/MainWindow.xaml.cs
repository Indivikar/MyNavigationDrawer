using MaterialDesignThemes.Wpf;
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

namespace MyNavigationDrawer
{
    // Tutorial
    // https://github.com/Abel13/NavigationDrawer

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //protected override void OnStateChanged(EventArgs e)
        //{
        //    if (this.WindowState == System.Windows.WindowState.Maximized /* && some conditions*/)
        //    {
        //        Console.WriteLine("WindowState Max");
        //        Btnmax.Content = new PackIcon { Kind = PackIconKind.WindowRestore };
        //    }

        //    else if (this.WindowState != System.Windows.WindowState.Maximized /* && other conditions*/)
        //    {
        //        Console.WriteLine("WindowState Min");
        //        Btnmax.Content = new PackIcon { Kind = PackIconKind.WindowMaximize };
        //    }

        //}

        private void ButtonWindowMin_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("set Window Max");
            WindowState = WindowState.Minimized;
        }

        private void ButtonWindowMax_Click(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == System.Windows.WindowState.Maximized /* && some conditions*/)
            {
                Console.WriteLine("WindowState Max");
                WindowState = WindowState.Normal;
                Btnmax.Content = new PackIcon { Kind = PackIconKind.WindowRestore };
            }

            else if (this.WindowState != System.Windows.WindowState.Maximized /* && other conditions*/)
            {
                Console.WriteLine("WindowState Min");
                WindowState = WindowState.Maximized;
                Btnmax.Content = new PackIcon { Kind = PackIconKind.WindowMaximize };

            }
        
        }

        private void ButtonWindowClose_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("set Window Close");
            System.Windows.Application.Current.Shutdown();
        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void Rectangle_PreviewMouseDown(object sender, RoutedEventArgs e) {
            Console.WriteLine("Click");
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlHome();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    usc = new UserControlCreate();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
    }
}
