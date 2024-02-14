using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using RouteLibrary;

namespace RailwayTask
{
    public partial class RailwayTrackRouteData : Window
    {
        private List<RoutesData> allRoutes;

        public RailwayTrackRouteData()
        {
            InitializeComponent();
            InitializeUserInfo();
        }

        private void InitializeUserInfo()
        {
            roleTextBlock.Text = UserContext.UserRole;
            userTextBlock.Text = Environment.UserName;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "CSV Files (*.csv)|*.csv"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string csvFilePath = openFileDialog.FileName;

                if (CheckFileSize(csvFilePath, 1))
                {
                    string xmlFilePath = Path.Combine(Path.GetDirectoryName(csvFilePath), "routes.xml");
                    txtBrowseXMLPath.Text = xmlFilePath;
                    ConvertCSVtoXML(csvFilePath, xmlFilePath);
                    DisplayData(xmlFilePath);
                }
            }
        }

        private bool CheckFileSize(string filePath, long maxSizeMB)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            long sizeInBytes = fileInfo.Length;
            double sizeInMB = sizeInBytes / (1024.0 * 1024.0);

            if (sizeInMB > maxSizeMB)
            {
                MessageBox.Show($"File size is more than {maxSizeMB} MB. Please provide a smaller file.");
                return false;
            }

            return true;
        }

        private void ConvertCSVtoXML(string csvFilePath, string xmlFilePath)
        {
            try
            {
                var dataTable = new DataTable();
                List<string> invalidRecords = new List<string>();

                using (var reader = new StreamReader(csvFilePath))
                {
                    string[] headers = reader.ReadLine()?.Split(',');
                    if (headers != null)
                    {
                        foreach (string header in headers)
                        {
                            string columnName = header.Replace(":", "_");
                            dataTable.Columns.Add(columnName);
                        }

                        while (!reader.EndOfStream)
                        {
                            string[] rows = reader.ReadLine()?.Split(',');
                            if (rows != null)
                            {
                                DataRow dataRow = dataTable.NewRow();
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    dataRow[i] = rows[i];
                                }
                                dataTable.Rows.Add(dataRow);

                                if (rows.Any(string.IsNullOrWhiteSpace))
                                {
                                    invalidRecords.Add(string.Join(",", rows));
                                }
                            }
                        }
                    }
                }

                if (invalidRecords.Any())
                {
                    LogInvalidRecords(csvFilePath, invalidRecords);
                    return;
                }

                CreateXMLFromDataTable(dataTable, xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while converting CSV to XML: " + ex.Message);
            }
        }

        private void LogInvalidRecords(string csvFilePath, List<string> invalidRecords)
        {
            string logFilePath = Path.Combine(Path.GetDirectoryName(csvFilePath), "invalid_records.log");
            File.WriteAllLines(logFilePath, invalidRecords);
            MessageBox.Show($"The following records are invalid. Check the log file for details: {logFilePath}");
        }

        private void CreateXMLFromDataTable(DataTable dataTable, string xmlFilePath)
        {
            XDocument xmlDocument = new XDocument(new XElement("Routes",
                                        dataTable.AsEnumerable().Select(row =>
                                            new XElement("Route",
                                                dataTable.Columns.Cast<DataColumn>().Select(column =>
                                                    new XElement(XmlConvert.EncodeName(column.ColumnName.Replace(":", "_")), row[column])
                                                )
                                            )
                                        )
                                    ));
            xmlDocument.Save(xmlFilePath);
        }

        private void DisplayData(string xmlFilePath)
        {
            try
            {
                allRoutes = XDocument.Load(xmlFilePath)?
                    .Descendants("Route")
                    .Select(route => new RoutesData
                    {
                        RouteTitle = (string)route.Element("Route_x0020_Title"),
                        FirstStation = (string)route.Element("First_x0020_Station"),
                        LastStation = (string)route.Element("Last_x0020_Station"),
                        Distance = (decimal)route.Element("Distance"),
                        Status = (string)route.Element("Status"),
                        LastModifiedDateTime = DateTime.TryParseExact(
                            (string)route.Element("Last_x0020_Modified_x0020_Datetime"),
                            "dd/MM/yyyy HH:mm:ss",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime parsedDateTime)
                            ? parsedDateTime
                            : DateTime.MinValue,
                        ReferenceCode = (string)route.Element("Reference_x0020_Code")
                    })
                    .ToList();

                dataGrid.ItemsSource = allRoutes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while displaying data: " + ex.Message);
            }
        }

        private void btnSearchByDate_Click(object sender, RoutedEventArgs e)
        {
            if (cmbStatus.SelectedItem != null)
            {
                string selectedStatus = (cmbStatus.SelectedItem as ComboBoxItem)?.Content.ToString();
                SearchByStatus(selectedStatus);
            }
            else
            {
                SearchByDateRange();
            }
        }

        private void SearchByStatus(string status)
        {
            List<RoutesData> filteredRoutes = string.IsNullOrEmpty(status)
                ? allRoutes.ToList()
                : allRoutes.Where(r => r.Status == status).ToList();

            dataGrid.ItemsSource = filteredRoutes;
        }

        private void SearchByDateRange()
        {
            DateTime startDate = startDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = endDatePicker.SelectedDate ?? DateTime.MaxValue;

            List<RoutesData> filteredRoutes = allRoutes.Where(r => r.LastModifiedDateTime >= startDate && r.LastModifiedDateTime <= endDate).ToList();

            dataGrid.ItemsSource = filteredRoutes;
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            cmbStatus.SelectedIndex = -1;
            startDatePicker.SelectedDate = null;
            endDatePicker.SelectedDate = null;
            DisplayAllData();
        }

        private void DisplayAllData()
        {
            dataGrid.ItemsSource = allRoutes;
        }
        public string GenerateReferenceCode(RoutesData record)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString("00");
            string day = DateTime.Now.Day.ToString("00");
            string title = record.RouteTitle.Substring(0, Math.Min(4, record.RouteTitle.Length)).ToUpper();
            return $"{year}{month}{day}{title}";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (RoutesData route in allRoutes)
            {
         
                string newReferenceCode = GenerateReferenceCode(route); 

               
                route.ReferenceCode = newReferenceCode;
            }

            
            dataGrid.Items.Refresh();
        }


        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrowseXMLPath.Text))
            {
                MessageBox.Show("Please browse for the data source file first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                DefaultExt = ".xml",
                Filter = "XML Files (*.xml)|*.xml"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string xmlFilePath = saveFileDialog.FileName;
                ImportDataToXML(xmlFilePath);
            }
        }

        private void ImportDataToXML(string xmlFilePath)
        {
            try
            {
                XDocument xmlDocument = new XDocument(new XElement("Routes",
                                            allRoutes.Select(route =>
                                                new XElement("Route",
                                                    new XElement("Route_x0020_Title", route.RouteTitle),
                                                    new XElement("First_x0020_Station", route.FirstStation),
                                                    new XElement("Last_x0020_Station", route.LastStation),
                                                    new XElement("Distance", route.Distance),
                                                    new XElement("Status", route.Status),
                                                    new XElement("Last_x0020_Modified_x0020_Datetime", route.LastModifiedDateTime.ToString("dd/MM/yyyy HH:mm:ss")),
                                                    new XElement("Reference_x0020_Code", route.ReferenceCode)
                                                )
                                            )
                                        ));
                xmlDocument.Save(xmlFilePath);
                MessageBox.Show("Data imported successfully to XML file: " + xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while importing data to XML: " + ex.Message);
            }
        }
    }
}
