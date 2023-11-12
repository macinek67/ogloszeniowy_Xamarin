using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy.classes;

namespace system_ogloszeniowy.Tables
{
    public class User_education
    {
        [PrimaryKey, AutoIncrement]
        public int Education_id { get; set; }
        public int User_id { get; set; }
        [MaxLength(75)]
        public string School_name { get; set; }
        [MaxLength(35)]
        public string City { get; set; }
        public string Level { get; set; }
        [MaxLength(75)]
        public string Specialization { get; set; }
        public DateTime Period_start { get; set; }
        public DateTime Period_end { get; set; }

    }
}
