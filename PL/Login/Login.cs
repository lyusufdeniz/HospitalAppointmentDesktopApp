using BL;
using EL;
using PL.Secretary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.Login
{
    public partial class Login : Form
    {

        public static EL.Secretary loginSecretary = null;
        public static EL.Doctor loginDoctor = null;
        public Login()
        {
            InitializeComponent();
        }



        private void Login_Load(object sender, EventArgs e)
        {
       
        }

        private void Login_ResizeEnd(object sender, EventArgs e)
        {
       
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            xuıColorPane1.Width = ClientSize.Width;
            xuıColorPane1.Height = ClientSize.Height/20;
            xuıColorPane1.Refresh();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(toggle.Value==true) {

                SecretaryManager sm = new SecretaryManager();
                loginSecretary = sm.Find(x => x.UserName == UserName_TextBox.Text && x.Password == UserPW_TextBox.Text);
                if (loginSecretary!=null)
                {
                    MessageBox.Show("GİRİŞ BAŞARILI");
                   
                    new SecretaryPanel().Show();
                    this.WindowState = FormWindowState.Minimized;

                }
                else
                {
                    MessageBox.Show("GİRİŞ BAŞARISIZ");
                }
            
            }
            if(toggle.Value== false)
            {
                DoctorManager dm = new DoctorManager();
                loginDoctor = dm.Find(x => x.UserName == UserName_TextBox.Text && x.Password == UserPW_TextBox.Text);
                if (loginDoctor != null)
                {
                    MessageBox.Show("GİRİŞ BAŞARILI");
                    new Doctor.DoctorPanel().Show();
                    this.WindowState = FormWindowState.Minimized;

                }
                else
                {
                    MessageBox.Show("GİRİŞ BAŞARISIZ");
                }

            }
        }
    }
}
