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
    public partial class CreateSecretaryPanel : Form
    {
        EL.Secretary selectedsecretary = null;
        SecretaryManager sm=new SecretaryManager();
        public CreateSecretaryPanel()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            dgv_secretary.DataSource = null;
            dgv_secretary.DataSource = sm.getAll();
            dgv_secretary.Columns[0].Visible = false;
            dgv_secretary.Columns[1].HeaderText = "AD";
            dgv_secretary.Columns[2].HeaderText = "SOYAD";
            dgv_secretary.Columns[3].HeaderText = "K.Adı";
            dgv_secretary.Columns[4].HeaderText = "Şifre";




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

        private void add_Click(object sender, EventArgs e)
        {

            if (checkTextbox())
            {
                try
                {
                   

                        sm.Add(new EL.Secretary {Name=name.Text,Surname=surname.Text,UserName=uname.Text,Password=pw.Text });
                        loadData();
                        clearTextbox();
                        MessageBox.Show("Sekreter Kaydedildi");

                    
                   

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

        private void CreateSecretaryPanel_Load(object sender, EventArgs e)
        {
            loadData();

        }

        private void dgv_secretary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedsecretary = sm.GetT(int.Parse(dgv_secretary.CurrentRow.Cells[0].Value.ToString()));
            name.Text = selectedsecretary.Name;
            surname.Text=selectedsecretary.Surname;
            uname.Text = selectedsecretary.UserName;
            pw.Text=selectedsecretary.Password;

        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (selectedsecretary != null)
            {



                try
                {
                    
                        selectedsecretary.Name = name.Text;
                    selectedsecretary.Surname = surname.Text;
                    selectedsecretary.UserName = uname.Text;
                    selectedsecretary.Password = pw.Text;


                        sm.Update(selectedsecretary);
                        loadData();
                        clearTextbox();
                        MessageBox.Show("Sekreter Kaydedildi");
        

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

        private void delete_Click(object sender, EventArgs e)
        {
            if (selectedsecretary != null)
                try
                {
                    sm.Delete(selectedsecretary.ID);
                    loadData();
                    clearTextbox();
                    MessageBox.Show("Sekreter Silindi");

                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message.ToString());
                    throw;
                }
            else
            {
                MessageBox.Show("Sekreter Seçilmedi");

            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close()
                ;
        }
    }
}
