using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteLibrary
{
    public interface IRecordRepository
    {
        ObservableCollection<Record> LoadRecords();
        void SaveRecords(ObservableCollection<Record> records);
        string GenerateReferenceCode(Record record);

        void AddRecord(Record record);

        void UpdateRecord(Record record);

        void DeleteRecord(Record record);
    }
}
