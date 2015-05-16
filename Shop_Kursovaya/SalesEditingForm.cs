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
    public partial class SalesEditingForm : FormEditor
    {
        int CurrentIdRow;

        int CurrentProduct;
        int CurrentPerson;
        double SalesQty;
        double CurrentStockQty;

        public SalesEditingForm(string lconnstring, int id = 0)
        {
            InitializeComponent();

            InitializeComponent();

            this.buttonChangeName(id);

            DescriptionChangeText(id, "заказы");

            connection = new SqlConnection();
            connection.ConnectionString = lconnstring;

            CurrentIdRow = id;

            //заполнение выпадающих списков 
            BindDefaultData();

            CurrentProduct= 0;
            CurrentPerson =0;

            // если данные редактируются
            if (id > 0)
            {
                BindData();
            }
        }


        SqlDataReader datareader;
        void BindData()
        {
            string lcommandtext = @"SELECT  Sales.SalesQty, Product.ID
                                            , Bill.BuyerId
                                            , Sales.SalesQty, Buyer.Name +' '  +Buyer.LName [Name]
                                        FROM   Product INNER JOIN
                                          Sales ON Product.ID = Sales.ProductId INNER JOIN
                                          Bill ON Sales.ID = Bill.SalesId INNER JOIN
                                          Buyer ON Bill.BuyerId = Buyer.ID
                                         WHERE Product.ID = @ID";

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
                   // CurrentProduct = Convert.ToInt32(datareader[0]);
                   // CurrentPerson = Convert.ToInt32(datareader[1]);
                    SalesQty = Convert.ToDouble(datareader[0]); 
                    
                }

                CurrentStockQty = SalesQty;
                // закрыть
                datareader.Close();

                cmbxProduct.SelectedIndex = CurrentProduct ;
                cmbClient.SelectedIndex = CurrentPerson ;
                textBox1.Text = SalesQty.ToString();               
           
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

        void BindDefaultData()
        {
            //cmbClient

            string commandText;
            Sqlcommand = new SqlCommand();
            commandText = @"SELECT [ID]
                                          ,LName+ ' '+ Name [Name]     
                                      FROM Buyer ";

            Sqlcommand.Connection = connection;
            Sqlcommand.CommandText = commandText;
            DataSet dset = new DataSet();

            SqlDataAdapter dadpter = new SqlDataAdapter();
            dadpter.SelectCommand = Sqlcommand;

            dadpter.Fill(dset);
            cmbClient.DataSource = dset.Tables[0];
            cmbClient.DisplayMember = "Name"; // to display roll no. in combobox
            cmbClient.ValueMember = "ID"; // to store name as value of combobox for selected 
            
            //----------------------------------------
            Sqlcommand = new SqlCommand();
            commandText = @"SELECT [ID]
                                  ,[Name]     
                              FROM [Product]";

            Sqlcommand.Connection = connection;
            Sqlcommand.CommandText = commandText;
            DataSet dsetPrcr = new DataSet();

            SqlDataAdapter daPrcr = new SqlDataAdapter();
            daPrcr.SelectCommand = Sqlcommand;

            daPrcr.Fill(dsetPrcr);
            cmbxProduct.DataSource = dsetPrcr.Tables[0];
            cmbxProduct.DisplayMember = "Name"; // to display roll no. in combobox
            cmbxProduct.ValueMember = "ID"; // to store name as value of combobox for selected 

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
       
        protected virtual void InsertRow()
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
            // непосредственно комманда
            string lcommand = @"INSERT INTO [Sales]
                                           ([Number],[AccountNumber],[ProductId],[SalesQty],[DalesDate])
                                     VALUES
                                           (@Number
                                           ,@AccountNumber
                                           ,@ProductId
                                           ,@SalesQty
                                           ,@DalesDate)";

            Sqlcommand = new SqlCommand();

            Sqlcommand.CommandText = lcommand;

            Sqlcommand.Connection = connection;

            // задать параметры для выполнения 
            Sqlcommand.Parameters.Add("@DalesDate", SqlDbType.SmallDateTime);
            Sqlcommand.Parameters["@DalesDate"].Value = DateTime.Now;

            Sqlcommand.Parameters.Add("@Number", SqlDbType.Int);
            Sqlcommand.Parameters["@Number"].Value = 0;

            Sqlcommand.Parameters.Add("@AccountNumber", SqlDbType.Text);
            Sqlcommand.Parameters["@AccountNumber"].Value = "";

            Sqlcommand.Parameters.Add("@ProductId", SqlDbType.Int);
            Sqlcommand.Parameters["@ProductId"].Value = CurrentProduct+1;

            Sqlcommand.Parameters.Add("@SalesQty", SqlDbType.Decimal);
            Sqlcommand.Parameters["@SalesQty"].Value = Quatntity;

        
            try
            {
                connection.Open();

                goodRun = Sqlcommand.ExecuteNonQuery();

                lcommand = @"SELECT @@IDENTITY";
                sqlcommand2.CommandText = lcommand;
                sqlcommand2.Connection = connection;

                // непосредственно индекс последнего добавленного ключа
                lastID = Convert.ToInt32(sqlcommand2.ExecuteScalar());

                // создаем запись в таблице чек                        
                
                lcommand = @"INSERT INTO [Bill]([BuyerId],[SalesId])
                                                VALUES (@BuyerId,@SalesId) ";
               
                    // указать покупателя
                Sqlcommand.Parameters.Add("@BuyerId", SqlDbType.Int);
                Sqlcommand.Parameters["@BuyerId"].Value = CurrentPerson +1 ;

                Sqlcommand.Parameters.Add("@SalesId", SqlDbType.Int);
                // так как нумерация с нуля
                Sqlcommand.Parameters["@SalesId"].Value = lastID;

                Sqlcommand.CommandText = lcommand;
                goodRun = Sqlcommand.ExecuteNonQuery();

                double qty = CurrentStockQty - SalesQty; //Quatntity
                // уменьшить количество
                lcommand = @"UPDATE [Product]
                                SET [StocksQty] = @StocksQty      
                              WHERE ID = @ID";

                Sqlcommand.Parameters.Add("@ID", SqlDbType.Int);
                Sqlcommand.Parameters["@ID"].Value = CurrentProduct+1;

                Sqlcommand.Parameters.Add("@StocksQty", SqlDbType.Int);
                // уменьшить количество на складе
                Sqlcommand.Parameters["@StocksQty"].Value = qty;            

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

        double Quatntity;

        protected virtual void UpdateData(int pId)
        {
            string command = @"";
        }

        protected virtual bool GetData() 
        {
            bool result = false;

            if (textBox1.Text.Length >= 1)
            {
                CurrentProduct = cmbxProduct.SelectedIndex ;
                CurrentPerson = cmbClient.SelectedIndex ;
               
                result = double.TryParse(textBox1.Text, out Quatntity);
            }

            return result; 
        }


        /// <summary>
        /// выбор товара 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentProduct = cmbxProduct.SelectedIndex ;
        }

        //выбор клиента
        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPerson = cmbClient.SelectedIndex;
        }
    }
}
