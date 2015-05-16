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
    public partial class ClientEditingForm : FormEditor
    {
        string _Name = "";
        string LName = "";
        string MName = "";
        string Adress = "";

        public ClientEditingForm(string lconnstring,int id= 0)
        {
            InitializeComponent();
            
            this.buttonChangeName(id);            

            this.Text = @"Редактирование клиента";

            connection = new SqlConnection();
            connection.ConnectionString = lconnstring;

            CurrentIdRow = id; 

            if (id > 0)
            {
                BindData(id);
            }
        }

        /// <summary>
        /// получение данных для редактирования и привязка 
        /// </summary>
        /// <param name="lconnstring"></param>
        /// <param name="pid"></param>
        void BindData(int pid)
        {
            SqlDataReader dataReader;
            int updateresult;

            string lcommandtext = @"SELECT 
                                          [Name]
                                          ,[LName]
                                          ,[MName]
                                          ,[Adress]
                                      FROM [shop].[dbo].[Buyer]
                                     WHERE ID = @ID  ";
            

            //  datareader = new SqlDataReader();
            SqlCommand lcommand = new SqlCommand(lcommandtext);
            lcommand.Connection = connection;

            // задать параметры для выполнения 
            lcommand.Parameters.Add("@ID", SqlDbType.Int);
            lcommand.Parameters["@ID"].Value = CurrentIdRow;         

            try
            {
                connection.Open();

                dataReader = lcommand.ExecuteReader();

                while (dataReader.Read())
                {
                    _Name = dataReader[0].ToString();
                    LName = dataReader[1].ToString();
                    MName = dataReader[2].ToString();
                    Adress = dataReader[3].ToString();
                }

                dataReader.Close();

                textBox1.Text = _Name;
                textBox2.Text = LName;
                textBox3.Text = MName;
                textBox4.Text = Adress;         

               
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


        //получение данных введенных пользователем 
        protected override bool GetData()
        {
            if (textBox1.Text.Length < 1
                && textBox2.Text.Length < 1
                && textBox3.Text.Length < 1
                && textBox4.Text.Length < 1)
            {
                MessageBox.Show("нет данных для внесения обновлений");
                return false;
            }

            if (textBox1.Text.Length > 0)
            {
                _Name = textBox1.Text;
            }
            if (textBox2.Text.Length > 0)
            {
                LName = textBox2.Text;
            }
            if (textBox3.Text.Length > 0)
            {
                MName = textBox3.Text;
            }
            if (textBox4.Text.Length > 0)
            {
                Adress = textBox4.Text;
            }

            return true;
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
        protected override void InsertRow()
        {
            // флаг типа выполнения запроса 
            int goodRun;

            GetData();

            // непосредственно комманда
            string lcommand = @"INSERT INTO [Buyer] ([Name],[LName],[MName],[Adress])
                                     VALUES  (@Name,@LName,@MName,@Adress)";

            Sqlcommand = new SqlCommand(); 
            
            Sqlcommand.CommandText = lcommand;
            Sqlcommand.Connection = connection;

            // задать параметры для выполнения 
            Sqlcommand.Parameters.Add("@Name",SqlDbType.NVarChar,50);
            Sqlcommand.Parameters["@Name"].Value = _Name;

            Sqlcommand.Parameters.Add("@LName", SqlDbType.NVarChar, 50);
            Sqlcommand.Parameters["@LName"].Value = LName;
            
            Sqlcommand.Parameters.Add("@MName", SqlDbType.NVarChar, 50);
            Sqlcommand.Parameters["@MName"].Value = MName;

            Sqlcommand.Parameters.Add("@Adress", SqlDbType.Text);
            Sqlcommand.Parameters["@Adress"].Value = Adress;

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
            catch(Exception exc)
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

    

     

        protected override void UpdateData(int pId)
        {
            int updateresult;
            string lcommandtext = @"UPDATE [Buyer]
                           SET [Name] =  @Name
                              ,[LName] = @LName
                              ,[MName] = @MName
                              ,[Adress] = @Adress
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
            lcommand.Parameters["@Name"].Value = _Name;

            lcommand.Parameters.Add("@LName", SqlDbType.NVarChar, 50);
            lcommand.Parameters["@LName"].Value = LName;


            lcommand.Parameters.Add("@MName", SqlDbType.NVarChar, 50);
            lcommand.Parameters["@MName"].Value = MName;

            lcommand.Parameters.Add("@Adress", SqlDbType.Text);
            lcommand.Parameters["@Adress"].Value = Adress;

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

     
    
    

   
    }
}
