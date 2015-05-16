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
    public partial class financialReportEveryDay : Form
    {
        SqlConnection conn;
        string connectionString;

        SqlDataAdapter adapter;
        DataSet ds;

        public financialReportEveryDay()
        {
            InitializeComponent();
        }

        
        public financialReportEveryDay(string connString)
        {
            InitializeComponent();

            connectionString= connString;
            BindData();
        }

        private void BindData()
        {                       
          
             conn = new SqlConnection(connectionString);
            try
            {
                //открываем соединение с базой данных
                conn.Open();
                //создаем новый ДатаАдаптер
                adapter = new SqlDataAdapter(@"SELECT  Product.ID, Product.Createddate, Product.Garanty, Product.Cost, Product.Name, Cathegory.Name AS Expr1, Producer.Name AS Expr2, Producer.Country
                                                  FROM  Cathegory 
                                            INNER JOIN
                                            CathegoryProduct ON Cathegory.ID = CathegoryProduct.CategoryID INNER JOIN
		                                            Product ON CathegoryProduct.ProductID = Product.ID INNER JOIN
		                                            ProductProducer ON Product.ID = ProductProducer.ProductId INNER JOIN
		                                            Producer ON ProductProducer.Producerid = Producer.ID", conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                //создаем новый ДатаСет
                ds = new DataSet();
                //связываем DataSet и таблицу test из базы данных
                adapter.Fill(ds, "Buyer");
                //к элементу формы bindingSource (который мы кинули на форму) привязываем таблицу из DataSet-а 
                bindingSource1.DataSource = ds.Tables[0];
                //привязываем bindingSource к bindingNavigator (который мы кинули на форму)
                bindingNavigator1.BindingSource = bindingSource1;
                //привязываем к нашей гриде (которую мы кинули на форму) наш bindingSource
                grdResult.DataSource = bindingSource1;

            }
            catch (Exception exception)
            {
                //перехватываем и выводим исключение
                MessageBox.Show(exception.Message);
            }
            finally
            {
                //закрываем соединение с базой данных
                conn.Close();
            }
        }
        
        /// <summary>
        /// отфильтровать данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);

            string currDate = dateTimePicker2.Value.ToShortDateString();
            try
            {
                //открываем соединение с базой данных
                conn.Open();
                string commandString = @"  
                                                SELECT  Product.ID, Product.Createddate, Product.Garanty, Product.Cost, Product.Name, Cathegory.Name AS Expr1, Producer.Name AS Expr2, Producer.Country
                                                  FROM  Cathegory 
                                            INNER JOIN
                                            CathegoryProduct ON Cathegory.ID = CathegoryProduct.CategoryID INNER JOIN
		                                            Product ON CathegoryProduct.ProductID = Product.ID INNER JOIN
		                                            ProductProducer ON Product.ID = ProductProducer.ProductId INNER JOIN
		                                            Producer ON ProductProducer.Producerid = Producer.ID
                                                WHERE Product.Createddate =@Createddate  ";
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = conn;
                sqlcommand.CommandText = commandString;

                //создаем новый ДатаАдаптер
                adapter = new SqlDataAdapter(sqlcommand);

                sqlcommand.Parameters.Add("@Createddate", SqlDbType.SmallDateTime);
                sqlcommand.Parameters["@Createddate"].Value = currDate;
                
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                //создаем новый ДатаСет
                ds = new DataSet();
                //связываем DataSet и таблицу test из базы данных
                adapter.Fill(ds, "Buyer");
                //к элементу формы bindingSource (который мы кинули на форму) привязываем таблицу из DataSet-а 
                bindingSource1.DataSource = ds.Tables[0];
                //привязываем bindingSource к bindingNavigator (который мы кинули на форму)
                bindingNavigator1.BindingSource = bindingSource1;
                //привязываем к нашей гриде (которую мы кинули на форму) наш bindingSource
                grdResult.DataSource = bindingSource1;

            }
            catch (Exception exception)
            {
                //перехватываем и выводим исключение
                MessageBox.Show(exception.Message);
            }
            finally
            {
                //закрываем соединение с базой данных
                conn.Close();
            }
        }
    }
}
