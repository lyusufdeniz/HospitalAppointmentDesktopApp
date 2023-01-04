using BL;
using EL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.Secretary
{
    public partial class CreateAppointment : Form
    {
        DoctorManager dm = new DoctorManager();
        AppointmentManager am = new AppointmentManager();
        PatientManager pm = new PatientManager();
        ClinicManager cm = new ClinicManager();
        EL.Patient selectedpatient = null;
        EL.Doctor selecteddoctor = null;
        EL.Clinic selectedclinic = null;
        AppointmenHourManager ahm= new AppointmenHourManager();
        AppointmentHour selectedappointmenthour = null;



        DateTime selecteddate;
        public void loadData()
        {
            dateTimePicker1.MinDate = DateTime.Now;
            dgv_bolum.DataSource = cm.getAll();
            dgv_bolum.Columns[0].Visible = false;
            dgv_bolum.Columns[1].HeaderText = "BÖLÜM";


            dgv_hasta.DataSource = pm.getAll();
            dgv_hasta.Columns[0].Visible = false;
            dgv_hasta.Columns[4].Visible = false;
            dgv_hasta.Columns[1].HeaderText = "TC";
            dgv_hasta.Columns[2].HeaderText = "H.AD";
            dgv_hasta.Columns[3].HeaderText = "H.SOYAD";



        }
        public CreateAppointment()
        {
            InitializeComponent();

        }
        public void createButtons()
        {
            this.tableLayoutPanel1.Controls.Clear();

            var rowCount = 8;
            var columnCount = 4;


            this.tableLayoutPanel1.ColumnCount = columnCount;
            this.tableLayoutPanel1.RowCount = rowCount;

            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < columnCount; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / columnCount));
            }
            for (int i = 0; i < rowCount; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / rowCount));
            }

            for (int i = 0; i < rowCount * columnCount; i++)
            {
                var list = ahm.getAll();
                var b = new Button();
                b.Text = list[i].Hour.ToString();
                b.Name = string.Format("b_{0}", i + 1);
                b.Click += b_Click;
                b.Dock = DockStyle.Fill;
                this.tableLayoutPanel1.Controls.Add(b);
                DateTime selecteddate = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                b.ForeColor = Color.White;
                if (am.getAll(x => x.Doctor.ID == selecteddoctor.ID &&x.AppointmentHourID==i+1).Where(x=>x.Date.ToString("yyyy-MM-dd")==selecteddate.ToString("yyyy-MM-dd")).Count() == 0)
                {
                    b.Enabled = true;
                    b.BackColor=Color.Green;
                    b.ForeColor = Color.White;
                    b.Font=new Font(b.Font,FontStyle.Bold);
                   
                }
                else
                {
                    b.Enabled=false;
                    b.BackColor = Color.Red;
                    b.ForeColor= Color.White;
                }
                b.Font = new Font(b.Font, FontStyle.Bold);
            }
        }
        private void CreateAppointment_Load(object sender, EventArgs e)
        {
            loadData();
             selecteddate = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
        }


        void b_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            saattarihtxt.Text = selecteddate.ToString("ddd/MMM/yyyy") +"  "+ b.Text;
           
            if (b != null)
            {
                MessageBox.Show(string.Format("{0} Saat Seçildi", b.Text));
                selectedappointmenthour = ahm.Find(x => x.Hour == b.Text);
            }
              
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_bolum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selecteddoctor = null;
            doktortxt.Text= null;

            selectedclinic = cm.GetT(int.Parse(dgv_bolum.CurrentRow.Cells[0].Value.ToString()));

            dgv_doktor.DataSource = dm.getAll(x => x.ClinicID == selectedclinic.ID);
            dgv_doktor.Columns[0].Visible = false;
            dgv_doktor.Columns[3].Visible = false;
            dgv_doktor.Columns[4].Visible = false;
            dgv_doktor.Columns[5].Visible = false;
            dgv_doktor.Columns[6].Visible = false;
            dgv_doktor.Columns[1].HeaderText = "DOKTOR ADI";
            dgv_doktor.Columns[2].HeaderText = "DOKTOR SOYADI";
            bolumtxt.Text = selectedclinic.Name;
        }

        private void dgv_doktor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selecteddoctor = dm.GetT((int)dgv_doktor.CurrentRow.Cells[0].Value);
            doktortxt.Text = selecteddoctor.Name + " " + selecteddoctor.Surname.ToUpper();
      
        }

        private void dgv_hasta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedpatient = pm.GetT(int.Parse(dgv_hasta.CurrentRow.Cells[0].Value.ToString()));
            hastatxt.Text = selectedpatient.Name + " " + selectedpatient.Surname.ToUpper();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (selectedclinic != null && selecteddoctor != null && selectedpatient != null&&selectedappointmenthour!=null)
            {

                am.Add(new EL.Appointment { PatientID = selectedpatient.ID, DoctorID = selecteddoctor.ID, Date = dateTimePicker1.Value ,AppointmentHourID=selectedappointmenthour.ID});
                MessageBox.Show("Randevu Oluşturuldu");
                
            }
            else
            {
                MessageBox.Show("Gerekli Alanları Seçin");
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
             selecteddate = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
          

        }

        //randevu arama butoun seçilen doktor hasta ve tarihe göre arama işlemini başlatır ve saatleri gösteren butonları oluşturur
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            if (selecteddate != null && selecteddoctor != null && selectedpatient != null)
            {    //yeni butonları oluşturma
                createButtons();
            }
            else
                MessageBox.Show("Gerekli Alanları Doldurun");
           
        }

        
    }
}

