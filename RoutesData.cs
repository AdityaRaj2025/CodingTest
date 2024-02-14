using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayTask
{
    public class RoutesData
    {
        public string RouteTitle { get; set; }
        public string FirstStation { get; set; }
        public string LastStation { get; set; }
        public decimal Distance { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public string ReferenceCode { get; set; }
    }

}
