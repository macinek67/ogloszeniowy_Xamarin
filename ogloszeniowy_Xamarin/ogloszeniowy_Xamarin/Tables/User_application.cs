using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy.classes
{
    public class User_application
    {
        [PrimaryKey, AutoIncrement]
        public int Application_id { get; set; }
        public int Announcement_id { get; set; }
        public int User_id { get; set; }
    }
}
