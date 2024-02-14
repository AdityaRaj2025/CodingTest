using RouteLibrary;
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
using System.Windows.Shapes;

namespace RailwayTask
{
    public partial class AddRecordWindow : Window
    {
        private readonly IRecordRepository _recordRepository;

        public Record NewRecord { get; private set; }

        public AddRecordWindow(Record existingRecord = null, IRecordRepository recordRepository = null)
        {
            InitializeComponent();

            _recordRepository = recordRepository ?? new RecordRepository();

            if (existingRecord != null)
            {
                routeTitleTextBox.Text = existingRecord.RouteTitle;
                firstStationTextBox.Text = existingRecord.FirstStation;
                lastStationTextBox.Text = existingRecord.LastStation;
                distanceTextBox.Text = existingRecord.Distance.ToString();
                statusTextBox.Text = existingRecord.Status;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(routeTitleTextBox.Text) ||
                string.IsNullOrWhiteSpace(firstStationTextBox.Text) ||
                string.IsNullOrWhiteSpace(lastStationTextBox.Text) ||
                string.IsNullOrWhiteSpace(distanceTextBox.Text) ||
                string.IsNullOrWhiteSpace(statusTextBox.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            decimal distance;
            if (!decimal.TryParse(distanceTextBox.Text, out distance))
            {
                MessageBox.Show("Invalid distance value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (distance < 0)
            {
                MessageBox.Show("Distance cannot be less than 0.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewRecord = new Record
            {
                RouteTitle = routeTitleTextBox.Text,
                FirstStation = firstStationTextBox.Text,
                LastStation = lastStationTextBox.Text,
                Distance = distance,
                Status = statusTextBox.Text,
                CreatedDatetime = DateTime.Now
            };

            /* Generate reference code for the new record using the injected repository */
            NewRecord.ReferenceCode = _recordRepository.GenerateReferenceCode(NewRecord);

            DialogResult = true;
        }
    }
}