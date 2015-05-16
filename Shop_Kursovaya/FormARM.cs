using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.OleDb;

using Excel = Microsoft.Office.Interop.Excel;

namespace Shop_Kursovaya
{

    public enum DataTableItem
    {
        Customer = 1,
        Order = 2,
        Product = 3
    };

    public partial class FormARM : Form
    {
       shopDataSet     rObj = new shopDataSet();
        // таблица зависимо от вкладки 
        public static DataTableItem _TableItem;

        SqlDataAdapter daBuyer;
        SqlDataAdapter cathegoryda;

        DataSet ds;
        DataSet cathegoryds;

        SqlDataAdapter daProducer;
        DataSet dsProducer;

        SqlDataAdapter daProduct;
        DataSet dsProduct;

        SqlDataAdapter daSalary;
        DataSet dsSalary;
        int _currGridRow;
        SqlConnection conn;

        string CurrentUser;

        public FormARM(string usr)
        {
            InitializeComponent();
            CreateConnectionString();
            ChangeUser(usr);
            GetData();
            CurrentUser = usr;
        }

        string dataBaseName;
        string serverName;
        string userName;
        string DBPass;
        string connectionString;

        //tovarDataGridView
        /// <summary>
        /// создание строки подключения
        /// </summary>
        void CreateConnectionString()
        {
            //получаем данные  из app config
            dataBaseName = Properties.Settings.Default.DBName;
            serverName = Properties.Settings.Default.DBSreverName;
            userName = Properties.Settings.Default.DBUserName;
            DBPass = Properties.Settings.Default.DBPass;

            string dateconn = @"Data Source={0};Initial Catalog={1};User ID={2}; Password={3}";
            connectionString = string.Format(dateconn, serverName, dataBaseName, userName, DBPass);
        }

        void GetData()
        {
            conn = new SqlConnection(connectionString);
            if (Properties.Settings.Default.usrDB != CurrentUser)
            {
                Bindclient();
                producerBindData();
                ProductBindData();
                BindCathegory();
                Bindsalary();
            }

        }
        void Bindsalary()
        {
            string commandtext = @"SELECT Product.Name [Наименование товара]
                                        , Producer.Name [Производитель]
                                        , Product.Cost [Стоимость]
                                        , Product.Garanty[Наличие гарантии]
                                        , Buyer.Name + '  '+Buyer.LName  [Покупатель]                                        
                                        , Sales.Number
                                        FROM   Sales
                                         INNER JOIN
                                              Bill ON Sales.ID = Bill.SalesId LEFT JOIN
                                              Buyer ON Bill.BuyerId = Buyer.ID LEFT JOIN
                                              Product ON Sales.ProductId = Product.ID LEFT JOIN
                                              ProductProducer ON Product.ID = ProductProducer.ProductId LEFT JOIN
                                              Producer ON ProductProducer.Producerid = Producer.ID";

            SqlCommand command = new SqlCommand(commandtext);
            command.Connection = conn;

            dsSalary = new DataSet();
            daSalary = new SqlDataAdapter();
            daSalary.SelectCommand = command;
            daSalary.Fill(dsSalary, "Sales");
            dataGridView2.DataSource = dsSalary.Tables["Sales"].DefaultView;

        }
        void BindCathegory()
        {
            string lcatcommandtext = @"SELECT [ID]
                                              ,Name [Наименование]
                                              ,Description [Описание]
                                          FROM [Cathegory]";
            SqlCommand lcatcommand = new SqlCommand(lcatcommandtext);
            lcatcommand.Connection = conn;

            cathegoryds = new DataSet();

            cathegoryda = new SqlDataAdapter();
            cathegoryda.SelectCommand = lcatcommand;

            cathegoryda.Fill(cathegoryds, "Cathegory");
            grdCathegory.DataSource = cathegoryds.Tables["Cathegory"].DefaultView;

        }

        void Bindclient()
        {
            string commandtext = @"Select ID ,[Name] [Фамилия],[LName] [Имя],Adress [Адрес] from Buyer";
            SqlCommand command = new SqlCommand(commandtext);
            command.Connection = conn;

            ds = new DataSet();
            daBuyer = new SqlDataAdapter();
            daBuyer.SelectCommand = command;
            daBuyer.Fill(ds, "Buyer");
            tovarDataGridView.DataSource = ds.Tables["Buyer"].DefaultView;
        }


        /// <summary>
        ///получение данных из таблицы поставщики 
        /// </summary>
        void producerBindData()
        {
            string commandtext = @"SELECT [ID]
                                     ,Name [Название]
                                     ,Country [Страна] 
                                     ,Description [Описание]                                  
                                 FROM [Producer]";

            SqlCommand command = new SqlCommand(commandtext);
            command = new SqlCommand(commandtext);
            command.Connection = conn;

            dsProducer = new DataSet();
            daProducer = new SqlDataAdapter();
            daProducer.SelectCommand = command;
            daProducer.Fill(dsProducer, "Producer");
            grdProducer.DataSource = dsProducer.Tables["Producer"].DefaultView;
        }

        /// <summary>
        /// вывод данных на форму из таблицы Товар
        /// </summary>
        void ProductBindData()
        {
            string commandtext = @"SELECT     Product.ID [ID]
		                                        , Product.Createddate [Дата создания] 
		                                        , Product.Garanty [Наличие гарантии]
		                                        , Product.Cost [Стоимость]
		                                        , Product.StocksQty [Количество на складе]
		                                        , Product.Name [Наименование продукта]
		                                        , Cathegory.Name [Категория]
		                                        , Producer.Name  [Производиетль]
                                                 FROM         Product 
                                                INNER JOIN
                                                 ProductProducer ON Product.ID = ProductProducer.ProductId INNER JOIN
                                                 Producer ON ProductProducer.Producerid = Producer.ID INNER JOIN
                                                 CathegoryProduct ON Product.ID = CathegoryProduct.ProductID INNER JOIN
                                                 Cathegory ON CathegoryProduct.CategoryID = Cathegory.ID";

            SqlCommand command = new SqlCommand(commandtext);
            command = new SqlCommand(commandtext);
            command.Connection = conn;

            dsProduct = new DataSet();
            daProduct = new SqlDataAdapter();
            daProduct.SelectCommand = command;
            daProduct.Fill(dsProduct, "Product");
            dataGridView1.DataSource = dsProduct.Tables["Product"].DefaultView;
        }

        #region Methods
        private void InitCatalogForm(string name)
        {
            bool find = false;
            string _name = name;

            if (this.MdiChildren.Length > 0)
            {
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Text == _name)
                    {
                        find = true;
                        f.Activate();
                        break;
                    }
                }
            }

            if (this.MdiChildren.Length == 0 || !find)
            {
                // изменить заголовок формы на name, вызвав соответствующую форму
                Form frm = new Form();
                switch (name)
                {
                    case "Клиенты":
                    case "Товары":
                    case "Заказы":
                        frm = new FormDbViewer(_name);
                        break;
                    default:
                        frm = new FormDbEditor(_name);
                        break;
                }
                frm.MdiParent = this;
                try
                {
                    frm.Show();
                }
                catch //(Exception ex)
                {
                    frm.Dispose();
                }
            }
        }

        private void ChangeUser(string usr)
        {
            // закрыть все дочерние окна
            if (this.MdiChildren.Length > 0)
            {
                foreach (Form f in this.MdiChildren)
                    f.Close();
            }

            //досступно всем
            changeUserCtrlNToolStripMenuItem.Visible = true;
            выходAltXToolStripMenuItem.Visible = true;

            //Здесь требуется настроить меню так, чтобы просмотрщик отчётов не мог видеть исходные таблицы, 
            //а администратор ни отчёты, ни таблицы
            tablesToolStripMenuItem.Visible = !usr.Equals("usrReport");
            //настройкиToolStripMenuItem.Visible = !usr.Equals("usrReport");
            switch (usr)
            {
                case "usr":
                    tablesToolStripMenuItem.Visible = true;
                    отчётыToolStripMenuItem.Visible = false;

                    //создание данных в таблицах
                    tablesToolStripMenuItem.Visible = true;
                    //данные в таблицах 
                    ProductTabControl.Visible = true;
                    //создание заказов
                    newSalaryToolStripMenuItem.Visible = true;

                    //обновить данные 
                    UpdateToolStripMenuItem.Visible = true;


                    break;
                // просмотр отчетов 
                case "usrReport":
                    отчётыToolStripMenuItem.Visible = true;

                    //создание данных в таблицах
                    tablesToolStripMenuItem.Visible = false;

                    //данные в таблицах 
                    ProductTabControl.Visible = false;

                    //создание заказов
                    newSalaryToolStripMenuItem.Visible = false;
                    //обновить данные 
                    UpdateToolStripMenuItem.Visible = false;

                    break;
                case "Admin":
                    отчётыToolStripMenuItem.Visible = true;

                    //создание данных в таблицах
                    tablesToolStripMenuItem.Visible = true;

                    //данные в таблицах 
                    ProductTabControl.Visible = true;

                    //создание заказов
                    newSalaryToolStripMenuItem.Visible = true;
                    //обновить данные 
                    UpdateToolStripMenuItem.Visible = true;
                    break;

            }
        }
        #endregion
        
        #region MenuButtons
        private void OpenForm_Click(object sender, EventArgs e)
        {
            InitCatalogForm(sender.ToString()/* ,((ToolStripMenuItem)sender).Name*/);
        }

        private void ChangeUser_Click(object sender, EventArgs e)
        {
            FormEditorProperties frm = new FormEditorProperties();
            frm.ShowDialog();

            //if (frm.DialogResult == DialogResult.OK)
            //   ChangeUser(frm.usr);
        }


        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void выходAltXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //меню сменить пользователя
        private void changeUserCtrlNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutentificationForm frm = new AutentificationForm();
            //frm.ShowDialog();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ChangeUser(frm.usr);
                // закрыть все дочерние окна
                if (this.MdiChildren.Length > 0)
                {
                    foreach (Form f in this.MdiChildren)
                        f.Close();
                }
            }
        }


        private void ProductTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // текущая активная вкладдка 
            int lcurrTab = ProductTabControl.SelectedTab.TabIndex;
        }

        /// <summary>
        /// добавление записи в таблицу клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // качестве параметров идегник по умолчанию 
            // строка подключения
            ClientEditingForm form = new ClientEditingForm(connectionString, 0);
            // form.Owner = this;
            form.Show();
        }

        /// <summary>
        /// добавление новой категории
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cathegoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CathegoryForm lform = new CathegoryForm(connectionString);
            lform.Owner = this;
            lform.Show();
        }

        /// <summary>
        /// изменение  доступности пунктов меню 
        /// </summary>
        private void changeVisible()
        {

        }

        /// <summary>
        /// обновление данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cathegoryda.Update(cathegoryds.Tables["Cathegory"]);

            producerBindData();
            Bindclient();
            BindCathegory();
            ProductBindData();
            Bindsalary();
        }

        /// <summary>
        ///  Редактирование 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdCathegory_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdCathegory_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //int row = e.RowIndex;
            //try
            //{
            //    Int32.TryParse((grdCathegory.Rows[row].Cells[0].Value).ToString(), out _currGridRow);
            //}
            //catch { }

            //// качестве параметров - строка подключения
            //CathegoryForm form = new CathegoryForm(connectionString, _currGridRow);
            //form.Owner = this;
            //form.Show();
        }

        /// <summary>
        /// создание записи в таблице производители 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void producerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProducerEditingForm lform = new ProducerEditingForm(connectionString);
            lform.Owner = this;
            lform.Show();
        }

        private void grdProducer_Leave(object sender, EventArgs e)
        {
            producerBindData();
        }

        /// <summary>
        /// выбор строки в  списке поставщиков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdProducer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            try
            {
                Int32.TryParse((grdProducer.Rows[row].Cells[0].Value).ToString(), out _currGridRow);
            }
            catch { }

            // качестве параметров - строка подключения и id редактируемой строки 
            ProducerEditingForm form = new ProducerEditingForm(connectionString, _currGridRow);
            form.Owner = this;
            form.Show();
        }

        /// <summary>
        /// создание записи в таблице товары 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductEditingform lform = new ProductEditingform(connectionString);
            lform.Owner = this;

            lform.Show();
        }


        /// <summary>
        ///  удаление товара 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdProducer_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int a = 10;
        }


        ///
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            try
            {
                Int32.TryParse((dataGridView1.Rows[row].Cells[0].Value).ToString(), out _currGridRow);
            }
            catch { }

            // качестве параметров - строка подключения и id редактируемой строки 
            ProductEditingform form = new ProductEditingform(connectionString, _currGridRow);
            form.Owner = this;
            form.Show();
        }

        private void tovarDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            try
            {
                _currGridRow = Convert.ToInt32(tovarDataGridView.Rows[row].Cells[0].Value);

                ClientEditingForm form = new ClientEditingForm(connectionString, _currGridRow);
                form.Owner = this;
                form.Show();
                if (form.DialogResult == DialogResult.OK)
                    cathegoryda.Update(cathegoryds.Tables["Cathegory"]);

            }
            catch { }
        }

        private void grdCathegory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            try
            {
                Int32.TryParse((grdCathegory.Rows[row].Cells[0].Value).ToString(), out _currGridRow);
            }
            catch { }

            // качестве параметров - строка подключения
            CathegoryForm form = new CathegoryForm(connectionString, _currGridRow);
            form.Owner = this;
            form.Show();
        }

        //отчет
        private void ежедневныйФинОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // если админ либо просмотрщик отчетов
            //if (Properties.Settings.Default.usrDB != CurrentUser)
            {
                financialReportEveryDay lform = new financialReportEveryDay(connectionString);
                lform.Owner = this;
                lform.Show();
            }
        }
        
        /// <summary>
        ///  форма только на созданрие записей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlDataReader dataReader = null;
            int id;
            string name = string.Empty;
            string country = string.Empty;
            double? cost = 0;
            int qty = 0;
            double resultCost = 0;
            DateTime date = DateTime.MinValue;
            string salesnumber = string.Empty;
            string productName = string.Empty;
            
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook newWorkbook = excelApp.Workbooks.Add();

            //лист
            Excel.Sheets excelSheets = newWorkbook.Worksheets;
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(1);

            //ячейчка
            Excel.Range excelCell;
            
            //выбранная строка
            int row = e.RowIndex;
            try
            {
                Int32.TryParse((dataGridView2.Rows[row].Cells[0].Value).ToString(), out _currGridRow);
            }
            catch { return; }

            string commandText = @"SELECT  
                                      Producer.Name
                                     , Producer.Country
                                     , Product.Cost
                                     , Sales.SalesQty
                                     , Product.Cost* Sales.SalesQty [Стоимость]
                                     , Sales.DalesDate
                                     , Sales.Number
                                     ,Product.Name
                                 FROM    Product 
                            LEFT JOIN ProductProducer ON Product.ID = ProductProducer.ProductId
                            LEFT JOIN Producer ON Producer.ID = ProductProducer.ProducerID  
                            LEFT JOIN CathegoryProduct ON Product.ID = CathegoryProduct.ProductID 
                            LEFT JOIN Cathegory ON CathegoryProduct.CategoryID = Cathegory.ID 
                            LEFT JOIN Sales ON Product.ID = Sales.ProductId  
                            LEFT JOIN Bill ON Bill.SalesId = Sales.ID
                            LEFT JOIN Buyer ON Bill.BuyerID  = Buyer.ID 
                                WHERE Sales.ID = @ID";

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = commandText;
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int);
            sqlCommand.Parameters["@ID"].Value = _currGridRow;

            try
            {
                conn.Open();
                dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    name = (string)dataReader[0].ToString();
                    country = Convert.ToString(dataReader.IsDBNull(1) ? string.Empty : dataReader[1]);
                    cost = Convert.ToDouble(dataReader.IsDBNull(2) ? 0 : dataReader[2]);
                    qty = Convert.ToInt32(dataReader.IsDBNull(3) ? 0 : dataReader[3]);
                    resultCost = Convert.ToInt32(dataReader.IsDBNull(4) ? 0 : dataReader[4]);
                    date = Convert.ToDateTime(dataReader.IsDBNull(5) ? DateTime.Now : dataReader[5]);
                    salesnumber = Convert.ToString(dataReader.IsDBNull(6) ? string.Empty : dataReader[6]);
                    productName = Convert.ToString(dataReader.IsDBNull(6) ? string.Empty : dataReader[7]);
                }

                excelCell = (Excel.Range)excelWorksheet.get_Range("A1", "A1");
                excelCell.ColumnWidth = 20;
                excelCell.Value = "Заказ";

                excelCell = (Excel.Range)excelWorksheet.get_Range("B1", "B1");
                excelCell.ColumnWidth = 25;

                excelCell.Value = salesnumber;

                //Дата 
                excelCell = (Excel.Range)excelWorksheet.get_Range("A2", "A2");
                excelCell.Value = "Дата создания";

                excelCell = (Excel.Range)excelWorksheet.get_Range("B2", "B2");
                excelCell.Value = DateTime.Now;
                
                //таблица 
                excelCell = (Excel.Range)excelWorksheet.get_Range("A5", "A5");
                excelCell.Value = "Наименование";
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("B5", "B5");
                excelCell.Value = "Производитель";
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("C5", "C5");
                excelCell.Value = "Страна";
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("D5", "D5");
                excelCell.Value = "стоимость за ед.";
                excelCell.ColumnWidth = 17;
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("E5", "E5");
                excelCell.Value = "Количество";
                excelCell.ColumnWidth = 11;
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("F5", "F5");
                excelCell.Value = "Сумма";
                excelCell.ColumnWidth = 13;
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("G5", "G5");
                excelCell.Value = "Дата изготовления ";
                excelCell.ColumnWidth = 18;
                excelCell.BorderAround(6);

                //данные 
                excelCell = (Excel.Range)excelWorksheet.get_Range("A6", "A6");
                excelCell.Value = productName;
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("B6", "B6");
                excelCell.Value = name;
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("C6", "C6");
                excelCell.Value = country;
                excelCell.BorderAround(6);
                
                excelCell = (Excel.Range)excelWorksheet.get_Range("D6", "D6");
                excelCell.Value = (cost == null ? "" : cost.ToString());
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("E6", "E6");
                excelCell.Value = qty;
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("F6", "F6");
                excelCell.Value = resultCost.ToString();
                excelCell.BorderAround(6);

                excelCell = (Excel.Range)excelWorksheet.get_Range("G6", "G6");
                if (date != DateTime.MinValue)
                {
                    excelCell.Value = date.ToShortDateString();
                }
                excelCell.BorderAround(2);
            }
            catch (SqlException ex)
            {}
            catch (Exception ex)
            {}
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                if (!dataReader.IsClosed)
                    dataReader.Close();
            }
            excelApp.Visible = true;
        }

        private void newSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesEditingForm form = new SalesEditingForm(connectionString);
            form.Owner = this;
            form.Show();
        }

        /// <summary>
        /// отчет о наиболее продаваемых продуктах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maxSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportProductMaxSalese lform = new reportProductMaxSalese(connectionString);
            lform.Show();
        }

        /// <summary>
        /// отчет - минимальное количество на складе 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimumQtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repottProductMinimum lfrom = new repottProductMinimum(connectionString);
            lfrom.Show();
        }

        private void FormARM_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shopDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.shopDataSet.Product);

        }
        /// <summary>
        /// BUTTON  TEST
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            var avtoris = rObj.Bill;

            //var query =
            //from x in avtoris
            //where x.idCount < 100
            //select new { x.idCount, x.Value, x.Name, x.State, x.Market, x.Interest };

            //dg.ItemsSource = query.ToList();

        }
    }

    internal class FormDbEditor : Form
    {
        public FormDbEditor(string name)
        {
            throw new NotImplementedException();
        }
    }

    internal class FormDbViewer : Form
    {
        public FormDbViewer(string name)
        {
            throw new NotImplementedException();
        }
    }
}
