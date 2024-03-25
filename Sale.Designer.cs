namespace WindowsFormsApp1
{
    partial class Sale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sale));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TodayCheckBox = new System.Windows.Forms.RadioButton();
            this.MonthlyCheckBox = new System.Windows.Forms.RadioButton();
            this.YearlyCheckBox = new System.Windows.Forms.RadioButton();
            this.SalesDataGridView = new System.Windows.Forms.DataGridView();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.OpenBilling = new System.Windows.Forms.Button();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthlyYearComboBox = new System.Windows.Forms.ComboBox();
            this.MonthlymonthsComboBox = new System.Windows.Forms.ComboBox();
            this.YearlyCombobox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.YearlyCombobox);
            this.groupBox1.Controls.Add(this.MonthlymonthsComboBox);
            this.groupBox1.Controls.Add(this.MonthlyYearComboBox);
            this.groupBox1.Controls.Add(this.TodayCheckBox);
            this.groupBox1.Controls.Add(this.MonthlyCheckBox);
            this.groupBox1.Controls.Add(this.YearlyCheckBox);
            this.groupBox1.Controls.Add(this.SalesDataGridView);
            this.groupBox1.Controls.Add(this.DateTimePicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SearchTextBox);
            this.groupBox1.Location = new System.Drawing.Point(57, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 440);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TodayCheckBox
            // 
            this.TodayCheckBox.AutoSize = true;
            this.TodayCheckBox.Checked = true;
            this.TodayCheckBox.Location = new System.Drawing.Point(336, 18);
            this.TodayCheckBox.Name = "TodayCheckBox";
            this.TodayCheckBox.Size = new System.Drawing.Size(68, 20);
            this.TodayCheckBox.TabIndex = 5;
            this.TodayCheckBox.TabStop = true;
            this.TodayCheckBox.Text = "Today";
            this.TodayCheckBox.UseVisualStyleBackColor = true;
            this.TodayCheckBox.CheckedChanged += new System.EventHandler(this.TodayCheckBox_CheckedChanged);
            // 
            // MonthlyCheckBox
            // 
            this.MonthlyCheckBox.AutoSize = true;
            this.MonthlyCheckBox.Location = new System.Drawing.Point(249, 56);
            this.MonthlyCheckBox.Name = "MonthlyCheckBox";
            this.MonthlyCheckBox.Size = new System.Drawing.Size(74, 20);
            this.MonthlyCheckBox.TabIndex = 6;
            this.MonthlyCheckBox.Text = "Monthly";
            this.MonthlyCheckBox.UseVisualStyleBackColor = true;
            this.MonthlyCheckBox.CheckedChanged += new System.EventHandler(this.MonthlyCheckBox_CheckedChanged);
            // 
            // YearlyCheckBox
            // 
            this.YearlyCheckBox.AutoSize = true;
            this.YearlyCheckBox.Location = new System.Drawing.Point(249, 92);
            this.YearlyCheckBox.Name = "YearlyCheckBox";
            this.YearlyCheckBox.Size = new System.Drawing.Size(67, 20);
            this.YearlyCheckBox.TabIndex = 7;
            this.YearlyCheckBox.Text = "Yearly";
            this.YearlyCheckBox.UseVisualStyleBackColor = true;
            this.YearlyCheckBox.CheckedChanged += new System.EventHandler(this.YearlyCheckBox_CheckedChanged);
            // 
            // SalesDataGridView
            // 
            this.SalesDataGridView.AllowUserToAddRows = false;
            this.SalesDataGridView.AllowUserToDeleteRows = false;
            this.SalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SalesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sno});
            this.SalesDataGridView.Location = new System.Drawing.Point(17, 129);
            this.SalesDataGridView.MultiSelect = false;
            this.SalesDataGridView.Name = "SalesDataGridView";
            this.SalesDataGridView.ReadOnly = true;
            this.SalesDataGridView.RowHeadersVisible = false;
            this.SalesDataGridView.RowHeadersWidth = 51;
            this.SalesDataGridView.RowTemplate.Height = 24;
            this.SalesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SalesDataGridView.Size = new System.Drawing.Size(492, 295);
            this.SalesDataGridView.TabIndex = 3;
            this.SalesDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.SalesDataGridView_RowsAdded);
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker.Location = new System.Drawing.Point(79, 56);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(129, 22);
            this.DateTimePicker.TabIndex = 2;
            this.DateTimePicker.Value = new System.DateTime(2024, 3, 25, 0, 0, 0, 0);
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(79, 15);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(207, 22);
            this.SearchTextBox.TabIndex = 0;
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(624, 54);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(462, 440);
            this.printPreviewControl1.TabIndex = 4;
            // 
            // OpenBilling
            // 
            this.OpenBilling.Location = new System.Drawing.Point(873, 12);
            this.OpenBilling.Name = "OpenBilling";
            this.OpenBilling.Size = new System.Drawing.Size(177, 23);
            this.OpenBilling.TabIndex = 5;
            this.OpenBilling.Text = "Billing";
            this.OpenBilling.UseVisualStyleBackColor = true;
            this.OpenBilling.Click += new System.EventHandler(this.OpenBilling_Click);
            // 
            // Sno
            // 
            this.Sno.HeaderText = "S.No";
            this.Sno.MinimumWidth = 6;
            this.Sno.Name = "Sno";
            this.Sno.ReadOnly = true;
            this.Sno.Width = 50;
            // 
            // MonthlyYearComboBox
            // 
            this.MonthlyYearComboBox.FormattingEnabled = true;
            this.MonthlyYearComboBox.Location = new System.Drawing.Point(419, 52);
            this.MonthlyYearComboBox.Name = "MonthlyYearComboBox";
            this.MonthlyYearComboBox.Size = new System.Drawing.Size(90, 24);
            this.MonthlyYearComboBox.TabIndex = 8;
            this.MonthlyYearComboBox.SelectedIndexChanged += new System.EventHandler(this.MonthlyYearComboBox_SelectedIndexChanged);
            // 
            // MonthlymonthsComboBox
            // 
            this.MonthlymonthsComboBox.FormattingEnabled = true;
            this.MonthlymonthsComboBox.Location = new System.Drawing.Point(336, 52);
            this.MonthlymonthsComboBox.Name = "MonthlymonthsComboBox";
            this.MonthlymonthsComboBox.Size = new System.Drawing.Size(77, 24);
            this.MonthlymonthsComboBox.TabIndex = 9;
            this.MonthlymonthsComboBox.SelectedIndexChanged += new System.EventHandler(this.MonthlymonthsComboBox_SelectedIndexChanged);
            // 
            // YearlyCombobox
            // 
            this.YearlyCombobox.FormattingEnabled = true;
            this.YearlyCombobox.Location = new System.Drawing.Point(336, 92);
            this.YearlyCombobox.Name = "YearlyCombobox";
            this.YearlyCombobox.Size = new System.Drawing.Size(77, 24);
            this.YearlyCombobox.TabIndex = 10;
            this.YearlyCombobox.SelectedIndexChanged += new System.EventHandler(this.YearlyCombobox_SelectedIndexChanged);
            // 
            // Sale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 520);
            this.Controls.Add(this.OpenBilling);
            this.Controls.Add(this.printPreviewControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Sale";
            this.Text = "Sale";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.DataGridView SalesDataGridView;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.RadioButton TodayCheckBox;
        private System.Windows.Forms.RadioButton MonthlyCheckBox;
        private System.Windows.Forms.RadioButton YearlyCheckBox;
        private System.Windows.Forms.Button OpenBilling;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
        private System.Windows.Forms.ComboBox YearlyCombobox;
        private System.Windows.Forms.ComboBox MonthlymonthsComboBox;
        private System.Windows.Forms.ComboBox MonthlyYearComboBox;
    }
}