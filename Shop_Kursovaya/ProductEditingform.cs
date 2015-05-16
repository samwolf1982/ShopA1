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
    public partial class ProductEditingform : FormEditor
    {
        SqlConnection connection;
        int CurrentIdRow;

        DateTime Createddate;
        bool Garanty;
        double Cost;
        int StocksQty;
        string Description;

        int CategoryId = 0;
        int ProducerId = 0;


        //public ProductEditingform()
        //{
        //    InitializeComponent();
        //}

        public ProductEditingform(string lconnstring, int pCurrentRowNum = 0)
        {
            InitializeComponent();
            this.buttonChangeName(pCurrentRowNum);
            DescriptionChangeText(pCurrentRowNum, "Товар");
            connection = new SqlConnection();
            connection.ConnectionString = lconnstring;
            CurrentIdRow = pCurrentRowNum;
            BindDefaultData();
            this.buttonChangeName(pCurrentRowNum);
            // если данные редактируются
            if (pCurrentRowNum > 0)
            {
                BindData();
            }
            else
            {
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
            }
        }

        SqlDataReader datareader;
        void BindData()
        {
            string lcommandtext = @"SELECT [Createddate]
                                          ,[Garanty]
                                          ,[Cost]
                                          ,[StocksQty]
                                          ,[Name]
                                          ,[Description]
                                      FROM [Product]
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

                Garanty = false;
                Cost = 0;
                StocksQty = 0;
                Description = "";

                int CategoryId;
                int ProducerId;

                object currValue;
                while (datareader.Read())
                {
                    currValue = datareader[0];
                    if (!(DateTime.TryParse(currValue.ToString(), out Createddate)))
                        Createddate = DateTime.Now;

                    Garanty = (bool)datareader[1];
                    Cost = Convert.ToDouble(datareader[2]);
                    StocksQty = Convert.ToInt32(datareader[3]);
                    Name = datareader[4].ToString();
                    Description = datareader[5].ToString();
                }
                // закрыть
                datareader.Close();

                textBox1.Text = Name;
                textBox2.Text = Cost.ToString();
                textBox3.Text = StocksQty.ToString();
                textBox4.Text = Description;
                checkBox1.Checked = Garanty;
                dateTimePicker1.Value = Createddate;

                // выбрать категорию по id 
                lcommandtext = @"SELECT  Cathegory.Name,Cathegory.ID
                                   FROM  CathegoryProduct 
                             INNER JOIN  Cathegory ON CathegoryProduct.CategoryID = Cathegory.ID
                                  WHERE CathegoryProduct.ProductID = @ID";

                lcommand = new SqlCommand(lcommandtext);
                lcommand.Connection = connection;

                // задать параметры для выполнения 
                lcommand.Parameters.Add("@ID", SqlDbType.Int);
                lcommand.Parameters["@ID"].Value = CurrentIdRow;

                datareader = lcommand.ExecuteReader();

                string cathegoryname = "";

                CategoryId = 0;
                while (datareader.Read())
                {
                    cathegoryname = datareader[0].ToString();
                    CategoryId = Convert.ToInt32(datareader[1]);
                }

                textBox5.Text = cathegoryname;
                cmbxCathegory.SelectedIndex = CategoryId - 1;

                datareader.Close();

                //сбиндить данные по поставщику 
                lcommandtext = @"SELECT Producer.Name, ProductProducer.ProductId 
                                   FROM Producer
                             INNER JOIN ProductProducer ON Producer.ID = ProductProducer.Producerid
                                  WHERE ProductProducer.ProductID = @ID";

                lcommand = new SqlCommand(lcommandtext);
                lcommand.Connection = connection;

                // задать параметры для выполнения 
                lcommand.Parameters.Add("@ID", SqlDbType.Int);
                lcommand.Parameters["@ID"].Value = CurrentIdRow;

                datareader = lcommand.ExecuteReader();

                string producer = "";
                ProducerId = 0;

                while (datareader.Read())
                {
                    producer = datareader[0].ToString();
                    ProducerId = Convert.ToInt32(datareader[1]);
                }

                textBox6.Text = producer;
                cmbxProducer.SelectedIndex = ProducerId - 1;
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

        /// <summary>
        /// считывание данных с контролов 
        /// </summary>
        /// <returns></returns>
        protected override bool GetData()
        {
            bool result = false;

            if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Поле 'Наименование обязательное к заполнению", "Некорректные данные");
                return false;
            }

            if (textBox2.Text.Length < 1)
            {
                MessageBox.Show("Поле 'Cтоимость' обязательное к заполнению", "Некорректные данные");
                return false;
            }

            if (textBox3.Text.Length < 1)
            {
                MessageBox.Show("Поле 'Остаток на складе' обязательное к заполнению", "Некорректные данные");
                return false;
            }

            if (textBox5.Text.Length < 1)
            {
                MessageBox.Show("Не выбрана категория товара", "Некорректные данные");
                return false;
            }

            if (textBox6.Text.Length < 1)
            {
                MessageBox.Show("Не выбран производитель товара", "Некорректные данные");
                return false;
            }

            try
            {
                string theDate = dateTimePicker1.Value.ToShortDateString();
                Createddate = this.dateTimePicker1.Value.Date;
                Name = textBox1.Text;

                double.TryParse(textBox2.Text, out Cost);
                int.TryParse(textBox3.Text, out StocksQty);

                Description = textBox4.Text;
                Garanty = checkBox1.Checked;

                result = true;
            }
            catch (Exception ex) {}
            return result;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void BindDefaultData()
        {
            //cmbxCathegory
            string commandText;
            Sqlcommand = new SqlCommand();
            commandText = @"SELECT [ID]
                                          ,[Name]     
                                      FROM Cathegory ";

            Sqlcommand.Connection = connection;
            Sqlcommand.CommandText = commandText;
            DataSet dset = new DataSet();

            SqlDataAdapter dadpter = new SqlDataAdapter();
            dadpter.SelectCommand = Sqlcommand;

            dadpter.Fill(dset);
            cmbxCathegory.DataSource = dset.Tables[0];
            cmbxCathegory.DisplayMember = "Name"; // to display roll no. in combobox
            cmbxCathegory.ValueMember = "ID"; // to store name as value of combobox for selected 
            //----------------------------------------
            Sqlcommand = new SqlCommand();
            commandText = @"SELECT [ID]
                                  ,[Name]     
                              FROM [Producer]";

            Sqlcommand.Connection = connection;
            Sqlcommand.CommandText = commandText;
            DataSet dsetPrcr = new DataSet();

            SqlDataAdapter daPrcr = new SqlDataAdapter();
            daPrcr.SelectCommand = Sqlcommand;

            daPrcr.Fill(dsetPrcr);
            cmbxProducer.DataSource = dsetPrcr.Tables[0];
            cmbxProducer.DisplayMember = "Name"; // to display roll no. in combobox
            cmbxProducer.ValueMember = "ID"; // to store name as value of combobox for selected 
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
        /// вставка новой строки данных
        /// </summary>
        protected override void InsertRow()
        {
            // флаг типа выполнения запроса 
            int goodRun;
            SqlCommand sqlcommand2 = new SqlCommand();

            //номер последней добавленной записи
            int lastID;

            // все делаем в транзакции
            SqlTransaction tx = null;

            if (!GetData())
                return;
            // непосредственно команда
            string lcommand = @"INSERT INTO [Product] ([Createddate],[Garanty],[Cost],[StocksQty],[Name],[Description])
                                     VALUES (@Createddate,@Garanty,@Cost,@StocksQty,@Name,@Description)";

            Sqlcommand = new SqlCommand();
            Sqlcommand.CommandText = lcommand;
            Sqlcommand.Connection = connection;

            // задать параметры для выполнения 
            Sqlcommand.Parameters.Add("@Createddate", SqlDbType.SmallDateTime);
            Sqlcommand.Parameters["@Createddate"].Value = Convert.ToDateTime(Createddate);

            Sqlcommand.Parameters.Add("@Garanty", SqlDbType.Bit);
            Sqlcommand.Parameters["@Garanty"].Value = Garanty;

            Sqlcommand.Parameters.Add("@Cost", SqlDbType.Decimal);
            Sqlcommand.Parameters["@Cost"].Value = Cost;

            Sqlcommand.Parameters.Add("@StocksQty", SqlDbType.Int);
            Sqlcommand.Parameters["@StocksQty"].Value = StocksQty;

            Sqlcommand.Parameters.Add("@Name", SqlDbType.Text);
            Sqlcommand.Parameters["@Name"].Value = Name;

            Sqlcommand.Parameters.Add("@Description", SqlDbType.Text);
            Sqlcommand.Parameters["@Description"].Value = Description;

            try
            {
                connection.Open();
                goodRun = Sqlcommand.ExecuteNonQuery();

                lcommand = @"SELECT @@IDENTITY";
                sqlcommand2.CommandText = lcommand;
                sqlcommand2.Connection = connection;

                // непосредственно индекс последнего добавленного ключа
                lastID = Convert.ToInt32(sqlcommand2.ExecuteScalar());

                // создаем запись в таблице производитель - товар 
                lcommand = @"INSERT INTO [ProductProducer]([ProductId],[Producerid])
                                  VALUES(@ProductId,@Producerid)";

                Sqlcommand.Parameters.Add("@ProductId", SqlDbType.Int);
                Sqlcommand.Parameters["@ProductId"].Value = lastID;

                Sqlcommand.Parameters.Add("@Producerid", SqlDbType.Int);
                Sqlcommand.Parameters["@Producerid"].Value = ProducerId - 1;

                Sqlcommand.CommandText = lcommand;
                goodRun = Sqlcommand.ExecuteNonQuery();
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // создаем запись в таблице категории продукта 
                lcommand = @"INSERT INTO [CathegoryProduct] ([CategoryID],[ProductID])
                                  VALUES (@CategoryID,@ProductID)";

                Sqlcommand.Parameters.Add("@ProductId", SqlDbType.Int);
                Sqlcommand.Parameters["@ProductId"].Value = lastID;

                Sqlcommand.Parameters.Add("@CategoryID", SqlDbType.Int);
                Sqlcommand.Parameters["@CategoryID"].Value = CategoryId - 1;

                Sqlcommand.CommandText = lcommand;
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
        /// получение категории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxCathegory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryId = cmbxCathegory.SelectedIndex;
            textBox5.Text = cmbxCathegory.Text;
        }

        /// <summary>
        /// выбор производителя из списка 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProducerId = cmbxProducer.SelectedIndex;
            textBox6.Text = cmbxProducer.Text;
        }


        /// <summary>
        /// проверка  данных при вводе цены 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') || (e.KeyChar <= '0'))
            {
                // e нас цифра
                return;
            }

            //точку заменяем запятой 
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox2.Text.IndexOf(',') != -1)
                {
                    //уже есть запятая 
                    e.Handled = true;
                }
            }
            if (char.IsControl(e.KeyChar))
            {
                //Enter
                if (e.KeyChar == (char)Keys.Enter)
                {
                    // убрать данные 
                    textBox2.Text = string.Empty;
                }
            }
            //остальные символы запрещены 
            e.Handled = true;
        }


        //остаток на складе
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') || (e.KeyChar <= '0'))
            {
                // e нас цифра
                return;
            }
            //точку заменяем запятой 
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox3.Text.IndexOf(',') != -1)
                {
                    //уже есть запятая 
                    e.Handled = true;
                }
            }

            if (char.IsControl(e.KeyChar))
            {
                //Enter
                if (e.KeyChar == (char)Keys.Enter)
                {
                    // убрать данные 
                    textBox3.Text = string.Empty;
                }
            }
            //остальные символы запрещены 
            e.Handled = true;
        }
    }
}
