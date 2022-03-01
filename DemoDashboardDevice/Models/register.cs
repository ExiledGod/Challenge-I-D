using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DemoDashboardDevice.Models
{
    public class register
    {
        public int Id { get; set; }
        public int employe_id { get; set; }
        public DateTime entry { get; set; }
        public DateTime endturn { get; set; }
        public DateTime colation { get; set; }
        public DateTime end_colation { get; set; }
    }
}
