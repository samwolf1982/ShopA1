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
    public partial class reportProductMaxSalese : Form
    {
        SqlConnection conn;
       string  connectionString;
       SqlDataAdapter adapter;

       DataSet ds;
        public reportProductMaxSalese(string lconnString)
        {
            InitializeComponent();

            connectionString = lconnString;
            DindData();
        }

        void DindData()             
        {
            conn = new SqlConnection(connectionString);

            
            try
            {
                //открываем соединение с базой данных
                conn.Open();
                string commandString = @" SELECT TOP  50  Product.Name [название товара]
                                                , Cathegory.Name [Категория]
                                                , Producer.Name  [Производитель]
                                                , Producer.Country [Страна - производитель]
                                                , Product.Cost [Стоимость]
                                                 , SALES.SALESQTY
                                                FROM    Product
                                                LEFT JOIN ProductProducer ON Product.ID = ProductProducer.ProductId
                                                LEFT JOIN Producer ON ProductProducer.Producerid = Producer.ID
                                                LEFT JOIN CathegoryProduct ON Product.ID = CathegoryProduct.ProductID
                                                LEFT JOIN Cathegory ON CathegoryProduct.CategoryID = Cathegory.ID
                                                LEFT JOIN Sales ON Product.ID = Sales.ProductId
                                                --LEFT JOIN Sales ON Product.ID = Sales.ProductId
                                                WHERE (SALES.ProductID is not null)

                                                ORDER by SALES.SALESQTY desc
                                                ";
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = conn;
                sqlcommand.CommandText = commandString;

                //создаем новый ДатаАдаптер
                adapter = new SqlDataAdapter(sqlcommand);

                
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                //создаем новый ДатаСет
                ds = new DataSet();
                //связываем DataSet и таблицу test из базы данных
                adapter.Fill(ds, "Product");
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
