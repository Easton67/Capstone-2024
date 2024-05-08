using LogicLayer;
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
using WpfPresentation.Pages.Housekeeping;

namespace WpfPresentation.Pages.User
{
    /// <summary>
    /// Creator:            Sagan Dewald
    /// Created:            02/04/2024
    /// Summary:            Creation of pgClientPriorty Page
    /// Last Updated By:    Sagan DeWald
    /// Last Updated:       03/29/2024
    /// What Was Changed:   Initial Creation
    /// </summary>
    public partial class pgClientPriority : Page
    {
        private MainManager _mainManager;
        private IClientPriorityManager _clientPriorityManager;
        private static pgClientPriority instance = null;

        /// <summary>
        /// Creator:            Sagan Dewald
        /// Created:            02/04/2024
        /// Summary:            Default constructor for "production."
        /// Last Updated By:    Sagan DeWald
        /// Last Updated:       03/29/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public pgClientPriority()
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
            _clientPriorityManager = new ClientPriorityManager();
        }

        /// <summary>
        /// Creator:            Sagan Dewald
        /// Created:            02/04/2024
        /// Summary:            Alternative constructor for testing purposes.
        /// Last Updated By:    Sagan DeWald
        /// Last Updated:       03/29/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        public pgClientPriority(IClientPriorityManager clientPriorityManager)
        {
            InitializeComponent();
            _mainManager = MainManager.GetMainManager();
            _clientPriorityManager = clientPriorityManager;
        }

        public static pgClientPriority GetClientPriorityPage()
        {
            return instance ?? (instance = new pgClientPriority());
        }

        /// <summary>
        /// Creator:            Sagan Dewald
        /// Created:            02/04/2024
        /// Summary:            If you have been convicted of a crime, you must explain it. Displays or hides the text box for doing so.
        /// Last Updated By:    Sagan DeWald
        /// Last Updated:       03/29/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        void rbConvicted_Checked(object sender, RoutedEventArgs e)
        {
            if (stckPnl_crimeExplanation == null || !stckPnl_crimeExplanation.IsLoaded)
            {
                return;
            }

            if((bool)rbConvicted_Yes.IsChecked)
            {
                stckPnl_crimeExplanation.Visibility = Visibility.Visible;
            }
            else
            {
                stckPnl_crimeExplanation.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Creator:            Sagan Dewald
        /// Created:            02/04/2024
        /// Summary:            If your housing situations does not match the other choices, you must explain it. Displays and hides the text box for doing so.
        /// Last Updated By:    Sagan DeWald
        /// Last Updated:       03/29/2024
        /// What Was Changed:   Initial Creation
        /// </summary>
        void cb_residenceSelection_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(stckPnl_otherResidenceExplanation == null || !stckPnl_otherResidenceExplanation.IsLoaded)
            {
                return;
            }

            string residenceSelection = (string) ( (ComboBoxItem) cb_residenceSelection.SelectedItem ).Content;

            if(residenceSelection == "Other")
            {
                stckPnl_otherResidenceExplanation.Visibility = Visibility.Visible;
            }
            else
            {
                stckPnl_otherResidenceExplanation.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Creator:            Sagan Dewald
        /// Created:            02/04/2024
        /// Summary:            Performs input validation. Submits a row to the ClientPriority table if everything is fine, displays a MessageBox error if not.
        ///Last Updated By:    Mitchell Stirmel
        ///Last Updated:       04/11/2024
        ///What Was changed:   Added try catch
        /// </summary>
        void btn_submitClientPriority_Click(object sender, RoutedEventArgs e)
        {
            string errorText = null;
            if(cb_residenceSelection.Text == "Other" && tb_otherResidenceExplanation.Text == "")
            {
                errorText = "You must give a written explanation of your housing situation.";
            }

            if((bool)rbConvicted_Yes.IsChecked && tb_crimeExplanation.Text == "")
            {
                if(errorText != null)
                {
                    errorText = errorText + "\n\n";
                }
                errorText = errorText + "You must explain what crime you were convicted of and why.";
            }

            if(errorText != null)
            {
                MessageBox.Show(errorText, "Client Priority Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int basePriority = 1; //"Other" housing situation is lowest by default, but their explanation is stored to be reviewed and manually adjusted later.
            int deductions = 0;

            if(cb_residenceSelection.SelectedIndex == 0) //Currently homeless.
            {
                basePriority = 4;
            }
            else if(cb_residenceSelection.SelectedIndex == 1) //In danger of being homeless within two weeks.
            {
                basePriority = 3;
            }
            else if(cb_residenceSelection.SelectedIndex == 2) //Unstable housing.
            {
                basePriority = 2;
            }

            //Lower their priority be default if convicted of a crime, but their explanation is stored so this can be reviewed and possibly reversed later.
            if((bool)rbConvicted_Yes.IsChecked)
            {
                deductions++;
            }

            try
            {
                _clientPriorityManager.AddClientPriority(_mainManager.LoggedInUser.UserID, basePriority, deductions, tb_crimeExplanation.Text, tb_otherResidenceExplanation.Text);
                MessageBox.Show("Client Priority successfully added to the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to add client priority \n" + ex.ToString(), "Failure", MessageBoxButton.OK);
            }

        }
    }
}
