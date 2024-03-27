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
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SearchByOrderNumber = new System.Windows.Forms.RadioButton();
            this.CustomRadioButton = new System.Windows.Forms.RadioButton();
            this.YearlyCombobox = new System.Windows.Forms.ComboBox();
            this.MonthlymonthsComboBox = new System.Windows.Forms.ComboBox();
            this.MonthlyYearComboBox = new System.Windows.Forms.ComboBox();
            this.TodayCheckBox = new System.Windows.Forms.RadioButton();
            this.MonthlyCheckBox = new System.Windows.Forms.RadioButton();
            this.YearlyCheckBox = new System.Windows.Forms.RadioButton();
            this.SalesDataGridView = new System.Windows.Forms.DataGridView();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SearchSalesTextBox = new System.Windows.Forms.TextBox();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.OpenBilling = new System.Windows.Forms.Button();
            this.PrintSalesButton = new System.Windows.Forms.Button();
            this.ClearRefreshSalesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalOrdersLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalAmountLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Controls.Add(this.SearchByOrderNumber);
            this.groupBox1.Controls.Add(this.CustomRadioButton);
            this.groupBox1.Controls.Add(this.YearlyCombobox);
            this.groupBox1.Controls.Add(this.MonthlymonthsComboBox);
            this.groupBox1.Controls.Add(this.MonthlyYearComboBox);
            this.groupBox1.Controls.Add(this.TodayCheckBox);
            this.groupBox1.Controls.Add(this.MonthlyCheckBox);
            this.groupBox1.Controls.Add(this.YearlyCheckBox);
            this.groupBox1.Controls.Add(this.SalesDataGridView);
            this.groupBox1.Controls.Add(this.DateTimePicker);
            this.groupBox1.Controls.Add(this.SearchSalesTextBox);
            this.groupBox1.Location = new System.Drawing.Point(57, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 440);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // SearchByOrderNumber
            // 
            this.SearchByOrderNumber.AutoSize = true;
            this.SearchByOrderNumber.Location = new System.Drawing.Point(26, 21);
            this.SearchByOrderNumber.Name = "SearchByOrderNumber";
            this.SearchByOrderNumber.Size = new System.Drawing.Size(148, 20);
            this.SearchByOrderNumber.TabIndex = 12;
            this.SearchByOrderNumber.TabStop = true;
            this.SearchByOrderNumber.Text = "Search By Order No";
            this.SearchByOrderNumber.UseVisualStyleBackColor = true;
            this.SearchByOrderNumber.CheckedChanged += new System.EventHandler(this.SearchByOrderNumber_CheckedChanged);
            // 
            // CustomRadioButton
            // 
            this.CustomRadioButton.AutoSize = true;
            this.CustomRadioButton.Location = new System.Drawing.Point(101, 71);
            this.CustomRadioButton.Name = "CustomRadioButton";
            this.CustomRadioButton.Size = new System.Drawing.Size(73, 20);
            this.CustomRadioButton.TabIndex = 11;
            this.CustomRadioButton.TabStop = true;
            this.CustomRadioButton.Text = "Custom";
            this.CustomRadioButton.UseVisualStyleBackColor = true;
            this.CustomRadioButton.CheckedChanged += new System.EventHandler(this.CustomRadioButton_CheckedChanged);
            // 
            // YearlyCombobox
            // 
            this.YearlyCombobox.FormattingEnabled = true;
            this.YearlyCombobox.Location = new System.Drawing.Point(530, 19);
            this.YearlyCombobox.Name = "YearlyCombobox";
            this.YearlyCombobox.Size = new System.Drawing.Size(91, 24);
            this.YearlyCombobox.TabIndex = 10;
            this.YearlyCombobox.SelectedIndexChanged += new System.EventHandler(this.YearlyCombobox_SelectedIndexChanged);
            // 
            // MonthlymonthsComboBox
            // 
            this.MonthlymonthsComboBox.FormattingEnabled = true;
            this.MonthlymonthsComboBox.Location = new System.Drawing.Point(447, 67);
            this.MonthlymonthsComboBox.Name = "MonthlymonthsComboBox";
            this.MonthlymonthsComboBox.Size = new System.Drawing.Size(77, 24);
            this.MonthlymonthsComboBox.TabIndex = 9;
            this.MonthlymonthsComboBox.SelectedIndexChanged += new System.EventHandler(this.MonthlymonthsComboBox_SelectedIndexChanged);
            // 
            // MonthlyYearComboBox
            // 
            this.MonthlyYearComboBox.FormattingEnabled = true;
            this.MonthlyYearComboBox.Location = new System.Drawing.Point(530, 67);
            this.MonthlyYearComboBox.Name = "MonthlyYearComboBox";
            this.MonthlyYearComboBox.Size = new System.Drawing.Size(90, 24);
            this.MonthlyYearComboBox.TabIndex = 8;
            this.MonthlyYearComboBox.SelectedIndexChanged += new System.EventHandler(this.MonthlyYearComboBox_SelectedIndexChanged);
            // 
            // TodayCheckBox
            // 
            this.TodayCheckBox.AutoSize = true;
            this.TodayCheckBox.Checked = true;
            this.TodayCheckBox.Location = new System.Drawing.Point(360, 20);
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
            this.MonthlyCheckBox.Location = new System.Drawing.Point(360, 71);
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
            this.YearlyCheckBox.Location = new System.Drawing.Point(447, 21);
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
            this.SalesDataGridView.Location = new System.Drawing.Point(17, 112);
            this.SalesDataGridView.MultiSelect = false;
            this.SalesDataGridView.Name = "SalesDataGridView";
            this.SalesDataGridView.ReadOnly = true;
            this.SalesDataGridView.RowHeadersVisible = false;
            this.SalesDataGridView.RowHeadersWidth = 51;
            this.SalesDataGridView.RowTemplate.Height = 24;
            this.SalesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SalesDataGridView.Size = new System.Drawing.Size(606, 312);
            this.SalesDataGridView.TabIndex = 3;
            this.SalesDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.SalesDataGridView_RowsAdded);
            this.SalesDataGridView.SelectionChanged += new System.EventHandler(this.SalesDataGridView_SelectionChanged);
            // 
            // Sno
            // 
            this.Sno.HeaderText = "S.No";
            this.Sno.MinimumWidth = 6;
            this.Sno.Name = "Sno";
            this.Sno.ReadOnly = true;
            this.Sno.Width = 50;
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker.Location = new System.Drawing.Point(191, 69);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(129, 22);
            this.DateTimePicker.TabIndex = 2;
            this.DateTimePicker.Value = new System.DateTime(2024, 3, 25, 0, 0, 0, 0);
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // SearchSalesTextBox
            // 
            this.SearchSalesTextBox.Location = new System.Drawing.Point(191, 20);
            this.SearchSalesTextBox.Name = "SearchSalesTextBox";
            this.SearchSalesTextBox.Size = new System.Drawing.Size(129, 22);
            this.SearchSalesTextBox.TabIndex = 0;
            this.SearchSalesTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(731, 54);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(462, 440);
            this.printPreviewControl1.TabIndex = 4;
            // 
            // OpenBilling
            // 
            this.OpenBilling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.OpenBilling.Location = new System.Drawing.Point(12, 12);
            this.OpenBilling.Name = "OpenBilling";
            this.OpenBilling.Size = new System.Drawing.Size(177, 36);
            this.OpenBilling.TabIndex = 5;
            this.OpenBilling.Text = "Billing";
            this.OpenBilling.UseVisualStyleBackColor = false;
            this.OpenBilling.Click += new System.EventHandler(this.OpenBilling_Click);
            // 
            // PrintSalesButton
            // 
            this.PrintSalesButton.BackColor = System.Drawing.Color.YellowGreen;
            this.PrintSalesButton.Location = new System.Drawing.Point(994, 12);
            this.PrintSalesButton.Name = "PrintSalesButton";
            this.PrintSalesButton.Size = new System.Drawing.Size(177, 36);
            this.PrintSalesButton.TabIndex = 7;
            this.PrintSalesButton.Text = "Print";
            this.PrintSalesButton.UseVisualStyleBackColor = false;
            this.PrintSalesButton.Click += new System.EventHandler(this.PrintSalesButton_Click);
            // 
            // ClearRefreshSalesButton
            // 
            this.ClearRefreshSalesButton.BackColor = System.Drawing.Color.Khaki;
            this.ClearRefreshSalesButton.Location = new System.Drawing.Point(811, 12);
            this.ClearRefreshSalesButton.Name = "ClearRefreshSalesButton";
            this.ClearRefreshSalesButton.Size = new System.Drawing.Size(177, 36);
            this.ClearRefreshSalesButton.TabIndex = 8;
            this.ClearRefreshSalesButton.Text = "Clear/Refresh";
            this.ClearRefreshSalesButton.UseVisualStyleBackColor = false;
            this.ClearRefreshSalesButton.Click += new System.EventHandler(this.ClearRefreshSalesButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 12);
            this.label1.MinimumSize = new System.Drawing.Size(150, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Orders:";
            // 
            // TotalOrdersLabel
            // 
            this.TotalOrdersLabel.AutoSize = true;
            this.TotalOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalOrdersLabel.Location = new System.Drawing.Point(383, 13);
            this.TotalOrdersLabel.MinimumSize = new System.Drawing.Size(100, 0);
            this.TotalOrdersLabel.Name = "TotalOrdersLabel";
            this.TotalOrdersLabel.Size = new System.Drawing.Size(100, 29);
            this.TotalOrdersLabel.TabIndex = 10;
            this.TotalOrdersLabel.Text = "----";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(532, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "Amount:";
            // 
            // TotalAmountLabel
            // 
            this.TotalAmountLabel.AutoSize = true;
            this.TotalAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAmountLabel.Location = new System.Drawing.Point(646, 13);
            this.TotalAmountLabel.MinimumSize = new System.Drawing.Size(100, 0);
            this.TotalAmountLabel.Name = "TotalAmountLabel";
            this.TotalAmountLabel.Size = new System.Drawing.Size(100, 29);
            this.TotalAmountLabel.TabIndex = 12;
            this.TotalAmountLabel.Text = "----";
            // 
            // Sale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1233, 520);
            this.Controls.Add(this.TotalAmountLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TotalOrdersLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearRefreshSalesButton);
            this.Controls.Add(this.PrintSalesButton);
            this.Controls.Add(this.OpenBilling);
            this.Controls.Add(this.printPreviewControl1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Sale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale";
            this.Load += new System.EventHandler(this.Sale_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.TextBox SearchSalesTextBox;
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
        private System.Windows.Forms.RadioButton CustomRadioButton;
        private System.Windows.Forms.RadioButton SearchByOrderNumber;
        private System.Windows.Forms.Button PrintSalesButton;
        private System.Windows.Forms.Button ClearRefreshSalesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TotalOrdersLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TotalAmountLabel;
    }
}