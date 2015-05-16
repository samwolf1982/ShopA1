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
    public partial class CathegoryForm : FormEditor
    {
        string _Name;
        string _Description;

        SqlDataReader datareader;

        public CathegoryForm()
        {
            InitializeComponent();
        }
        public CathegoryForm(string lconnstring, int id = 0)
        {
            InitializeComponent();

            this.buttonChangeName(id);

            DescriptionChangeText(id, "категории");

            connection = new SqlConnection();
            connection.ConnectionString = lconnstring;

            CurrentIdRow = id;
            // если данные редактируются
            if (id > 0)
            {
                BindData();
            }
        }

        private bool GetData()
        {
            if (textBox1.Text.Length > 0)
            {
                _Name = textBox1.Text;
            }
            if (textBox2.Text.Length > 0)
            {
                _Description = textBox2.Text;
            }
            return true;
        }

        /// <summary>
        ///  получить и отобразить текущие данные 
        /// </summary>
        void BindData()
        {
            string lcommandtext = @"SELECT 
                                           [Name]
                                          ,[Description]
                                      FROM [Cathegory]
                                    WHERE ID = @ID";
        
            SqlCommand lcommand = new SqlCommand(lcommandtext);
            lcommand.Connection = connection;

            // задать параметры для выполнения 
            lcommand.Parameters.Add("@ID", SqlDbType.Int);
            lcommand.Parameters["@ID"].Value = CurrentIdRow;

            try
            {
                   connection.Open();
                   datareader = lcommand.ExecuteReader();

                   while (datareader.Read())
                   {
                       _Name = datareader[0].ToString();
                       _Description = datareader[1].ToString();                    
                   }

                   textBox1.Text = _Name;
                   textBox2.Text = _Description;
                   datareader.Close();   
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                if (!datareader.IsClosed)
                {
                    datareader.Close();
                }
            }
         
        }

        void UpdateData(int CurrentIdRow)
        {
            int updateresult;
            
            string lcommandtext = @"UPDATE [Cathegory]
                                    SET Name = @Name
                                        ,Description =@Description
                                    WHERE ID = @ID";
            GetData();

            //  datareader = new SqlDataReader();
            SqlCommand lcommand = new SqlCommand(lcommandtext);
            lcommand.Connection = connection;

            // задать параметры для выполнения 
            lcommand.Parameters.Add("@ID", SqlDbType.Int);
            lcommand.Parameters["@ID"].Value = CurrentIdRow;

            lcommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
            lcommand.Parameters["@Name"].Value = _Name;

            lcommand.Parameters.Add("@Description", SqlDbType.Text);
            lcommand.Parameters["@Description"].Value = _Description;

            try
            {
                connection.Open();

                updateresult =  lcommand.ExecuteNonQuery();

                if (updateresult > 0)
                {
                    MessageBox.Show("Данные успешно обновлены", "Обновление данных");
                }

                datareader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                if (!datareader.IsClosed)
                {
                    datareader.Close();
                }
            }
        }

        protected override void CreateCommand()
        {
            //если режим добавления 
            if (isInsertRow)
            {
                InsertRow();
            }
            else
            {
                UpdateData(CurrentIdRow);
            }
        }

        /// <summary>
        /// вставка ной строки данных
        /// </summary>
        void InsertRow()
        {
            // флаг типа выполнения запроса 
            int goodRun;

            GetData();

            // непосредственно комманда
            string lcommand = @"INSERT INTO [Cathegory] ([Name],[Description])
                                     VALUES (@Name,@Description)";

            Sqlcommand = new SqlCommand();

            Sqlcommand.CommandText = lcommand;
            Sqlcommand.Connection = connection;

            // задать параметры для выполнения 
            Sqlcommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
            Sqlcommand.Parameters["@Name"].Value = _Name;

            Sqlcommand.Parameters.Add("@Description", SqlDbType.Text);
            Sqlcommand.Parameters["@Description"].Value = _Description;

            try
            {
                connection.Open();

                goodRun = Sqlcommand.ExecuteNonQuery();

                if (goodRun > 0)
                {
                    MessageBox.Show("Изменения внесены", "Дабавление записи");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при добавлении данных ");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Непредвиденная ошибка");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// обновление  данных в базе 
        /// </summary>
        void UpdateData()
        {
            int updateres;

            ///SqlDataReader datareader;
            string lcommandtext = @"SELECT 
                                         Name [Наименование]
                                        ,Description [Описание]
                                    FROM [Cathegory]
                                    WHERE ID = @ID";


            SqlCommand lcommand = new SqlCommand(lcommandtext);
            lcommand.Connection = connection;

            // задать параметры для выполнения 
            lcommand.Parameters.Add("@ID", SqlDbType.Int);
            lcommand.Parameters["@ID"].Value = CurrentIdRow;


            try
            {
                connection.Open();
              //  datareader = lcommand.ExecuteReader();

                updateres = Sqlcommand.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
