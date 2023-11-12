using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy.classes;

namespace system_ogloszeniowy.Tables
{
    public class User_experience
    {
        [PrimaryKey, AutoIncrement]
        public int Education_id { get; set; }
        public int User_id { get; set; }
        [MaxLength(75)]
        public string Position { get; set; }
        [MaxLength(50)]
        public string Company { get; set; }
        public string Localization { get; set; }
        public DateTime Period_start { get; set; }
        public DateTime Period_end { get; set; }
        public string Duties { get; set; }
    }
}
