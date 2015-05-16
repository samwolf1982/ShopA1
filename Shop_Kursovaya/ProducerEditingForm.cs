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
    public partial class ProducerEditingForm : FormEditor
    {
        // название , страна, описание 
        string Name;
        string Country;
        string Description;

        public ProducerEditingForm()
        {
            InitializeComponent();
        }
      
        public ProducerEditingForm(string lconnstring, int id = 0)
        {
            InitializeComponent();

            this.buttonChangeName(id);

            DescriptionChangeText(id, "производитель");

            connection = new SqlConnection();
            connection.ConnectionString = lconnstring;         

            CurrentIdRow = id;
            // если данные редактируются
            if (id > 0)
            {
                BindData();
            }
        }

        /// <summary>
        ///  получить и отобразить текущие данные 
        /// </summary>
        void BindData()
        {
            SqlDataReader datareader = null;

            // получить данные поставщика по запросу 
            string lcommandtext = @"SELECT
                                          [Name]
                                         ,[Country]
                                         ,[Description]
                                     FROM [Producer]
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
                    Name = datareader[0].ToString();
                    Country = datareader[1].ToString();
                    Description = datareader[2].ToString();
                }

                textBox1.Text = Name;
                textBox2.Text = Country;
                textBox3.Text = Description;

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

        bool  GetData()
        {
            if (textBox1.Text.Length < 1 && textBox1.Text.Length < 1 && textBox1.Text.Length < 1)
            {
                MessageBox.Show("Нет данных внесения изменеий");
                return false;
            }
            if (textBox1.Text == Name
                && textBox1.Text == Country
                & textBox1.Text == Description)
            {
                MessageBox.Show("Входные параметры пусты");
                return false;
            }
          
            Name = textBox1.Text;
            Country = textBox2.Text;
            Description = textBox3.Text;
            return true;
        }

        /// <summary>
        /// Внесение изменений 
        /// </summary>
        /// <param name="CurrentIdRow"></param>
        void UpdateData(int CurrentIdRow)
        {
            int updateresult;           

            string lcommandtext = @"UPDATE [Producer]
                                       SET [Name] = @Name
                                          ,[Country] = @Country
                                          ,[Description] = @Description
                                     WHERE ID = @ID";
            
            if (!GetData())
                return;

            //  datareader = new SqlDataReader();
            SqlCommand lcommand = new SqlCommand(lcommandtext);
            lcommand.Connection = connection;

            // задать параметры для выполнения 
            lcommand.Parameters.Add("@ID", SqlDbType.Int);
            lcommand.Parameters["@ID"].Value = CurrentIdRow;

            lcommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
            lcommand.Parameters["@Name"].Value = Name;

            lcommand.Parameters.Add("@Country", SqlDbType.NVarChar, 50);
            lcommand.Parameters["@Country"].Value = Country;

            lcommand.Parameters.Add("@Description", SqlDbType.Text);
            lcommand.Parameters["@Description"].Value = Description;

            try
            {
                connection.Open();

                updateresult = lcommand.ExecuteNonQuery();

                if (updateresult > 0)
                {
                    MessageBox.Show("Данные успешно обновлены", "Обновление данных");
                }                
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

        /// <summary>
        /// вставка ной строки данных
        /// </summary>
        protected override void InsertRow()
        {
            // флаг типа выполнения запроса 
            int goodRun;

            GetData();

            // непосредственно комманда
            string lcommand = @"INSERT INTO [Producer] ([Name],[Country],[Description])
                                     VALUES (@Name,@Country,@Description)";

            Sqlcommand = new SqlCommand();

            Sqlcommand.CommandText = lcommand;
            Sqlcommand.Connection = connection;

            // задать параметры для выполнения 
            Sqlcommand.Parameters.Add("@ID", SqlDbType.Int);
            Sqlcommand.Parameters["@ID"].Value = CurrentIdRow;

            Sqlcommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
            Sqlcommand.Parameters["@Name"].Value = Name;

            Sqlcommand.Parameters.Add("@Country", SqlDbType.NVarChar, 50);
            Sqlcommand.Parameters["@Country"].Value = Country;

            Sqlcommand.Parameters.Add("@Description", SqlDbType.Text);
            Sqlcommand.Parameters["@Description"].Value = Description;

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
     
    }
}
