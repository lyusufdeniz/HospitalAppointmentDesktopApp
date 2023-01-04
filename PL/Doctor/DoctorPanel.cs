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

namespace PL.Doctor
{
    public partial class DoctorPanel : Form
    {
        AppointmentManager am = new AppointmentManager();
        PatientManager pm = new PatientManager();
        EL.Doctor doctor = Login.Login.loginDoctor;
        Appointment selectedapointment;
        Patient selectedpatient;
        public DoctorPanel()
        {
            InitializeComponent();
        }


        public void loadData()
        {
            dataGridView1.DataSource = am.getAll(x => x.DoctorID == doctor.ID && x.State == 1);
            for (int i = 4; i <= 15; i++)
            {
                dataGridView1.Columns[i].Visible = false;

            }
            Patient eachpt;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                eachpt = pm.GetT(int.Parse(dataGridView1[5, i].Value.ToString()));
                dataGridView1[0, i].Value = eachpt.Name + " " + eachpt.Surname;
                dataGridView1[1, i].Value = eachpt.TC;
                dataGridView1[2, i].Value = eachpt.BirthDate.ToString();
                dataGridView1[3, i].Value = eachpt.EMail;

                eachpt = null;

            }




        }
        public void clearTextbox()
        {
            foreach (Control c in this.Controls)
            {
                var tb = c as Bunifu.Framework.UI.BunifuMaterialTextbox;
                if (tb != null)
                {
                    tb.Text = String.Empty;
                }

            }
        }
        public bool checkTextbox()
        {
            foreach (Control c in this.Controls)
            {
                var tb = c as Bunifu.Framework.UI.BunifuMaterialTextbox;
                if (tb != null && tb.Enabled == false)
                {
                    if (String.IsNullOrEmpty(tb.Text))
                    {
                        return false;
                    }
                }

            }
            return true;
        }
        private void DoctorPanel_Load(object sender, EventArgs e)
        {

            loadData();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedapointment = am.GetT(int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()));
            selectedpatient = pm.GetT(int.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString()));
            tcbox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            AD.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dtbox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() != null)
                mailbox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (selectedapointment != null && checkTextbox())
            {
                selectedapointment.Analysis = tahlilbox.Text;
                selectedapointment.Comments = yorumbox.Text;
                selectedapointment.Prescription = ilacbox.Text;
                selectedapointment.State = 0;
                am.Update(selectedapointment);
                if (mailat.Checked)
                {

                    if (new BL.MailSender().sendMail(selectedpatient.EMail, selectedpatient.Name + " " + selectedpatient.Surname, selectedapointment.Date, selectedapointment.Analysis, selectedapointment.Comments, selectedapointment.Prescription))
                    {
                        MessageBox.Show("Mail Gönderildi");
                    }
                    else
                        MessageBox.Show("Mail Gönderilirken Hata Oluştu");
                }
                selectedapointment = null;
                selectedpatient = null;
                MessageBox.Show("Muayene Tamamlandı");
                loadData();
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız!");

            }


        }
    }
}

