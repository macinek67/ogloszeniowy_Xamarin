using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy.classes
{
    public class Announcement_subcategory
    {
        [PrimaryKey, AutoIncrement]
        public int AnnouncementCategory_id { get; set; }
        public int Category_id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
