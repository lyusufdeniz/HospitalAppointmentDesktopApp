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
using static System.Net.Mime.MediaTypeNames;

namespace PL.Secretary
{
    public partial class CreateDoctorPanel : Form
    {
       EL.Doctor selectedDoctor = null;
        DoctorManager dm = new DoctorManager();
      
        public void loadData()
        {
            dgv_doctor.DataSource = null;
            dgv_doctor.DataSource = dm.getAll();
            
            dgv_doctor.Columns[0].Visible = false;
            dgv_doctor.Columns[6].Visible = false;
            dgv_doctor.Columns[1].HeaderText = "AD";
            dgv_doctor.Columns[2].HeaderText = "SOYAD";
            dgv_doctor.Columns[3].HeaderText = "K.Adı";
            dgv_doctor.Columns[4].HeaderText = "Şifre";
            dgv_doctor.Columns[5].Visible = false;
            kliniklist.DataSource = new ClinicManager().getAll();
            kliniklist.DisplayMember = "Name";
            kliniklist.ValueMember = "ID";

            {
               
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
                if (tb != null)
                {
                    if (String.IsNullOrEmpty(tb.Text))
                    {
                        return false;
                    }
                }


            }
            return true;
        }
        public CreateDoctorPanel()
        {
            InitializeComponent();
        }

        private void CreateDoctorPanel_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (checkTextbox())
            {
                try
                {



                    dm.Add(new EL.Doctor { ClinicID = int.Parse(kliniklist.SelectedValue.ToString()), Name = txt_doctorName.Text, Surname = txt_doctorsurname.Text, UserName = txt_username.Text, Password = txt_pw.Text });
                    loadData();
                    clearTextbox();
                    MessageBox.Show("Doktor Kaydedildi");




                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message.ToString());
                    throw;
                }
            }
            else
                MessageBox.Show("BOŞ ALAN BIRAKMAYIN!");
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (selectedDoctor != null)
            {



                try
                {

                    selectedDoctor.Name = txt_doctorName.Text;
                    selectedDoctor.Surname = txt_doctorsurname.Text;
                    selectedDoctor.UserName = txt_doctorsurname.Text;
                    selectedDoctor.Password = txt_pw.Text;
                    selectedDoctor.ClinicID = int.Parse(kliniklist.SelectedValue.ToString());


                    dm.Update(selectedDoctor);
                    loadData();
                    clearTextbox();
                    MessageBox.Show("Doktor Kaydedildi");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }

            }
            else
            {
                MessageBox.Show("Doktor Seçiniz");
            }
        }

        private void dgv_doctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedDoctor = dm.GetT(int.Parse(dgv_doctor.CurrentRow.Cells[0].Value.ToString()));
            txt_doctorName.Text= selectedDoctor.Name;
             txt_doctorsurname.Text= selectedDoctor.Surname;
            txt_username.Text = selectedDoctor.UserName;
            txt_pw.Text = selectedDoctor.Password;
            kliniklist.SelectedValue= selectedDoctor.ClinicID;

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (selectedDoctor != null)
                try
                {
                    dm.Delete(selectedDoctor.ID);
                    loadData();
                    clearTextbox();
                    MessageBox.Show("Doktor Silindi");

                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message.ToString());
                    throw;
                }
            else
            {
                MessageBox.Show("Doktor Seçilmedi");

            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
