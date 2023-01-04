using BL;
using EL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.Secretary
{
    public partial class CreatePatientPanel : Form
    {
        PatientManager pm = new PatientManager();
        Patient selectedPatient = null;
        public CreatePatientPanel()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            PatientsDGV.DataSource = null;
            PatientsDGV.DataSource = pm.getAll();
            PatientsDGV.Columns[0].Visible = false;
            PatientsDGV.Columns[1].HeaderText = "TC";
            PatientsDGV.Columns[2].HeaderText = "AD";
            PatientsDGV.Columns[3].HeaderText = "SOYAD";
            PatientsDGV.Columns[4].HeaderText = "DOĞUM TARİHİ";
            PatientsDGV.Columns[5].HeaderText = "E POSTA";




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
        private void CreatePatientPanel_Load(object sender, EventArgs e)
        {
            loadData();

        }

        private void btnPatientAdd_Click(object sender, EventArgs e)
        {
            if (checkTextbox())
            {
                try
                {
                    if (TCTXT.Text.Length == 11)
                    {

                        pm.Add(new EL.Patient { BirthDate = DATETIMEPICKER.Value, Name = NAMETXT.Text, Surname = SNAMETXT.Text, TC = TCTXT.Text,EMail=emailbox.Text });
                        loadData();
                        clearTextbox();
                        MessageBox.Show("Hasta Kaydedildi");
                        
                    }
                        else
                    {
                        MessageBox.Show("Hata TC 11 HANEDEN OLUŞMALI");
                    }
                    
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

        private void btncPatientEdit_Click(object sender, EventArgs e)
        {
            if (selectedPatient != null)
            {
             
                   

                try
                {
                    if (TCTXT.Text.Length == 11)
                    {
                        selectedPatient.TC = TCTXT.Text;
                        selectedPatient.BirthDate = DATETIMEPICKER.Value;
                        selectedPatient.Name = NAMETXT.Text;
                        selectedPatient.Surname = SNAMETXT.Text;
                        selectedPatient.EMail = emailbox.Text;


                        pm.Update(selectedPatient);
                        loadData();
                        clearTextbox();
                        MessageBox.Show("Hasta Kaydedildi");
                    }
                    else
                        MessageBox.Show("Hata TC 11 HANEDEN OLUŞMALI");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }

            }
            else
            {
                MessageBox.Show("Hasta Seçiniz");
            }

        }

        private void PatientsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedPatient = pm.GetT(int.Parse(PatientsDGV.CurrentRow.Cells[0].Value.ToString()));
            NAMETXT.Text = selectedPatient.Name;
            SNAMETXT.Text = selectedPatient.Surname;
            TCTXT.Text = selectedPatient.TC;
            DATETIMEPICKER.Value = selectedPatient.BirthDate;
            selectedPatient.Name = NAMETXT.Text;

        }

        private void btnPatientDelete_Click(object sender, EventArgs e)
        {
            if(selectedPatient!=null)
            try
            {
                    pm.Delete(selectedPatient.ID);
                    loadData();
                    clearTextbox();
                    MessageBox.Show("Hasta Silindi");
                  
            }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message.ToString());
                    throw;
                }
            else
            { MessageBox.Show("Hasta Seçilmedi");
            
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
