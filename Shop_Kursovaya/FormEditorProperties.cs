using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Reflection;

namespace Shop_Kursovaya
{
    public partial class FormEditorProperties : Form
    {
        public string connectionString;

        string dataBaseName;
        string serverName;
        string userName;
        string DBPass;

        string currentConnectionString;

        public FormEditorProperties()
        {
            InitializeComponent();

            //считываем данные для подключения
            dataBaseName = Properties.Settings.Default.DBName;
            serverName = Properties.Settings.Default.DBSreverName;
            userName = Properties.Settings.Default.DBUserName;
            DBPass = Properties.Settings.Default.DBPass;

            //имя сервера
            textBox2.Text = serverName;
            textBox3.Text = dataBaseName;
            textBox4.Text = userName;
            textBox1.Text = DBPass;

          
            
            // 2 -й вариант
            currentConnectionString = ConfigurationManager.ConnectionStrings["Shop_Kursovaya.Properties.Settings.shopConnectionString"].ConnectionString;
        }





        // TODO:
        // плохой вариант
        private void button1_Click(object sender, EventArgs e)
        {
            string dateconn = @"Data Source={0};Initial Catalog={1};User ID={2}; Password={3}";

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                serverName = textBox2.Text;
                dataBaseName = textBox3.Text;
                userName = textBox4.Text;
                DBPass = textBox1.Text;


            }
            else
            {
                MessageBox.Show("название сервера, Пользователь, Пароль и название Базы Данных обязательны для заполнения", "Незаполнены поля", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = string.Format(dateconn, serverName, dataBaseName, userName, DBPass);
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            SqlConnection sqlconnection = new SqlConnection();

            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                string msgName = string.Concat("Ошибка подключения к ", serverName);
                MessageBox.Show(ex.Message, msgName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                //если получилось законнектиться 
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    //используем только авторизацию SQL Server 
                    serverName = textBox2.Text;
                    dataBaseName = textBox3.Text;
                    userName = textBox4.Text;
                    DBPass = textBox1.Text;

                    Properties.Settings.Default.DBName = dataBaseName;
                    Properties.Settings.Default.DBSreverName = serverName;
                    Properties.Settings.Default.DBUserName = userName;
                    Properties.Settings.Default.DBPass = DBPass;
                   
                    //сохраняем настройки 
                    Properties.Settings.Default.Save();

                    //обновляем данные строки подключения
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                   config.ConnectionStrings.ConnectionStrings["Shop_Kursovaya.Properties.Settings.shopConnectionString"].ConnectionString = connectionString;
                                                           
                    config.Save(ConfigurationSaveMode.Modified, true);
                    ConfigurationManager.RefreshSection("connectionStrings");

                    DialogResult = DialogResult.OK;

                }
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// завершить приложение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEditorProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }


    }
}
