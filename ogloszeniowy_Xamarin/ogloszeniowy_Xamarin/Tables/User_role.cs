using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_ogloszeniowy.Tables
{
    public class User_role
    {
        [PrimaryKey, AutoIncrement]
        public int Role_id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
