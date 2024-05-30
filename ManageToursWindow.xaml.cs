using System;
using System.Windows;
using TravelAgencyLibrary.Models;
using TravelAgencyLibrary.Services;

namespace TravelAgencyApp
{
    public partial class ManageToursWindow : Window
    {
        private readonly DataService _dataService;

        public ManageToursWindow(DataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
            ToursListBox.ItemsSource = _dataService.Tours;
        }

        private void AddTourButton_Click(object sender, RoutedEventArgs e)
        {
            var newTour = new Tour
            {
                Name = "New Tour",
                Description = "Description",
                Price = 100,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(7)
            };
            _dataService.Tours.Add(newTour);
            ToursListBox.Items.Refresh();
        }
    }
}