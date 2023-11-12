using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy.classes
{
    public class Company
    {
        [PrimaryKey, AutoIncrement]
        public int Company_id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(75)]
        public string Adress { get; set; }
        public string Localization_link { get; set; }
        public string Description { get; set; }
    }
}
