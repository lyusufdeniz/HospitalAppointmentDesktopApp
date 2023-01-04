using EL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DAL
{
    public class Context : DbContext
    {
        public Context() : base("name=Context")
        {
            Database.SetInitializer(new DatabaseInitializer());

        }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Secretary> Secretary { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<AppointmentHour> AppointmentHour { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
        {
            protected override void Seed(Context context)
            {
                if (!context.Secretary.Any())
                {
                    context.Secretary.Add(new Secretary() { ID = 1, Name = "sekreter", Surname = "sekreter", UserName = "sekreter", Password = "sekreter" });
                 
               

                    context.SaveChanges();
                }
                if (!context.Doctor.Any())
                {
                    context.Doctor.Add(new Doctor() { ID = 1, Name = "doktor", Surname = "doktor", ClinicID = 1 });
                    context.SaveChanges();
                }
                    if (!context.Clinic.Any())
                {
                    List<Clinic> list = new List<Clinic>();
                    list.Add(new Clinic() { ID = 1, Name = "Dahiliye" });
                    list.Add(new Clinic() { ID = 2, Name = "Kulak Burun Boğaz" });
                    list.Add(new Clinic() { ID = 3, Name = "Göz Hastalıkları" });
                    list.Add(new Clinic() { ID = 4, Name = "Beyin ve SinirCerrahisi" });
                    list.Add(new Clinic() { ID = 5, Name = "Ortopedi ve Travmatoloji" });
                    list.Add(new Clinic() { ID = 6, Name = "Radyoloji" });
                    list.Add(new Clinic() { ID = 7, Name = "Nöroloji" });
                    list.Add(new Clinic() { ID = 8, Name = "Psikoloji" });
                    list.Add(new Clinic() { ID = 9, Name = "Genel Cerrahi" });
                    list.Add(new Clinic() { ID = 10, Name = "Clidiye" });
                    list.Add(new Clinic() { ID = 11, Name = "Üroloji" });
                    list.Add(new Clinic() { ID = 12, Name = "Kadın Doğum ve Hastalıkları" });
                    foreach (Clinic c in list)
                    {
                        context.Clinic.Add(c);
                    }
                    if(!context.AppointmentHour.Any())
                    {
                        List<AppointmentHour> saatler = new List<AppointmentHour>();
                        saatler.Add(new AppointmentHour { ID = 1, Hour = "9:00" });
                        saatler.Add(new AppointmentHour { ID = 2, Hour = "9:15" });
                        saatler.Add(new AppointmentHour { ID = 3, Hour = "9:30" });
                        saatler.Add(new AppointmentHour { ID = 4, Hour = "9:45" });
                        saatler.Add(new AppointmentHour { ID = 5, Hour = "10:00" });
                        saatler.Add(new AppointmentHour { ID = 6, Hour = "10:15" });
                        saatler.Add(new AppointmentHour { ID = 7, Hour = "10:30" });
                        saatler.Add(new AppointmentHour { ID = 8, Hour = "10:45" });
                        saatler.Add(new AppointmentHour { ID = 9, Hour = "11:00" });
                        saatler.Add(new AppointmentHour { ID = 10, Hour = "11:15" });
                        saatler.Add(new AppointmentHour { ID = 11, Hour = "11:30" });
                        saatler.Add(new AppointmentHour { ID = 12, Hour = "11:45" });
                        saatler.Add(new AppointmentHour { ID = 13, Hour = "12:00" });
                        saatler.Add(new AppointmentHour { ID = 14, Hour = "12:15" });
                        saatler.Add(new AppointmentHour { ID = 15, Hour = "12:30" });
                        saatler.Add(new AppointmentHour { ID = 16, Hour = "12:45" });
                        saatler.Add(new AppointmentHour { ID = 17, Hour = "13:00" });
                        saatler.Add(new AppointmentHour { ID = 18, Hour = "13:15" });
                        saatler.Add(new AppointmentHour { ID = 19, Hour = "13:30" });
                        saatler.Add(new AppointmentHour { ID = 20, Hour = "13:45" });
                        saatler.Add(new AppointmentHour { ID = 21, Hour = "14:00" });
                        saatler.Add(new AppointmentHour { ID = 22, Hour = "14:15" });
                        saatler.Add(new AppointmentHour { ID = 23, Hour = "14:30" });
                        saatler.Add(new AppointmentHour { ID = 24, Hour = "14:45" });
                        saatler.Add(new AppointmentHour { ID = 25, Hour = "15:00" });
                        saatler.Add(new AppointmentHour { ID = 26, Hour = "15:15" });
                        saatler.Add(new AppointmentHour { ID = 27, Hour = "15:30" });
                        saatler.Add(new AppointmentHour { ID = 28, Hour = "15:45" });
                        saatler.Add(new AppointmentHour { ID = 29, Hour = "16:00" });
                        saatler.Add(new AppointmentHour { ID = 30, Hour = "16:15" });
                        saatler.Add(new AppointmentHour { ID = 31, Hour = "16:30" });
                        saatler.Add(new AppointmentHour { ID = 32, Hour = "16:45" });
                        foreach (AppointmentHour c in saatler)
                        {
                            context.AppointmentHour.Add(c);
                        }
                    }
                 

                    context.SaveChanges();
                }
                    base.Seed(context);
            }
        }

    }
}

