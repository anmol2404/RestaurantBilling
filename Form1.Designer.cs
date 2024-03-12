namespace WindowsFormsApp1
{
    partial class AddUpdateForm
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
            this.ItemNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddNewButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.AddUpdateGroupBox = new System.Windows.Forms.GroupBox();
            this.Clearbutton = new System.Windows.Forms.Button();
            this.FullPlatePriceTextBox = new System.Windows.Forms.TextBox();
            this.HalfPlatePriceTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ItemIDLabel = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SearchGroupBox = new System.Windows.Forms.GroupBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AddUpdateDatagrid = new System.Windows.Forms.DataGridView();
            this.BillingButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.AddUpdateGroupBox.SuspendLayout();
            this.SearchGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpdateDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemNameTextBox
            // 
            this.ItemNameTextBox.Location = new System.Drawing.Point(118, 43);
            this.ItemNameTextBox.Name = "ItemNameTextBox";
            this.ItemNameTextBox.Size = new System.Drawing.Size(122, 20);
            this.ItemNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Half plate Price";
            // 
            // AddNewButton
            // 
            this.AddNewButton.BackColor = System.Drawing.Color.PaleGreen;
            this.AddNewButton.Location = new System.Drawing.Point(23, 200);
            this.AddNewButton.Name = "AddNewButton";
            this.AddNewButton.Size = new System.Drawing.Size(123, 59);
            this.AddNewButton.TabIndex = 3;
            this.AddNewButton.Text = "ADD NEW";
            this.AddNewButton.UseVisualStyleBackColor = false;
            this.AddNewButton.Click += new System.EventHandler(this.AddNewButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.Gold;
            this.UpdateButton.Location = new System.Drawing.Point(169, 200);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(123, 59);
            this.UpdateButton.TabIndex = 4;
            this.UpdateButton.Text = "UPDATE";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // AddUpdateGroupBox
            // 
            this.AddUpdateGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.AddUpdateGroupBox.Controls.Add(this.Clearbutton);
            this.AddUpdateGroupBox.Controls.Add(this.FullPlatePriceTextBox);
            this.AddUpdateGroupBox.Controls.Add(this.HalfPlatePriceTextBox);
            this.AddUpdateGroupBox.Controls.Add(this.label5);
            this.AddUpdateGroupBox.Controls.Add(this.ItemIDLabel);
            this.AddUpdateGroupBox.Controls.Add(this.label1);
            this.AddUpdateGroupBox.Controls.Add(this.UpdateButton);
            this.AddUpdateGroupBox.Controls.Add(this.ItemNameTextBox);
            this.AddUpdateGroupBox.Controls.Add(this.AddNewButton);
            this.AddUpdateGroupBox.Controls.Add(this.label2);
            this.AddUpdateGroupBox.Location = new System.Drawing.Point(478, 39);
            this.AddUpdateGroupBox.Name = "AddUpdateGroupBox";
            this.AddUpdateGroupBox.Size = new System.Drawing.Size(332, 390);
            this.AddUpdateGroupBox.TabIndex = 6;
            this.AddUpdateGroupBox.TabStop = false;
            // 
            // Clearbutton
            // 
            this.Clearbutton.BackColor = System.Drawing.Color.Silver;
            this.Clearbutton.Location = new System.Drawing.Point(23, 275);
            this.Clearbutton.Name = "Clearbutton";
            this.Clearbutton.Size = new System.Drawing.Size(123, 59);
            this.Clearbutton.TabIndex = 11;
            this.Clearbutton.Text = "Clear / Refresh";
            this.Clearbutton.UseVisualStyleBackColor = false;
            this.Clearbutton.Click += new System.EventHandler(this.Clearbutton_Click);
            // 
            // FullPlatePriceTextBox
            // 
            this.FullPlatePriceTextBox.Location = new System.Drawing.Point(118, 138);
            this.FullPlatePriceTextBox.Name = "FullPlatePriceTextBox";
            this.FullPlatePriceTextBox.Size = new System.Drawing.Size(122, 20);
            this.FullPlatePriceTextBox.TabIndex = 2;
            // 
            // HalfPlatePriceTextBox
            // 
            this.HalfPlatePriceTextBox.Location = new System.Drawing.Point(118, 92);
            this.HalfPlatePriceTextBox.Name = "HalfPlatePriceTextBox";
            this.HalfPlatePriceTextBox.Size = new System.Drawing.Size(122, 20);
            this.HalfPlatePriceTextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Full plate Price";
            // 
            // ItemIDLabel
            // 
            this.ItemIDLabel.AutoSize = true;
            this.ItemIDLabel.Location = new System.Drawing.Point(275, 16);
            this.ItemIDLabel.Name = "ItemIDLabel";
            this.ItemIDLabel.Size = new System.Drawing.Size(21, 13);
            this.ItemIDLabel.TabIndex = 7;
            this.ItemIDLabel.Text = "ID:";
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.Orange;
            this.EditButton.Location = new System.Drawing.Point(6, 356);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(203, 28);
            this.EditButton.TabIndex = 8;
            this.EditButton.Text = "EDIT";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Tomato;
            this.DeleteButton.Location = new System.Drawing.Point(229, 356);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(203, 28);
            this.DeleteButton.TabIndex = 9;
            this.DeleteButton.Text = "DELETE";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SearchGroupBox
            // 
            this.SearchGroupBox.Controls.Add(this.DeleteButton);
            this.SearchGroupBox.Controls.Add(this.EditButton);
            this.SearchGroupBox.Controls.Add(this.SearchTextBox);
            this.SearchGroupBox.Controls.Add(this.label4);
            this.SearchGroupBox.Controls.Add(this.AddUpdateDatagrid);
            this.SearchGroupBox.Location = new System.Drawing.Point(12, 39);
            this.SearchGroupBox.Name = "SearchGroupBox";
            this.SearchGroupBox.Size = new System.Drawing.Size(438, 390);
            this.SearchGroupBox.TabIndex = 7;
            this.SearchGroupBox.TabStop = false;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.SearchTextBox.Location = new System.Drawing.Point(132, 23);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(245, 20);
            this.SearchTextBox.TabIndex = 4;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Search";
            // 
            // AddUpdateDatagrid
            // 
            this.AddUpdateDatagrid.AllowUserToAddRows = false;
            this.AddUpdateDatagrid.AllowUserToDeleteRows = false;
            this.AddUpdateDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AddUpdateDatagrid.Location = new System.Drawing.Point(6, 61);
            this.AddUpdateDatagrid.Name = "AddUpdateDatagrid";
            this.AddUpdateDatagrid.ReadOnly = true;
            this.AddUpdateDatagrid.RowHeadersVisible = false;
            this.AddUpdateDatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AddUpdateDatagrid.Size = new System.Drawing.Size(426, 289);
            this.AddUpdateDatagrid.TabIndex = 0;
            // 
            // BillingButton
            // 
            this.BillingButton.BackColor = System.Drawing.Color.Goldenrod;
            this.BillingButton.Location = new System.Drawing.Point(112, 10);
            this.BillingButton.Name = "BillingButton";
            this.BillingButton.Size = new System.Drawing.Size(185, 23);
            this.BillingButton.TabIndex = 8;
            this.BillingButton.Text = "Billing";
            this.BillingButton.UseVisualStyleBackColor = false;
            this.BillingButton.Click += new System.EventHandler(this.BillingButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(358, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(735, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // AddUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(822, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BillingButton);
            this.Controls.Add(this.SearchGroupBox);
            this.Controls.Add(this.AddUpdateGroupBox);
            this.MaximizeBox = false;
            this.Name = "AddUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update";
            this.Load += new System.EventHandler(this.AddUpdateForm_Load);
            this.AddUpdateGroupBox.ResumeLayout(false);
            this.AddUpdateGroupBox.PerformLayout();
            this.SearchGroupBox.ResumeLayout(false);
            this.SearchGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpdateDatagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddNewButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.GroupBox AddUpdateGroupBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label ItemIDLabel;
        private System.Windows.Forms.GroupBox SearchGroupBox;
        private System.Windows.Forms.DataGridView AddUpdateDatagrid;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FullPlatePriceTextBox;
        private System.Windows.Forms.TextBox HalfPlatePriceTextBox;
        private System.Windows.Forms.Button Clearbutton;
        private System.Windows.Forms.Button BillingButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

