using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy.classes
{
    public class Announcement
    {
        [PrimaryKey, AutoIncrement]
        public int Announcement_id { get; set; }
        public int Company_id { get; set; }
        public int Category_id { get; set; }
        public int Subcategory_id { get; set; }
        [MaxLength(75)]
        public string Position_name { get; set; }
        public string Position_level { get; set; }
        public string Contract_type { get; set; }
        public string Working_time { get; set; }
        public string Work_type { get; set; }
        [MaxLength(11)]
        public string Working_hours { get; set; }
        public DateTime End_date { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }
        public string Benefits { get; set; }
    }
}
