using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using system_ogloszeniowy.classes;

namespace system_ogloszeniowy.Tables
{
    public class User_language
    {
        [PrimaryKey, AutoIncrement]
        public int Language_id { get; set; }
        public int User_id { get; set; }
        [MaxLength(35)]
        public string Language { get; set; }
        public string Level { get; set; }

    }
}
