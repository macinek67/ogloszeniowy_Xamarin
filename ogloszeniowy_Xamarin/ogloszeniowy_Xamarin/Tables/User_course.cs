using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy.classes
{
    public class User_course
    {
        [PrimaryKey, AutoIncrement]
        public int Course_id { get; set; }
        public int User_id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(40)]
        public string Organizer { get; set; }

        public DateTime Period { get; set; }

    }
}
