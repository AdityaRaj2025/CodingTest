using NUnit.Framework;
using RouteLibrary;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace RouteLibrary.Tests
{
    [TestFixture]
    public class RecordRepositoryTests
    {
        private RecordRepository recordRepository;

        private const string TestFilePath = "test_records.xml";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(TestFilePath))
                File.Delete(TestFilePath);

            recordRepository = new RecordRepository();
        }

        [Test]
        public void LoadRecords_LoadsRecordsSuccessfully()
        {
            ObservableCollection<Record> testRecords = new ObservableCollection<Record>
            {
                new Record { RouteTitle = "Test Route 1", FirstStation = "Station A", LastStation = "Station B", Distance = 10, Status = "Active", CreatedDatetime = DateTime.Now },
                new Record { RouteTitle = "Test Route 2", FirstStation = "Station C", LastStation = "Station D", Distance = 20, Status = "Inactive", CreatedDatetime = DateTime.Now }
            };
            recordRepository.SaveRecords(testRecords);

            ObservableCollection<Record> loadedRecords = recordRepository.LoadRecords();

            Assert.IsNotNull(loadedRecords);
            Assert.AreEqual(2, loadedRecords.Count);
        }

        [Test]
        public void SaveRecords_SavesRecordsSuccessfully()
        {
            ObservableCollection<Record> testRecords = new ObservableCollection<Record>
            {
                new Record { RouteTitle = "Test Route 1", FirstStation = "Station A", LastStation = "Station B", Distance = 10, Status = "Active", CreatedDatetime = DateTime.Now },
                new Record { RouteTitle = "Test Route 2", FirstStation = "Station C", LastStation = "Station D", Distance = 20, Status = "Inactive", CreatedDatetime = DateTime.Now }
            };

            recordRepository.SaveRecords(testRecords);

            Assert.IsTrue(File.Exists(TestFilePath));
        }

        [Test]
        public void AddRecord_AddsRecordSuccessfully()
        {
            Record newRecord = new Record
            {
                RouteTitle = "Test Route 1",
                FirstStation = "Station A",
                LastStation = "Station B",
                Distance = 10,
                Status = "Active",
                CreatedDatetime = DateTime.Now
            };

            recordRepository.AddRecord(newRecord);

            ObservableCollection<Record> loadedRecords = recordRepository.LoadRecords();
            Assert.IsNotNull(loadedRecords);
            Assert.AreEqual(1, loadedRecords.Count);
        }

        [Test]
        public void UpdateRecord_UpdatesRecordSuccessfully()
        {
            Record existingRecord = new Record
            {
                RouteTitle = "Test Route 1",
                FirstStation = "Station A",
                LastStation = "Station B",
                Distance = 10,
                Status = "Active",
                CreatedDatetime = DateTime.Now
            };
            recordRepository.AddRecord(existingRecord);

            existingRecord.Status = "Inactive"; 

            recordRepository.UpdateRecord(existingRecord);

            ObservableCollection<Record> loadedRecords = recordRepository.LoadRecords();
            Assert.IsNotNull(loadedRecords);
            Assert.AreEqual("Inactive", loadedRecords[0].Status); 
        }

        [Test]
        public void DeleteRecord_DeletesRecordSuccessfully()
        {          
            Record recordToDelete = new Record
            {
                RouteTitle = "Test Route 1",
                FirstStation = "Station A",
                LastStation = "Station B",
                Distance = 10,
                Status = "Active",
                CreatedDatetime = DateTime.Now
            };
            recordRepository.AddRecord(recordToDelete);

            recordRepository.DeleteRecord(recordToDelete);

            ObservableCollection<Record> loadedRecords = recordRepository.LoadRecords();
            Assert.IsNotNull(loadedRecords);
            Assert.AreEqual(0, loadedRecords.Count); 
        }
        [Test]     
        public void GenerateReferenceCode_GeneratesReferenceCodeSuccessfully()
        {
         
            Record record = new Record
            {
                RouteTitle = "Test Route",
                FirstStation = "Station A",
                LastStation = "Station B",
                Distance = 10,
                Status = "Active",
                CreatedDatetime = DateTime.Now
            };
      
            string referenceCode = recordRepository.GenerateReferenceCode(record);
       
            Assert.IsNotNull(referenceCode); 
            Assert.IsNotEmpty(referenceCode); 
          
        }
    }
}
