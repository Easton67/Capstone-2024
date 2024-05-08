using DataObjects;
using LogicLayer;
using System.Windows;
using System.Windows.Input;
using WpfPresentation.Pages.Login;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// Creator: Tyler Barz          
    /// Created: 02/11/2024
    /// Summary: Created LoginWindow, and styled
    /// Last Updated By: Tyler Barz
    /// Last Updated: 02/24/2024
    /// What Was Changed: Removed test code, implemented login page
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            FrameLoad.Navigate(new pgLogin());
        }

        /// <summary>
        /// Creator: Tyler Barz          
        /// Created: 02/11/2024
        /// Summary: Adding draggablity to the window, as I removed the default windows border
        /// Last Updated By: Tyler Barz
        /// Last Updated: 02/11/2024
        /// What Was Changed: Inital creation
        /// </summary>
        #region Minimize, Close, Drag
        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Store this window, so you have the ability to close within login page
            CloseWindow.win = this;
        }
    }
}
