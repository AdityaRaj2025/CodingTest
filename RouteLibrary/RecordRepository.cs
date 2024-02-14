using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RouteLibrary
{
    public class RecordRepository : IRecordRepository
    {
        private static readonly string filePath = "records.xml";

        public ObservableCollection<Record> LoadRecords()
        {
            ObservableCollection<Record> records = new ObservableCollection<Record>();
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Record>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    records = (ObservableCollection<Record>)serializer.Deserialize(fileStream);
                }
            }
            return records;
        }

        public void SaveRecords(ObservableCollection<Record> records)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Record>));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, records);
            }
        }

        public string GenerateReferenceCode(Record record)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString("00");
            string day = DateTime.Now.Day.ToString("00");
            string title = record.RouteTitle.Substring(0, Math.Min(4, record.RouteTitle.Length)).ToUpper();
            return $"{year}{month}{day}{title}";
        }

        public void AddRecord(Record record)
        {
            ObservableCollection<Record> records = LoadRecords();
            records.Add(record);
            SaveRecords(records);
        }

        public void UpdateRecord(Record updatedRecord)
        {
            ObservableCollection<Record> records = LoadRecords();
            Record existingRecord = records.FirstOrDefault(r => r.ReferenceCode == updatedRecord.ReferenceCode);
            if (existingRecord != null)
            {
                // Update the existing record
                existingRecord.RouteTitle = updatedRecord.RouteTitle;
                existingRecord.FirstStation = updatedRecord.FirstStation;
                existingRecord.LastStation = updatedRecord.LastStation;
                existingRecord.Distance = updatedRecord.Distance;
                existingRecord.Status = updatedRecord.Status;
                existingRecord.CreatedDatetime = updatedRecord.CreatedDatetime;

                SaveRecords(records);
            }
            else
            {
                throw new ArgumentException("Record not found.");
            }
        }

        public void DeleteRecord(Record record)
        {
            ObservableCollection<Record> records = LoadRecords();
            Record recordToRemove = records.FirstOrDefault(r => r.ReferenceCode == record.ReferenceCode);
            if (recordToRemove != null)
            {
                records.Remove(recordToRemove);
                SaveRecords(records);
            }
            else
            {
                throw new ArgumentException("Record not found.");
            }
        }


        public ObservableCollection<Record> SearchByDate(DateTime date)
        {
            ObservableCollection<Record> records = LoadRecords();
            return new ObservableCollection<Record>(records.Where(r => r.CreatedDatetime.Date == date.Date));
        }

        public Record SearchByReferenceCode(string referenceCode)
        {
            ObservableCollection<Record> records = LoadRecords();
            return records.FirstOrDefault(r => r.ReferenceCode == referenceCode);
        }
    }
}
