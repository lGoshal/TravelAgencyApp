using System;
using System.Windows;
using TravelAgencyLibrary.Services;

namespace TravelAgencyApp
{
    public partial class MainWindow : Window
    {
        private readonly DataService _dataService;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                _dataService = new DataService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing data service: {ex.Message}");
                throw;
            }
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                _dataService.SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}");
            }
        }

        private void ManageToursButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manageToursWindow = new ManageToursWindow(_dataService);
                manageToursWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Tours window: {ex.Message}");
            }
        }

        private void ManageCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manageCustomersWindow = new ManageCustomersWindow(_dataService);
                manageCustomersWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Customers window: {ex.Message}");
            }
        }
    }
}