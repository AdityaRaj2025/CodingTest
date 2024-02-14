using RouteLibrary;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RailwayTask
{
    public partial class MainWindow : Window
    {
        private readonly IRecordRepository _recordRepository;
        private ObservableCollection<Record> records;

        public MainWindow(IRecordRepository recordRepository)
        {
            InitializeComponent();
            _recordRepository = recordRepository;

            SetUserInformation();
            LoadRecords();
        }

        private void SetUserInformation()
        {
            roleTextBlock.Text = UserContext.UserRole;
            userTextBlock.Text = Environment.UserName;
        }

        private void LoadRecords()
        {
            records = _recordRepository.LoadRecords();
            dataGrid.ItemsSource = records;
        }

        private void AddOrUpdateRecord(Record existingRecord = null)
        {
            AddRecordWindow addOrUpdateRecordWindow = new AddRecordWindow(existingRecord);
            if (addOrUpdateRecordWindow.ShowDialog() == true)
            {
                var newRecord = addOrUpdateRecordWindow.NewRecord;
                if (newRecord.Distance < 0)
                {
                    MessageBox.Show("Distance cannot be less than 0.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                newRecord.ReferenceCode = _recordRepository.GenerateReferenceCode(newRecord);
                if (existingRecord != null)
                {
                    _recordRepository.UpdateRecord(newRecord);
                }
                else
                {
                    _recordRepository.AddRecord(newRecord);
                }

                LoadRecords(); 
            }
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            AddOrUpdateRecord();
        }

        private void UpdateRecord_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                if (UserContext.UserRole == "Admin")
                {
                    var selectedRecord = (Record)dataGrid.SelectedItem;
                    AddOrUpdateRecord(selectedRecord);
                }
                else
                {
                    MessageBox.Show("You don't have permission to update records.");
                }
            }
            else
            {
                MessageBox.Show("Please select a record to update.");
            }
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                if (UserContext.UserRole == "Admin")
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var selectedRecord = (Record)dataGrid.SelectedItem;
                        _recordRepository.DeleteRecord(selectedRecord);
                        LoadRecords(); 
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to delete records.");
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void TrackData_Click(object sender, RoutedEventArgs e)
        {
            RailwayTrackRouteData trackRouteDataWindow = new RailwayTrackRouteData();
            trackRouteDataWindow.Show();
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

    }
}
