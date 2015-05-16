using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Shop_Kursovaya
{
    public partial class FormEditor : Form
    {
        public SqlConnection connection;
        public SqlCommand Sqlcommand;

        public bool isInsertRow;
        public int CurrentIdRow;

        public FormEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// конструктор формы 
        /// </summary>
        /// <param name="lconnstring">строка подключения</param>
        /// <param name="pCurrentRowNum">идещник строки </param>
        public FormEditor(string lconnstring, int pCurrentRowNum)
        {
            InitializeComponent();
            connection = new SqlConnection();
            connection.ConnectionString = lconnstring;
            Sqlcommand = new SqlCommand();
            Sqlcommand.Connection = connection;
            CurrentIdRow = pCurrentRowNum;
        }

        public void buttonChangeName(int id)
        {
            if (id < 1)
            {
                btnOk.Text = "Добавить";
                isInsertRow = true;
            }
            else
            {
                btnOk.Text = "Изменить";
            }

            btnCancel.Text = "Отмена";
        }

        public void DescriptionChangeText(int id, string pformName)
        {
            if (id < 1)
            {
                this.Text = "Создание новой записи  " + pformName;
            }
            else
            {
                this.Text = "Редактирование записи  " + pformName;
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            CreateCommand();
        }

        protected virtual void CreateCommand()
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void InsertRow() { }
        protected virtual void UpdateData(int pId) { }
        protected virtual bool GetData() { return false; }
    }
}
