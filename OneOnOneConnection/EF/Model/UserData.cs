using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model
{
    public class UserData
    {
        [Key]
        [ForeignKey("User")]
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }
    }
}
