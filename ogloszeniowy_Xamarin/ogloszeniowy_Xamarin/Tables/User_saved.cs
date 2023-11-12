using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy.classes;

namespace system_ogloszeniowy.Tables
{
    public class User_saved
    {
        [PrimaryKey, AutoIncrement]
        public int Saved_id { get; set; }
        public int Announcement_id { get; set; }
        public int User_id { get; set; }
    }
}
