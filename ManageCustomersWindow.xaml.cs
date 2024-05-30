using System.Windows;
using TravelAgencyLibrary.Models;
using TravelAgencyLibrary.Services;

namespace TravelAgencyApp
{
    public partial class ManageCustomersWindow : Window
    {
        private readonly DataService _dataService;

        public ManageCustomersWindow(DataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
            CustomersListBox.ItemsSource = _dataService.Customers;
        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var newCustomer = new Customer
            {
                Name = "New Customer",
                Email = "email@example.com"
            };
            _dataService.Customers.Add(newCustomer);
            CustomersListBox.Items.Refresh();
        }
    }
}