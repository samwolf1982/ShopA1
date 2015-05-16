using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shop_Kursovaya
{
    public partial class AutentificationForm : Form
    {
        private List<User> Users = new List<User>();
        private class User
        {
            public string usrName
            {
                get;
                set;
            }
            public string comment
            {
                get;
                set;
            }
            public User(string _usrName, string _comment)
            {
                usrName = _usrName;
                comment = _comment;
            }
        }


        public AutentificationForm()
        {//
            InitializeComponent();

            // Properties.Settings.Default.usrDB = "usr";
            // Properties.Settings.Default.Save();

            Users.Add(new User("Admin", "Настройка параметров"));
            Users.Add(new User(Properties.Settings.Default.usrDB, "Редактирование БД"));
            Users.Add(new User(Properties.Settings.Default.usrReport, "Просмотр отчётов"));

            cbUser.DataSource = Users;
            cbUser.DisplayMember = "comment";
            cbUser.ValueMember = "usrName";
            cbUser.SelectedIndex = 1;
        }

        /// <summary>
        ///  свойство для передачи информации о текущем пользователе
        /// </summary>
        public string usr
        {
            get
            {
                return (cbUser.Items.Count > 0) ? cbUser.SelectedValue.ToString() : string.Empty;
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormAutentification_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            switch (cbUser.SelectedValue.ToString())
            {
                case "Admin":
                    if (tbPassword.Text == Properties.Settings.Default.passAdmin)
                        using (FormEditorProperties frm = new FormEditorProperties())
                        {
                            this.Visible = false;
                            DialogResult = frm.ShowDialog(this);
                           
                        }
                    else
                    {
                        MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbPassword.Focus();
                    }
                    break;
                case "usr":
                    if (tbPassword.Text == Properties.Settings.Default.passUser)
                        using (FormEditorProperties frm = new FormEditorProperties())
                        {
                            this.Visible = false;
                            DialogResult = frm.ShowDialog(this);
                       //     this.Visible = true;
                        }
                    else
                    {
                        MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        tbPassword.Focus(); return;
                    }
                    break;

                case "usrReport":
                    if (tbPassword.Text == Properties.Settings.Default.passUser)
                        using (FormEditorProperties frm = new FormEditorProperties())
                        {
                            this.Visible = false;
                            DialogResult = frm.ShowDialog(this);
                           
                        }
                    else
                    {
                        MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        tbPassword.Focus(); return;
                    }
                    break;

                default:
                   
                    tbPassword.Text = string.Empty;
                    break;
            }
        }

    }
}
