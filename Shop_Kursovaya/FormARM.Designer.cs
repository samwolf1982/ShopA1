namespace Shop_Kursovaya
{
    partial class FormARM
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormARM));
            this.ProductTabControl = new System.Windows.Forms.TabControl();
            this.ClientTabPage = new System.Windows.Forms.TabPage();
            this.tovarDataGridView = new System.Windows.Forms.DataGridView();
            this.ProductTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductGridView = new System.Windows.Forms.DataGridView();
            this.OrdersTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cathegoryPage = new System.Windows.Forms.TabPage();
            this.grdCathegory = new System.Windows.Forms.DataGridView();
            this.producertabPage = new System.Windows.Forms.TabPage();
            this.grdProducer = new System.Windows.Forms.DataGridView();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shopDataSet = new Shop_Kursovaya.shopDataSet();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUserCtrlNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходAltXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cathegoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.producerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.report1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimumQtyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgramCtrlIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSet1 = new System.Data.DataSet();
            this.dataSet2 = new System.Data.DataSet();
            this.productTableAdapter = new Shop_Kursovaya.shopDataSetTableAdapters.ProductTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.ProductTabControl.SuspendLayout();
            this.ClientTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tovarDataGridView)).BeginInit();
            this.ProductTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGridView)).BeginInit();
            this.OrdersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.cathegoryPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCathegory)).BeginInit();
            this.producertabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductTabControl
            // 
            this.ProductTabControl.Controls.Add(this.ClientTabPage);
            this.ProductTabControl.Controls.Add(this.ProductTabPage);
            this.ProductTabControl.Controls.Add(this.OrdersTabPage);
            this.ProductTabControl.Controls.Add(this.cathegoryPage);
            this.ProductTabControl.Controls.Add(this.producertabPage);
            this.ProductTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductTabControl.Location = new System.Drawing.Point(0, 24);
            this.ProductTabControl.Name = "ProductTabControl";
            this.ProductTabControl.SelectedIndex = 0;
            this.ProductTabControl.Size = new System.Drawing.Size(1111, 491);
            this.ProductTabControl.TabIndex = 3;
            this.ProductTabControl.SelectedIndexChanged += new System.EventHandler(this.ProductTabControl_SelectedIndexChanged);
            // 
            // ClientTabPage
            // 
            this.ClientTabPage.Controls.Add(this.tovarDataGridView);
            this.ClientTabPage.Location = new System.Drawing.Point(4, 22);
            this.ClientTabPage.Name = "ClientTabPage";
            this.ClientTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ClientTabPage.Size = new System.Drawing.Size(1103, 465);
            this.ClientTabPage.TabIndex = 0;
            this.ClientTabPage.Text = "Покупатели";
            this.ClientTabPage.UseVisualStyleBackColor = true;
            // 
            // tovarDataGridView
            // 
            this.tovarDataGridView.AllowUserToAddRows = false;
            this.tovarDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tovarDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tovarDataGridView.Location = new System.Drawing.Point(3, 3);
            this.tovarDataGridView.Name = "tovarDataGridView";
            this.tovarDataGridView.ReadOnly = true;
            this.tovarDataGridView.Size = new System.Drawing.Size(1097, 459);
            this.tovarDataGridView.TabIndex = 0;
            this.tovarDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tovarDataGridView_CellDoubleClick);
            // 
            // ProductTabPage
            // 
            this.ProductTabPage.Controls.Add(this.dataGridView1);
            this.ProductTabPage.Controls.Add(this.ProductGridView);
            this.ProductTabPage.Location = new System.Drawing.Point(4, 22);
            this.ProductTabPage.Name = "ProductTabPage";
            this.ProductTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProductTabPage.Size = new System.Drawing.Size(1103, 465);
            this.ProductTabPage.TabIndex = 1;
            this.ProductTabPage.Text = "Товары";
            this.ProductTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1097, 459);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ProductGridView
            // 
            this.ProductGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductGridView.Location = new System.Drawing.Point(3, 3);
            this.ProductGridView.Name = "ProductGridView";
            this.ProductGridView.Size = new System.Drawing.Size(1097, 459);
            this.ProductGridView.TabIndex = 0;
            // 
            // OrdersTabPage
            // 
            this.OrdersTabPage.Controls.Add(this.dataGridView2);
            this.OrdersTabPage.Location = new System.Drawing.Point(4, 22);
            this.OrdersTabPage.Name = "OrdersTabPage";
            this.OrdersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OrdersTabPage.Size = new System.Drawing.Size(1103, 465);
            this.OrdersTabPage.TabIndex = 2;
            this.OrdersTabPage.Text = "Заказы";
            this.OrdersTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1097, 459);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // cathegoryPage
            // 
            this.cathegoryPage.Controls.Add(this.grdCathegory);
            this.cathegoryPage.Location = new System.Drawing.Point(4, 22);
            this.cathegoryPage.Name = "cathegoryPage";
            this.cathegoryPage.Padding = new System.Windows.Forms.Padding(3);
            this.cathegoryPage.Size = new System.Drawing.Size(1103, 465);
            this.cathegoryPage.TabIndex = 3;
            this.cathegoryPage.Text = "Категории";
            this.cathegoryPage.UseVisualStyleBackColor = true;
            // 
            // grdCathegory
            // 
            this.grdCathegory.AllowUserToAddRows = false;
            this.grdCathegory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCathegory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCathegory.Location = new System.Drawing.Point(3, 3);
            this.grdCathegory.Name = "grdCathegory";
            this.grdCathegory.ReadOnly = true;
            this.grdCathegory.Size = new System.Drawing.Size(1097, 459);
            this.grdCathegory.TabIndex = 0;
            this.grdCathegory.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCathegory_CellContentDoubleClick);
            this.grdCathegory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCathegory_CellDoubleClick);
            // 
            // producertabPage
            // 
            this.producertabPage.Controls.Add(this.grdProducer);
            this.producertabPage.Location = new System.Drawing.Point(4, 22);
            this.producertabPage.Name = "producertabPage";
            this.producertabPage.Padding = new System.Windows.Forms.Padding(3);
            this.producertabPage.Size = new System.Drawing.Size(1103, 465);
            this.producertabPage.TabIndex = 4;
            this.producertabPage.Text = "Производитель";
            this.producertabPage.UseVisualStyleBackColor = true;
            // 
            // grdProducer
            // 
            this.grdProducer.AllowUserToAddRows = false;
            this.grdProducer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProducer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProducer.Location = new System.Drawing.Point(3, 3);
            this.grdProducer.Name = "grdProducer";
            this.grdProducer.ReadOnly = true;
            this.grdProducer.Size = new System.Drawing.Size(1097, 459);
            this.grdProducer.TabIndex = 0;
            this.grdProducer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProducer_CellDoubleClick);
            this.grdProducer.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdProducer_UserDeletingRow);
            this.grdProducer.Leave += new System.EventHandler(this.grdProducer_Leave);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.shopDataSet;
            // 
            // shopDataSet
            // 
            this.shopDataSet.DataSetName = "shopDataSet";
            this.shopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.tablesToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1111, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSalaryToolStripMenuItem,
            this.UpdateToolStripMenuItem,
            this.changeUserCtrlNToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходAltXToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // newSalaryToolStripMenuItem
            // 
            this.newSalaryToolStripMenuItem.Name = "newSalaryToolStripMenuItem";
            this.newSalaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.newSalaryToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.newSalaryToolStripMenuItem.Text = "Создать Заказ";
            this.newSalaryToolStripMenuItem.Click += new System.EventHandler(this.newSalaryToolStripMenuItem_Click);
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.UpdateToolStripMenuItem.Text = "Обновить";
            this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // changeUserCtrlNToolStripMenuItem
            // 
            this.changeUserCtrlNToolStripMenuItem.DoubleClickEnabled = true;
            this.changeUserCtrlNToolStripMenuItem.Name = "changeUserCtrlNToolStripMenuItem";
            this.changeUserCtrlNToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.changeUserCtrlNToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.changeUserCtrlNToolStripMenuItem.Text = "Сменить пользователя";
            this.changeUserCtrlNToolStripMenuItem.Click += new System.EventHandler(this.changeUserCtrlNToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(257, 6);
            // 
            // выходAltXToolStripMenuItem
            // 
            this.выходAltXToolStripMenuItem.Name = "выходAltXToolStripMenuItem";
            this.выходAltXToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.выходAltXToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.выходAltXToolStripMenuItem.Text = "Выход ";
            this.выходAltXToolStripMenuItem.Click += new System.EventHandler(this.выходAltXToolStripMenuItem_Click);
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.cathegoryToolStripMenuItem,
            this.producerToolStripMenuItem});
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.tablesToolStripMenuItem.Text = "Таблицы";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.productToolStripMenuItem.Text = "Товары";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // cathegoryToolStripMenuItem
            // 
            this.cathegoryToolStripMenuItem.Name = "cathegoryToolStripMenuItem";
            this.cathegoryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.cathegoryToolStripMenuItem.Text = "Категория";
            this.cathegoryToolStripMenuItem.Click += new System.EventHandler(this.cathegoryToolStripMenuItem_Click);
            // 
            // producerToolStripMenuItem
            // 
            this.producerToolStripMenuItem.Name = "producerToolStripMenuItem";
            this.producerToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.producerToolStripMenuItem.Text = "Производитель";
            this.producerToolStripMenuItem.Click += new System.EventHandler(this.producerToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.report1ToolStripMenuItem,
            this.maxSalesToolStripMenuItem,
            this.minimumQtyToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // report1ToolStripMenuItem
            // 
            this.report1ToolStripMenuItem.Name = "report1ToolStripMenuItem";
            this.report1ToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.report1ToolStripMenuItem.Text = "Ежедневный фин отчет";
            this.report1ToolStripMenuItem.Click += new System.EventHandler(this.ежедневныйФинОтчетToolStripMenuItem_Click);
            // 
            // maxSalesToolStripMenuItem
            // 
            this.maxSalesToolStripMenuItem.Name = "maxSalesToolStripMenuItem";
            this.maxSalesToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.maxSalesToolStripMenuItem.Text = "Наиболее продаваемые продукты";
            this.maxSalesToolStripMenuItem.Click += new System.EventHandler(this.maxSalesToolStripMenuItem_Click);
            // 
            // minimumQtyToolStripMenuItem
            // 
            this.minimumQtyToolStripMenuItem.Name = "minimumQtyToolStripMenuItem";
            this.minimumQtyToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.minimumQtyToolStripMenuItem.Text = "Наименьшее количество на складе ";
            this.minimumQtyToolStripMenuItem.Click += new System.EventHandler(this.minimumQtyToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userGuideToolStripMenuItem,
            this.AboutProgramCtrlIToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // userGuideToolStripMenuItem
            // 
            this.userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            this.userGuideToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.userGuideToolStripMenuItem.Text = "Руководство пользователя ";
            // 
            // AboutProgramCtrlIToolStripMenuItem
            // 
            this.AboutProgramCtrlIToolStripMenuItem.Name = "AboutProgramCtrlIToolStripMenuItem";
            this.AboutProgramCtrlIToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.AboutProgramCtrlIToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.AboutProgramCtrlIToolStripMenuItem.Text = "О программе";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "dataSet2";
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormARM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 515);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ProductTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormARM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Продажи";
            this.Load += new System.EventHandler(this.FormARM_Load);
            this.ProductTabControl.ResumeLayout(false);
            this.ClientTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tovarDataGridView)).EndInit();
            this.ProductTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGridView)).EndInit();
            this.OrdersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.cathegoryPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCathegory)).EndInit();
            this.producertabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProducer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl ProductTabControl;
        private System.Windows.Forms.TabPage ClientTabPage;
        private System.Windows.Forms.TabPage ProductTabPage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeUserCtrlNToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходAltXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutProgramCtrlIToolStripMenuItem;
        private System.Windows.Forms.DataGridView tovarDataGridView;
        private System.Windows.Forms.DataGridView ProductGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataSet dataSet2;
        private System.Windows.Forms.TabPage OrdersTabPage;
        private System.Windows.Forms.ToolStripMenuItem cathegoryToolStripMenuItem;
        private System.Windows.Forms.TabPage cathegoryPage;
        private System.Windows.Forms.DataGridView grdCathegory;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem producerToolStripMenuItem;
        private System.Windows.Forms.TabPage producertabPage;
        private System.Windows.Forms.DataGridView grdProducer;
        private System.Windows.Forms.ToolStripMenuItem report1ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStripMenuItem newSalaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimumQtyToolStripMenuItem;
        private shopDataSet shopDataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private shopDataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.Button button1;

    }
}

