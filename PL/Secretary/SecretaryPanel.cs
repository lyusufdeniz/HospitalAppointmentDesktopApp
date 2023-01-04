using BL;
using EL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PL.Secretary
{
    public partial class SecretaryPanel : Form
    {
        ClinicManager cm = new ClinicManager();
        AppointmentManager am=new AppointmentManager();
        DoctorManager dm=new DoctorManager();
        public SecretaryPanel()
        {
            InitializeComponent();
        }

      
        private void hASTAKAYITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreatePatientPanel().Show();

            
        }

        private void dOKTORKAYITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreateDoctorPanel().Show();
        }

        private void sEKRETERKAYITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreateSecretaryPanel().Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close()
                ;
        }

        private void rANDEVUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreateAppointment().Show();
        }

        private void SecretaryPanel_Load(object sender, EventArgs e)
        {


            List<Clinic> klinikler = new List<Clinic>();
            klinikler.AddRange(cm.getAll());
            List<Appointment> randevular = new List<Appointment>();
            randevular.AddRange(am.getAll());
            List<EL.Doctor> doktorlar = new List<EL.Doctor>();
            doktorlar.AddRange(dm.getAll());
            foreach (EL.Doctor d in doktorlar)
            {
                if (randevular.Where(x => x.DoctorID == d.ID).Count() != 0)
                {
                    chart2.Series["Doktorlar"].Points.AddXY(d.Name + " " + d.Surname, randevular.Where(x => x.DoctorID == d.ID).Count());
                }
            }

            foreach (Clinic a in klinikler)
            {
                if (randevular.Where(x => x.Doctor.ClinicID == a.ID).Count() != 0)
                    chart.Series["Bolumler"].Points.AddXY(a.Name, randevular.Where(x => x.Doctor.ClinicID == a.ID).Count());
            }

        }


        private void hAKKINDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YUSUF DENİZ 201001091 \nMEHMET EMİN ERKENEKEN ");
        }

 
    }
}
