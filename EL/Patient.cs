using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Patient : IEntity
    {
        public int ID { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        public string TC { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string EMail { get; set; }

    }
}
