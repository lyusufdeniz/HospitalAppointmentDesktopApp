using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class AppointmentHour:IEntity
    {
        public int ID { get; set; }
        public string Hour { get; set; }
    }
}
