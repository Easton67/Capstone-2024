using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfPresentation
{
    /// <summary>
    /// Creator:            Tyler Barz
    /// Created:            02/13/2024
    /// Summary:            Add basic ability to close parent window from within page
    /// Last Updated By:    Tyler Barz
    /// Last Updated:       02/13/2024
    /// What Was Changed:   Inital creation
    /// </summary>
    public static class CloseWindow
    {
        public static Window win = null;
        public static void CloseParent()
        {
            if(win != null)
            {
                win.Close();
            }
        }
    }
}
