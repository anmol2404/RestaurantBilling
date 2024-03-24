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
            this.SalesDataGridView = new System.Windows.Forms.DataGridView();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.TodayCheckBox = new System.Windows.Forms.RadioButton();
            this.MonthlyCheckBox = new System.Windows.Forms.RadioButton();
            this.YearlyCheckBox = new System.Windows.Forms.RadioButton();
            this.OpenBilling = new System.Windows.Forms.Button();
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
            // SalesDataGridView
            // 
            this.SalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SalesDataGridView.Location = new System.Drawing.Point(17, 129);
            this.SalesDataGridView.Name = "SalesDataGridView";
            this.SalesDataGridView.RowHeadersVisible = false;
            this.SalesDataGridView.RowHeadersWidth = 51;
            this.SalesDataGridView.RowTemplate.Height = 24;
            this.SalesDataGridView.Size = new System.Drawing.Size(492, 295);
            this.SalesDataGridView.TabIndex = 3;
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker.Location = new System.Drawing.Point(369, 36);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(140, 22);
            this.DateTimePicker.TabIndex = 2;
            this.DateTimePicker.Value = new System.DateTime(2024, 3, 24, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(143, 35);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(173, 22);
            this.SearchTextBox.TabIndex = 0;
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(624, 54);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(462, 440);
            this.printPreviewControl1.TabIndex = 4;
            // 
            // TodayCheckBox
            // 
            this.TodayCheckBox.AutoSize = true;
            this.TodayCheckBox.Checked = true;
            this.TodayCheckBox.Location = new System.Drawing.Point(57, 84);
            this.TodayCheckBox.Name = "TodayCheckBox";
            this.TodayCheckBox.Size = new System.Drawing.Size(85, 25);
            this.TodayCheckBox.TabIndex = 5;
            this.TodayCheckBox.TabStop = true;
            this.TodayCheckBox.Text = "Today";
            this.TodayCheckBox.UseVisualStyleBackColor = true;
            this.TodayCheckBox.EnabledChanged += new System.EventHandler(this.TodayCheckBox_EnabledChanged);
            // 
            // MonthlyCheckBox
            // 
            this.MonthlyCheckBox.AutoSize = true;
            this.MonthlyCheckBox.Location = new System.Drawing.Point(213, 84);
            this.MonthlyCheckBox.Name = "MonthlyCheckBox";
            this.MonthlyCheckBox.Size = new System.Drawing.Size(93, 25);
            this.MonthlyCheckBox.TabIndex = 6;
            this.MonthlyCheckBox.Text = "Monthly";
            this.MonthlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // YearlyCheckBox
            // 
            this.YearlyCheckBox.AutoSize = true;
            this.YearlyCheckBox.Location = new System.Drawing.Point(369, 84);
            this.YearlyCheckBox.Name = "YearlyCheckBox";
            this.YearlyCheckBox.Size = new System.Drawing.Size(84, 25);
            this.YearlyCheckBox.TabIndex = 7;
            this.YearlyCheckBox.Text = "Yearly";
            this.YearlyCheckBox.UseVisualStyleBackColor = true;
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
    }
}