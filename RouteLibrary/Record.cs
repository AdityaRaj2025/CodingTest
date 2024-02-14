using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteLibrary
{
    [Serializable]
    public class Record
    {
        public string RouteTitle { get; set; }
        public string FirstStation { get; set; }
        public string LastStation { get; set; }
        public decimal Distance { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string ReferenceCode { get; set; }
    }
}
