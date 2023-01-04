using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Appointment : IEntity
    {
        public int ID { get; set; }
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public int AppointmentHourID { get; set; }
        public virtual AppointmentHour AppointmentHour { get; set; }
        public string Analysis { get; set; }
        public string Prescription { get; set; }
        public string Comments { get; set; }
        public int State { get; set; } = 1;



    }
}
