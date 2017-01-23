namespace WinArc
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.buttonCreate = new System.Windows.Forms.Button();
			this.buttonExtract = new System.Windows.Forms.Button();
			this.buttonHelp = new System.Windows.Forms.Button();
			this.buttonExit = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.HotTracking = true;
			this.treeView1.Location = new System.Drawing.Point(12, 94);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(250, 441);
			this.treeView1.TabIndex = 3;
			this.treeView1.TabStop = false;
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 541);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(250, 23);
			this.progressBar1.TabIndex = 3;
			// 
			// buttonCreate
			// 
			this.buttonCreate.Location = new System.Drawing.Point(12, 12);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(55, 50);
			this.buttonCreate.TabIndex = 1;
			this.buttonCreate.Text = "Create";
			this.buttonCreate.UseVisualStyleBackColor = true;
			this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
			// 
			// buttonExtract
			// 
			this.buttonExtract.Location = new System.Drawing.Point(134, 12);
			this.buttonExtract.Name = "buttonExtract";
			this.buttonExtract.Size = new System.Drawing.Size(55, 50);
			this.buttonExtract.TabIndex = 2;
			this.buttonExtract.Text = "Extract";
			this.buttonExtract.UseVisualStyleBackColor = true;
			this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
			// 
			// buttonHelp
			// 
			this.buttonHelp.Location = new System.Drawing.Point(655, 12);
			this.buttonHelp.Name = "buttonHelp";
			this.buttonHelp.Size = new System.Drawing.Size(55, 50);
			this.buttonHelp.TabIndex = 3;
			this.buttonHelp.Text = "Help";
			this.buttonHelp.UseVisualStyleBackColor = true;
			// 
			// buttonExit
			// 
			this.buttonExit.Location = new System.Drawing.Point(716, 12);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(55, 50);
			this.buttonExit.TabIndex = 4;
			this.buttonExit.Text = "Exit";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(271, 94);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(500, 470);
			this.listView1.TabIndex = 3;
			this.listView1.TabStop = false;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.Click += new System.EventHandler(this.listView1_Click);
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 132;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			this.columnHeader2.Width = 111;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Date modified";
			this.columnHeader3.Width = 102;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Size";
			this.columnHeader4.Width = 291;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 68);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(759, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Location = new System.Drawing.Point(195, 12);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(55, 50);
			this.buttonRefresh.TabIndex = 5;
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(73, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(55, 50);
			this.button1.TabIndex = 6;
			this.button1.Text = "With Password";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(780, 576);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.buttonCreate);
			this.Controls.Add(this.buttonExtract);
			this.Controls.Add(this.buttonExit);
			this.Controls.Add(this.buttonHelp);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 614);
			this.Name = "Form1";
			this.Text = "WinArc";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
			this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button button1;
	}
}

