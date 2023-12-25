using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy.classes
{
    public class User_data
    {
        [PrimaryKey, AutoIncrement]
        public int User_data_id { get; set; }
        public int User_id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string Surname { get; set; }
        public DateTime Birth_date { get; set; }
        [MaxLength(9)]
        public string Telephone_number { get; set; }
        [MaxLength(35)]
        public string City { get; set; }
        [MaxLength(75)]
        public string Currnent_occupation { get; set; }
        public string Summary { get; set; }
    }
}
