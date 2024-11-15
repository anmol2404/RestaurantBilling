﻿using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class Billing : Form
    {
        private dbclass dbclass;

        private int itemID;
        private string Itemname;
        private int hprice;
        private int fprice;

        private int table2itemID;
        private string table2Itemname;
        private int table2hprice;
        private int table2fprice;

        private int table3itemID;
        private string table3Itemname;
        private int table3hprice;
        private int table3fprice;

        private int table4itemID;
        private string table4Itemname;
        private int table4hprice;
        private int table4fprice;

        private int table5itemID;
        private string table5Itemname;
        private int table5hprice;
        private int table5fprice;

        private int table6itemID;
        private string table6Itemname;
        private int table6hprice;
        private int table6fprice;

        private int table7itemID;
        private string table7Itemname;
        private int table7hprice;
        private int table7fprice;

        private int table8itemID;
        private string table8Itemname;
        private int table8hprice;
        private int table8fprice;

        private int table9itemID;
        private string table9Itemname;
        private int table9hprice;
        private int table9fprice;

        private int table10itemID;
        private string table10Itemname;
        private int table10hprice;
        private int table10fprice;

        private int table11itemID;
        private string table11Itemname;
        private int table11hprice;
        private int table11fprice;

        private int table12itemID;
        private string table12Itemname;
        private int table12hprice;
        private int table12fprice;

        private int x, y;
        public Billing()
        {
            InitializeComponent();

            //dbclass = new dbclass();
            //dbclass.CreateDatabaseAndFolder();
            //GetDefaultPrinterName();

            //Linkcombobox();
            //Table2Linkcombobox();
            //Table3Linkcombobox();
            //Table4Linkcombobox();
            //Table5Linkcombobox();
            //Table6Linkcombobox();
            //Table7Linkcombobox();
            //Table8Linkcombobox();
            //Table9Linkcombobox();
            //Table10Linkcombobox();
            //Table11Linkcombobox();
            //Table12Linkcombobox();


            //TotalTextBox.Enabled = false;
            //Table2TotalTextBox.Enabled = false;
            //Table3TotalTextBox.Enabled = false;
            //Table4TotalTextBox.Enabled = false;
            //Table5TotalTextBox.Enabled = false;
            //Table6TotalTextBox.Enabled = false;
            //Table7TotalTextBox.Enabled = false;
            //Table8TotalTextBox.Enabled = false;
            //Table9TotalTextBox.Enabled = false;
            //Table10TotalTextBox.Enabled = false;
            //Table11TotalTextBox.Enabled = false;
            //Table12TotalTextBox.Enabled = false;

            //RemoveItembutton.Enabled = false;
            //Table2RemoveButton.Enabled = false;
            //Table3RemoveButton.Enabled = false;
            //Table4RemoveButton.Enabled = false;
            //Table5RemoveButton.Enabled = false;
            //Table6RemoveButton.Enabled = false;
            //Table7RemoveButton.Enabled = false;
            //Table8RemoveButton.Enabled = false;
            //Table9RemoveButton.Enabled = false;
            //Table10RemoveButton.Enabled = false;
            //Table11RemoveButton.Enabled = false;
            //Table12RemoveButton.Enabled = false;

            //SavePrintButton.Enabled = false;
            //Table2Savebutton.Enabled = false;
            //Table3SaveButton.Enabled = false;
            //Table4SaveButton.Enabled = false;
            //Table5SaveButton.Enabled = false;
            //Table6SaveButton.Enabled = false;
            //Table7SaveButton.Enabled = false;
            //Table8SaveButton.Enabled = false;
            //Table9SaveButton.Enabled = false;
            //Table10SaveButton.Enabled = false;
            //Table11SaveButton.Enabled = false;
            //Table12SaveButton.Enabled = false;

            //EnablePrint.Checked = true;

            //checkifdatatableemprtyornot();
        }

        private string GetDefaultPrinterName()
        {
            PrinterSettings settings = new PrinterSettings();
            string printername = settings.PrinterName;
            if (settings.IsDefaultPrinter && settings.IsValid)
                return printername;
            else 
                return printername = "";
        }

        private void checkifdatatableemprtyornot()
        {
            DataTable dt = dbclass.getData();
 
            if (dt.Rows.Count < 1)
            {
                AddUpdateForm form = new AddUpdateForm();
                form.ShowDialog();
            }
        }

        #region table 1 
        private void Linkcombobox()
        {
            ItemNamecombobox.DataSource = dbclass.getData();
            ItemNamecombobox.DisplayMember = "Particulars";
            ItemNamecombobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            ItemNamecombobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ItemNamecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)ItemNamecombobox.SelectedItem;

            itemID = Convert.ToInt32(selectedrow["S.No."]);
            Itemname = selectedrow["Particulars"].ToString();
            hprice = Convert.ToInt32(selectedrow["Half P price"]);
            fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                FullPlatePriceButton.Text = "Full " + fprice;
                HalfPlatePriceButton.Text = "Half " + hprice;
                if (hprice == 0)
                {
                    HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    HalfPlatePriceButton.Enabled = true;
                }
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Linkcombobox();
            TableOneDatagrid.Rows.Clear();
            TotalTextBox.Text = "";
            Qtytextbox.Value = 1;
        }
        private void FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)ItemNamecombobox.SelectedItem;

            itemID = Convert.ToInt32(selectedrow["S.No."]);
            Itemname = selectedrow["Particulars"].ToString();
            fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Qtytextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in TableOneDatagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["ItemPrice"].Value.ToString());
                if (ItemIDExist == itemID && itempriceexist == fprice)
                {
                    int currentqty = int.Parse(row.Cells["Quantity"].Value.ToString());
                    row.Cells["Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * fprice;
                    row.Cells["Amount"].Value = amount;

                    TotalTextBoxValue();
                    Qtytextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * fprice;
                TableOneDatagrid.Rows.Add("", itemID, Itemname, qty, fprice, amount);
                Qtytextbox.Value = 1;
            }
        }
        private void TotalTextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in TableOneDatagrid.Rows)
            {
                if (row.Cells["Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    TotalTextBox.Text = string.Empty;
                }
            }
        }
        private void TableOneDatagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                TableOneDatagrid.Rows[e.RowIndex + i].Cells["Sno"].Value = snoValue;
            }
            RemoveItembutton.Enabled = true;
            SavePrintButton.Enabled = true;
            TotalTextBoxValue();
        }
        private void RemoveItembutton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(TableOneDatagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    TableOneDatagrid.Rows.RemoveAt(index);
                    TotalTextBoxValue();
                }
                if (TableOneDatagrid.Rows.Count == 0)
                {
                    TotalTextBox.Text = string.Empty;
                    RemoveItembutton.Enabled = false;
                    SavePrintButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }
        private void HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)ItemNamecombobox.SelectedItem;

            itemID = Convert.ToInt32(selectedrow["S.No."]);
            Itemname = selectedrow["Particulars"].ToString();
            hprice = Convert.ToInt32(selectedrow["Half P price"]);

            Itemname = Itemname + " (Half)";

            int qty = Convert.ToInt32(Qtytextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in TableOneDatagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["ItemPrice"].Value.ToString());

                if (ItemIDExist == itemID && itempriceexist == hprice)
                {
                    int currentqty = int.Parse(row.Cells["Quantity"].Value.ToString());
                    row.Cells["Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * hprice;
                    row.Cells["Amount"].Value = amount;

                    TotalTextBoxValue();
                    Qtytextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * hprice;
                TableOneDatagrid.Rows.Add("", itemID, Itemname, qty, hprice, amount);
                Qtytextbox.Value = 1;
            }
        }
        private void TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TotalTextBox.Text))
            {
                SavePrintButton.Enabled = false;
            }
        }
        private void SavePrintButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "1";
            int amount = Convert.ToInt32(TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in TableOneDatagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                            string rowname = row.Cells["name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            ClearButton_Click(sender, e);
        }
        #endregion

        #region table 2
        private void Table2Linkcombobox()
        {
            Table2Combobox.DataSource = dbclass.getData();
            Table2Combobox.DisplayMember = "Particulars";
            Table2Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table2Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table2TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table2DataGrid.Rows)
            {
                if (row.Cells["Table2Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table2Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table2Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table2TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table2TotalTextBox.Text = string.Empty;
                }
            }
        }
        private void Table2Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table2Combobox.SelectedItem;

            table2itemID = Convert.ToInt32(selectedrow["S.No."]);
            table2Itemname = selectedrow["Particulars"].ToString();
            table2hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table2fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table2FullPlateButton.Text = "Full " + table2fprice;
                Table2HalfPlateButton.Text = "Half " + table2hprice;
                if (table2hprice == 0)
                {
                    Table2HalfPlateButton.Enabled = false;
                }
                else
                {
                    Table2HalfPlateButton.Enabled = true;
                }
            }
        }
        private void Table2DataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table2DataGrid.Rows[e.RowIndex + i].Cells["Table2Sno"].Value = snoValue;
            }
            Table2RemoveButton.Enabled = true;
            Table2Savebutton.Enabled = true;
            Table2TextBoxValue();
        }
        private void Table2RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table2DataGrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table2DataGrid.Rows.RemoveAt(index);
                    Table2TextBoxValue();
                }
                if (Table2DataGrid.Rows.Count == 0)
                {
                    Table2TotalTextBox.Text = string.Empty;
                    Table2RemoveButton.Enabled = false;
                    Table2Savebutton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }
        private void Table2HalfPlateButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table2Combobox.SelectedItem;

            table2itemID = Convert.ToInt32(selectedrow["S.No."]);
            table2Itemname = selectedrow["Particulars"].ToString();
            table2hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table2Itemname = table2Itemname + " (Half)";

            int qty = Convert.ToInt32(Table2QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table2DataGrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table2Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table2ItemPrice"].Value.ToString());

                if (ItemIDExist == table2itemID && itempriceexist == table2hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table2Quantity"].Value.ToString());
                    row.Cells["Table2Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table2hprice;
                    row.Cells["Table2Amount"].Value = amount;

                    Table2TextBoxValue();
                    Table2QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table2hprice;
                Table2DataGrid.Rows.Add("", table2itemID, table2Itemname, qty, table2hprice, amount);
                Table2QuantityTextbox.Value = 1;
            }
        }
        private void Table2FullPlateButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table2Combobox.SelectedItem;

            table2itemID = Convert.ToInt32(selectedrow["S.No."]);
            table2Itemname = selectedrow["Particulars"].ToString();
            table2fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table2QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table2DataGrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table2Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table2ItemPrice"].Value.ToString());
                if (ItemIDExist == table2itemID && itempriceexist == table2fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table2Quantity"].Value.ToString());
                    row.Cells["Table2Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table2fprice;
                    row.Cells["Table2Amount"].Value = amount;

                    Table2TextBoxValue();
                    Table2QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table2fprice;

                Table2DataGrid.Rows.Add("", table2itemID, table2Itemname, qty, table2fprice, amount);
                Table2QuantityTextbox.Value = 1;
            }
        }
        private void Table2ClearRefreshbutton_Click(object sender, EventArgs e)
        {
            Table2Linkcombobox();
            Table2DataGrid.Rows.Clear();
            Table2TotalTextBox.Text = "";
            Table2QuantityTextbox.Value = 1;
        }
        private void Table2TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table2TotalTextBox.Text))
            {
                Table2Savebutton.Enabled = false;
            }
        }
        private void Table2Savebutton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "2";
            int amount = Convert.ToInt32(Table2TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table2DataGrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table2Id"].Value.ToString());
                            string rowname = row.Cells["Table2name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table2Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table2ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table2Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table2ClearRefreshbutton_Click(sender, e);
        }
        #endregion

        #region table 3
        private void Table3Linkcombobox()
        {
            Table3Combobox.DataSource = dbclass.getData();
            Table3Combobox.DisplayMember = "Particulars";
            Table3Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table3Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table3TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table3Datagrid.Rows)
            {
                if (row.Cells["Table3Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table3Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table3Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table3TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table3TotalTextBox.Text = string.Empty;
                }
            }
        }
        private void Table3Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table3Combobox.SelectedItem;

            table3itemID = Convert.ToInt32(selectedrow["S.No."]);
            table3Itemname = selectedrow["Particulars"].ToString();
            table3hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table3fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table3FullPlatePriceButton.Text = "Full " + table3fprice;
                Table3HalfPlatePriceButton.Text = "Half " + table3hprice;

                if (table3hprice == 0)
                {
                    Table3HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table3HalfPlatePriceButton.Enabled = true;
                }
            }
        }
        private void Table3Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table3Datagrid.Rows[e.RowIndex + i].Cells["Table3Sno"].Value = snoValue;
            }
            Table3RemoveButton.Enabled = true;
            Table3SaveButton.Enabled = true;
            Table3TextBoxValue();
        }
        private void Table3RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table3Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table3Datagrid.Rows.RemoveAt(index);
                    Table3TextBoxValue();
                }
                if (Table3Datagrid.Rows.Count == 0)
                {
                    Table3TotalTextBox.Text = string.Empty;
                    Table3RemoveButton.Enabled = false;
                    Table3SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }
        private void Table3HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table3Combobox.SelectedItem;

            table3itemID = Convert.ToInt32(selectedrow["S.No."]);
            table3Itemname = selectedrow["Particulars"].ToString();
            table3hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table3Itemname = table3Itemname + " (Half)";

            int qty = Convert.ToInt32(Table3QuantityTextBox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table3Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table3Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table3ItemPrice"].Value.ToString());

                if (ItemIDExist == table3itemID && itempriceexist == table3hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table3Quantity"].Value.ToString());
                    row.Cells["Table3Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table3hprice;
                    row.Cells["Table3Amount"].Value = amount;

                    Table3TextBoxValue();
                    Table3QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table3hprice;
                Table3Datagrid.Rows.Add("", table3itemID, table3Itemname, qty, table3hprice, amount);
                Table3QuantityTextBox.Value = 1;
            }
        }
        private void Table3FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table3Combobox.SelectedItem;

            table3itemID = Convert.ToInt32(selectedrow["S.No."]);
            table3Itemname = selectedrow["Particulars"].ToString();
            table3fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table3QuantityTextBox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table3Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table3Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table3ItemPrice"].Value.ToString());
                if (ItemIDExist == table3itemID && itempriceexist == table3fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table3Quantity"].Value.ToString());
                    row.Cells["Table3Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table3fprice;
                    row.Cells["Table3Amount"].Value = amount;

                    Table3TextBoxValue();
                    Table3QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table3fprice;

                Table3Datagrid.Rows.Add("", table3itemID, table3Itemname, qty, table3fprice, amount);
                Table3QuantityTextBox.Value = 1;
            }
        }
        private void Table3ClearRefreshbutton_Click(object sender, EventArgs e)
        {
            Table3Linkcombobox();
            Table3Datagrid.Rows.Clear();
            Table3TotalTextBox.Text = "";
            Table3QuantityTextBox.Value = 1;
        }
        private void Table3TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table3TotalTextBox.Text))
            {
                Table3SaveButton.Enabled = false;
            }
        }
        private void Table3SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "3";
            int amount = Convert.ToInt32(Table3TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table3Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table3Id"].Value.ToString());
                            string rowname = row.Cells["Table3name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table3Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table3ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table3Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table3ClearRefreshbutton_Click(sender, e);
        }
        #endregion

        #region table 4
        private void Table4Linkcombobox()
        {
            Table4Combobox.DataSource = dbclass.getData();
            Table4Combobox.DisplayMember = "Particulars";
            Table4Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table4Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table4TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table4DataGrid.Rows)
            {
                if (row.Cells["Table4Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table4Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table4Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table4TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table4TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table4Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table4Combobox.SelectedItem;

            table4itemID = Convert.ToInt32(selectedrow["S.No."]);
            table4Itemname = selectedrow["Particulars"].ToString();
            table4hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table4fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table4FullPlatePriceButton.Text = "Full " + table4fprice;
                Table4HalfPlatePriceButton.Text = "Half " + table4hprice;

                if (table4hprice == 0)
                {
                    Table4HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table4HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table4DataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table4DataGrid.Rows[e.RowIndex + i].Cells["Table4Sno"].Value = snoValue;
            }
            Table4RemoveButton.Enabled = true;
            Table4SaveButton.Enabled = true;
            Table4TextBoxValue();
        }

        private void Table4RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table4DataGrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table4DataGrid.Rows.RemoveAt(index);
                    Table4TextBoxValue();
                }
                if (Table4DataGrid.Rows.Count == 0)
                {
                    Table4TotalTextBox.Text = string.Empty;
                    Table4RemoveButton.Enabled = false;
                    Table4SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table4HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table4Combobox.SelectedItem;

            table4itemID = Convert.ToInt32(selectedrow["S.No."]);
            table4Itemname = selectedrow["Particulars"].ToString();
            table4hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table4Itemname = table4Itemname + " (Half)";

            int qty = Convert.ToInt32(Table4QuantityTextBox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table4DataGrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table4Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table4ItemPrice"].Value.ToString());

                if (ItemIDExist == table4itemID && itempriceexist == table4hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table4Quantity"].Value.ToString());
                    row.Cells["Table4Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table4hprice;
                    row.Cells["Table4Amount"].Value = amount;

                    Table4TextBoxValue();
                    Table4QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table4hprice;
                Table4DataGrid.Rows.Add("", table4itemID, table4Itemname, qty, table4hprice, amount);
                Table4QuantityTextBox.Value = 1;
            }
        }

        private void Table4FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table4Combobox.SelectedItem;

            table4itemID = Convert.ToInt32(selectedrow["S.No."]);
            table4Itemname = selectedrow["Particulars"].ToString();
            table4fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table4QuantityTextBox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table4DataGrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table4Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table4ItemPrice"].Value.ToString());
                if (ItemIDExist == table4itemID && itempriceexist == table4fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table4Quantity"].Value.ToString());
                    row.Cells["Table4Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table4fprice;
                    row.Cells["Table4Amount"].Value = amount;

                    Table4TextBoxValue();
                    Table4QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table4fprice;

                Table4DataGrid.Rows.Add("", table4itemID, table4Itemname, qty, table4fprice, amount);
                Table4QuantityTextBox.Value = 1;
            }
        }

        private void Table4ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table4Linkcombobox();
            Table4DataGrid.Rows.Clear();
            Table4TotalTextBox.Text = "";
            Table4QuantityTextBox.Value = 1;
        }

        private void Table4TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table4TotalTextBox.Text))
            {
                Table4SaveButton.Enabled = false;
            }
        }
        private void Table4SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "4";
            int amount = Convert.ToInt32(Table4TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table4DataGrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table4Id"].Value.ToString());
                            string rowname = row.Cells["Table4name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table4Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table4ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table4Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table4ClearRefreshButton_Click(sender, e);
        }
        #endregion

        #region table 5
        private void Table5Linkcombobox()
        {
            Table5Combobox.DataSource = dbclass.getData();
            Table5Combobox.DisplayMember = "Particulars";
            Table5Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table5Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table5TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table5Datagrid.Rows)
            {
                if (row.Cells["Table5Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table5Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table5Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table5TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table5TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table5Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table5Combobox.SelectedItem;

            table5itemID = Convert.ToInt32(selectedrow["S.No."]);
            table5Itemname = selectedrow["Particulars"].ToString();
            table5hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table5fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table5FullPlatePriceButton.Text = "Full " + table5fprice;
                Table5HalfPlatePriceButton.Text = "Half " + table5hprice;

                if (table5hprice == 0)
                {
                    Table5HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table5HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table5Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table5Datagrid.Rows[e.RowIndex + i].Cells["Table5Sno"].Value = snoValue;
            }
            Table5RemoveButton.Enabled = true;
            Table5SaveButton.Enabled = true;
            Table5TextBoxValue();
        }

        private void Table5RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table5Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table5Datagrid.Rows.RemoveAt(index);
                    Table5TextBoxValue();
                }
                if (Table5Datagrid.Rows.Count == 0)
                {
                    Table5TotalTextBox.Text = string.Empty;
                    Table5RemoveButton.Enabled = false;
                    Table5SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table5HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table5Combobox.SelectedItem;

            table5itemID = Convert.ToInt32(selectedrow["S.No."]);
            table5Itemname = selectedrow["Particulars"].ToString();
            table5hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table5Itemname = table5Itemname + " (Half)";

            int qty = Convert.ToInt32(Table5QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table5Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table5Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table5ItemPrice"].Value.ToString());

                if (ItemIDExist == table5itemID && itempriceexist == table5hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table5Quantity"].Value.ToString());
                    row.Cells["Table5Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table5hprice;
                    row.Cells["Table5Amount"].Value = amount;

                    Table5TextBoxValue();
                    Table5QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table5hprice;
                Table5Datagrid.Rows.Add("", table5itemID, table5Itemname, qty, table5hprice, amount);
                Table5QuantityTextbox.Value = 1;
            }
        }

        private void Table5FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table5Combobox.SelectedItem;

            table5itemID = Convert.ToInt32(selectedrow["S.No."]);
            table5Itemname = selectedrow["Particulars"].ToString();
            table5fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table5QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table5Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table5Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table5ItemPrice"].Value.ToString());
                if (ItemIDExist == table5itemID && itempriceexist == table5fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table5Quantity"].Value.ToString());
                    row.Cells["Table5Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table5fprice;
                    row.Cells["Table5Amount"].Value = amount;

                    Table5TextBoxValue();
                    Table5QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table5fprice;

                Table5Datagrid.Rows.Add("", table5itemID, table5Itemname, qty, table5fprice, amount);
                Table5QuantityTextbox.Value = 1;
            }
        }

        private void Table5ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table5Linkcombobox();
            Table5Datagrid.Rows.Clear();
            Table5TotalTextBox.Text = "";
            Table5QuantityTextbox.Value = 1;
        }

        private void Table5TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table5TotalTextBox.Text))
            {
                Table5SaveButton.Enabled = false;
            }
        }
        private void Table5SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "5";
            int amount = Convert.ToInt32(Table5TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table5Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table5Id"].Value.ToString());
                            string rowname = row.Cells["Table5name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table5Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table5ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table5Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table5ClearRefreshButton_Click(sender, e);
        }
        #endregion

        #region table 6
        private void Table6Linkcombobox()
        {
            Table6Combobox.DataSource = dbclass.getData();
            Table6Combobox.DisplayMember = "Particulars";
            Table6Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table6Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table6TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table6Datagrid.Rows)
            {
                if (row.Cells["Table6Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table6Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table6Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table6TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table6TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table6Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table6Combobox.SelectedItem;

            table6itemID = Convert.ToInt32(selectedrow["S.No."]);
            table6Itemname = selectedrow["Particulars"].ToString();
            table6hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table6fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table6FullPlatePriceButton.Text = "Full " + table6fprice;
                Table6HalfPlatePriceButton.Text = "Half " + table6hprice;

                if (table6hprice == 0)
                {
                    Table6HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table6HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table6Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table6Datagrid.Rows[e.RowIndex + i].Cells["Table6Sno"].Value = snoValue;
            }
            Table6RemoveButton.Enabled = true;
            Table6SaveButton.Enabled = true;
            Table6TextBoxValue();
        }

        private void Table6RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table6Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table6Datagrid.Rows.RemoveAt(index);
                    Table6TextBoxValue();
                }
                if (Table6Datagrid.Rows.Count == 0)
                {
                    Table6TotalTextBox.Text = string.Empty;
                    Table6RemoveButton.Enabled = false;
                    Table6SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table6HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table6Combobox.SelectedItem;

            table6itemID = Convert.ToInt32(selectedrow["S.No."]);
            table6Itemname = selectedrow["Particulars"].ToString();
            table6hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table6Itemname = table6Itemname + " (Half)";

            int qty = Convert.ToInt32(Table6QuantityTextBox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table6Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table6Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table6ItemPrice"].Value.ToString());

                if (ItemIDExist == table6itemID && itempriceexist == table6hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table6Quantity"].Value.ToString());
                    row.Cells["Table6Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table6hprice;
                    row.Cells["Table6Amount"].Value = amount;

                    Table6TextBoxValue();
                    Table6QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table6hprice;
                Table6Datagrid.Rows.Add("", table6itemID, table6Itemname, qty, table6hprice, amount);
                Table6QuantityTextBox.Value = 1;
            }
        }

        private void Table6FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table6Combobox.SelectedItem;

            table6itemID = Convert.ToInt32(selectedrow["S.No."]);
            table6Itemname = selectedrow["Particulars"].ToString();
            table6fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table6QuantityTextBox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table6Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table6Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table6ItemPrice"].Value.ToString());
                if (ItemIDExist == table6itemID && itempriceexist == table6fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table6Quantity"].Value.ToString());
                    row.Cells["Table6Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table6fprice;
                    row.Cells["Table6Amount"].Value = amount;

                    Table6TextBoxValue();
                    Table6QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table6fprice;

                Table6Datagrid.Rows.Add("", table6itemID, table6Itemname, qty, table6fprice, amount);
                Table6QuantityTextBox.Value = 1;
            }
        }

        private void Table6ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table6Linkcombobox();
            Table6Datagrid.Rows.Clear();
            Table6TotalTextBox.Text = "";
            Table6QuantityTextBox.Value = 1;
        }

        private void Table6TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table6TotalTextBox.Text))
            {
                Table6SaveButton.Enabled = false;
            }
        }
        private void Table6SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "6";
            int amount = Convert.ToInt32(Table6TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table6Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table6Id"].Value.ToString());
                            string rowname = row.Cells["Table6name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table6Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table6ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table6Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table6ClearRefreshButton_Click(sender, e);
        }
        #endregion

        #region table 7
        private void Table7Linkcombobox()
        {
            Table7Combobox.DataSource = dbclass.getData();
            Table7Combobox.DisplayMember = "Particulars";
            Table7Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table7Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table7TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table7Datagrid.Rows)
            {
                if (row.Cells["Table7Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table7Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table7Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table7TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table7TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table7Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table7Combobox.SelectedItem;

            table7itemID = Convert.ToInt32(selectedrow["S.No."]);
            table7Itemname = selectedrow["Particulars"].ToString();
            table7hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table7fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table7FullPlatePriceButton.Text = "Full " + table7fprice;
                Table7HalfPlatePriceButton.Text = "Half " + table7hprice;

                if (table7hprice == 0)
                {
                    Table7HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table7HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table7Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table7Datagrid.Rows[e.RowIndex + i].Cells["Table7Sno"].Value = snoValue;
            }
            Table7RemoveButton.Enabled = true;
            Table7SaveButton.Enabled = true;
            Table7TextBoxValue();
        }

        private void Table7RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table7Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table7Datagrid.Rows.RemoveAt(index);
                    Table7TextBoxValue();
                }
                if (Table7Datagrid.Rows.Count == 0)
                {
                    Table7TotalTextBox.Text = string.Empty;
                    Table7RemoveButton.Enabled = false;
                    Table7SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table7HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table7Combobox.SelectedItem;

            table7itemID = Convert.ToInt32(selectedrow["S.No."]);
            table7Itemname = selectedrow["Particulars"].ToString();
            table7hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table7Itemname = table7Itemname + " (Half)";

            int qty = Convert.ToInt32(Table7QuantityTextBox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table7Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table7Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table7ItemPrice"].Value.ToString());

                if (ItemIDExist == table7itemID && itempriceexist == table7hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table7Quantity"].Value.ToString());
                    row.Cells["Table7Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table7hprice;
                    row.Cells["Table7Amount"].Value = amount;

                    Table7TextBoxValue();
                    Table7QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table7hprice;
                Table7Datagrid.Rows.Add("", table7itemID, table7Itemname, qty, table7hprice, amount);
                Table7QuantityTextBox.Value = 1;
            }
        }

        private void Table7FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table7Combobox.SelectedItem;

            table7itemID = Convert.ToInt32(selectedrow["S.No."]);
            table7Itemname = selectedrow["Particulars"].ToString();
            table7fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table7QuantityTextBox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table7Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table7Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table7ItemPrice"].Value.ToString());
                if (ItemIDExist == table7itemID && itempriceexist == table7fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table7Quantity"].Value.ToString());
                    row.Cells["Table7Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table7fprice;
                    row.Cells["Table7Amount"].Value = amount;

                    Table7TextBoxValue();
                    Table7QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table7fprice;

                Table7Datagrid.Rows.Add("", table7itemID, table7Itemname, qty, table7fprice, amount);
                Table7QuantityTextBox.Value = 1;
            }
        }

        private void Table7ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table7Linkcombobox();
            Table7Datagrid.Rows.Clear();
            Table7TotalTextBox.Text = "";
            Table7QuantityTextBox.Value = 1;
        }

        private void Table7TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table7TotalTextBox.Text))
            {
                Table7SaveButton.Enabled = false;
            }
        }
        private void Table7SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "7";
            int amount = Convert.ToInt32(Table7TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table7Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table7Id"].Value.ToString());
                            string rowname = row.Cells["Table7name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table7Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table7ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table7Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table7ClearRefreshButton_Click(sender, e);
        }
        #endregion

        #region table 8
        private void Table8Linkcombobox()
        {
            Table8Combobox.DataSource = dbclass.getData();
            Table8Combobox.DisplayMember = "Particulars";
            Table8Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table8Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table8TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table8Datagrid.Rows)
            {
                if (row.Cells["Table8Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table8Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table8Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table8TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table8TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table8Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table8Combobox.SelectedItem;

            table8itemID = Convert.ToInt32(selectedrow["S.No."]);
            table8Itemname = selectedrow["Particulars"].ToString();
            table8hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table8fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table8FullPlatePriceButton.Text = "Full " + table8fprice;
                Table8HalfPlatePriceButton.Text = "Half " + table8hprice;

                if (table8hprice == 0)
                {
                    Table8HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table8HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table8Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table8Datagrid.Rows[e.RowIndex + i].Cells["Table8Sno"].Value = snoValue;
            }
            Table8RemoveButton.Enabled = true;
            Table8SaveButton.Enabled = true;
            Table8TextBoxValue();
        }

        private void Table8RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table8Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table8Datagrid.Rows.RemoveAt(index);
                    Table8TextBoxValue();
                }
                if (Table8Datagrid.Rows.Count == 0)
                {
                    Table8TotalTextBox.Text = string.Empty;
                    Table8RemoveButton.Enabled = false;
                    Table8SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table8HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table8Combobox.SelectedItem;

            table8itemID = Convert.ToInt32(selectedrow["S.No."]);
            table8Itemname = selectedrow["Particulars"].ToString();
            table8hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table8Itemname = table8Itemname + " (Half)";

            int qty = Convert.ToInt32(Table8QuantityTextBox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table8Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table8Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table8ItemPrice"].Value.ToString());

                if (ItemIDExist == table8itemID && itempriceexist == table8hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table8Quantity"].Value.ToString());
                    row.Cells["Table8Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table8hprice;
                    row.Cells["Table8Amount"].Value = amount;

                    Table8TextBoxValue();
                    Table8QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table8hprice;
                Table8Datagrid.Rows.Add("", table8itemID, table8Itemname, qty, table8hprice, amount);
                Table8QuantityTextBox.Value = 1;
            }
        }

        private void Table8FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table8Combobox.SelectedItem;

            table8itemID = Convert.ToInt32(selectedrow["S.No."]);
            table8Itemname = selectedrow["Particulars"].ToString();
            table8fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table8QuantityTextBox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table8Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table8Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table8ItemPrice"].Value.ToString());
                if (ItemIDExist == table8itemID && itempriceexist == table8fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table8Quantity"].Value.ToString());
                    row.Cells["Table8Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table8fprice;
                    row.Cells["Table8Amount"].Value = amount;

                    Table8TextBoxValue();
                    Table8QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table8fprice;

                Table8Datagrid.Rows.Add("", table8itemID, table8Itemname, qty, table8fprice, amount);
                Table8QuantityTextBox.Value = 1;
            }
        }

        private void Table8ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table8Linkcombobox();
            Table8Datagrid.Rows.Clear();
            Table8TotalTextBox.Text = "";
            Table8QuantityTextBox.Value = 1;
        }

        private void Table8TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table8TotalTextBox.Text))
            {
                Table8SaveButton.Enabled = false;
            }
        }
        private void Table8SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "8";
            int amount = Convert.ToInt32(Table8TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0) // ordernumber, amount, datetime, tablenumber, datagridview
                {
                    foreach (DataGridViewRow row in Table8Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table8Id"].Value.ToString());
                            string rowname = row.Cells["Table8name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table8Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table8ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table8Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);
                        }
                    }

                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table8ClearRefreshButton_Click(sender, e);
        }
        #endregion

        private void AddUpdateOpenForm_Click(object sender, EventArgs e)
        {
            AddUpdateForm form2 = new AddUpdateForm();
            form2 .ShowDialog();
        }

        public void PrintPdf()
        {
            if (EnablePrint.Checked)
            {
                string printername = GetDefaultPrinterName();
                if (!string.IsNullOrEmpty(printername))
                {
                    printPreviewDialog1.Document = printDocument1;
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("custom", 285, 700);
                    //printPreviewDialog1.ShowDialog();
                    printDocument1.Print();
                }
            }
        }

        private void OpenSalesWindow_Click(object sender, EventArgs e)
        {
                Sale form2 = new Sale();
                form2.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Linkcombobox();
            Table2Linkcombobox();
            Table3Linkcombobox();
            Table4Linkcombobox();
            Table5Linkcombobox();
            Table6Linkcombobox();
            Table7Linkcombobox();
            Table8Linkcombobox();
            Table9Linkcombobox();
            Table10Linkcombobox();
            Table11Linkcombobox();
            Table12Linkcombobox();

            TotalTextBox.Enabled = false;
            Table2TotalTextBox.Enabled = false;
            Table3TotalTextBox.Enabled = false;
            Table4TotalTextBox.Enabled = false;
            Table5TotalTextBox.Enabled = false;
            Table6TotalTextBox.Enabled = false;
            Table7TotalTextBox.Enabled = false;
            Table8TotalTextBox.Enabled = false;
            Table9TotalTextBox.Enabled = false;
            Table10TotalTextBox.Enabled = false;
            Table11TotalTextBox.Enabled = false;
            Table12TotalTextBox.Enabled = false;

            RemoveItembutton.Enabled = false;
            Table2RemoveButton.Enabled = false;
            Table3RemoveButton.Enabled = false;
            Table4RemoveButton.Enabled = false;
            Table5RemoveButton.Enabled = false;
            Table6RemoveButton.Enabled = false;
            Table7RemoveButton.Enabled = false;
            Table8RemoveButton.Enabled = false;
            Table9RemoveButton.Enabled = false;
            Table10RemoveButton.Enabled = false;
            Table11RemoveButton.Enabled = false;
            Table12RemoveButton.Enabled = false;

            SavePrintButton.Enabled = false;
            Table2Savebutton.Enabled = false;
            Table3SaveButton.Enabled = false;
            Table4SaveButton.Enabled = false;
            Table5SaveButton.Enabled = false;
            Table6SaveButton.Enabled = false;
            Table7SaveButton.Enabled = false;
            Table8SaveButton.Enabled = false;
            Table9SaveButton.Enabled = false;
            Table10SaveButton.Enabled = false;
            Table11SaveButton.Enabled = false;
            Table12SaveButton.Enabled = false;

            TableOneDatagrid.Rows.Clear();
            Table2DataGrid.Rows.Clear();
            Table3Datagrid.Rows.Clear();
            Table4DataGrid.Rows.Clear();
            Table5Datagrid.Rows.Clear();
            Table6Datagrid.Rows.Clear();
            Table7Datagrid.Rows.Clear();
            Table8Datagrid.Rows.Clear();
            Table9Datagrid.Rows.Clear();
            Table10Datagrid.Rows.Clear();
            Table12Datagrid.Rows.Clear();
            Table11Datagrid.Rows.Clear();

            Qtytextbox.Value = 1;
            Table2QuantityTextbox.Value = 1;
            Table3QuantityTextBox.Value = 1;
            Table4QuantityTextBox.Value = 1;
            Table5QuantityTextbox.Value = 1;
            Table6QuantityTextBox.Value = 1;
            Table7QuantityTextBox.Value = 1;
            Table8QuantityTextBox.Value = 1;

            Table9QuantityTextbox.Value = 1;
            Table10QuantityTextbox.Value = 1;
            Table11QuantityTextbox.Value = 1;
            Table12QuantityTextbox.Value = 1;

            TotalTextBox.Text = string.Empty;
            Table2TotalTextBox.Text = string.Empty;
            Table3TotalTextBox.Text = string.Empty;
            Table4TotalTextBox.Text = string.Empty;
            Table5TotalTextBox.Text = string.Empty;
            Table6TotalTextBox.Text = string.Empty;
            Table7TotalTextBox.Text = string.Empty;
            Table8TotalTextBox.Text = string.Empty;
            Table9TotalTextBox.Text = string.Empty;
            Table10TotalTextBox.Text = string.Empty;
            Table11TotalTextBox.Text = string.Empty;
            Table12TotalTextBox.Text = string.Empty;

            checkifdatatableemprtyornot();

            Billing_Load(sender, e);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int PrintOrderNumber = dbclass.getordernumber();

            DataTable OrderDetail = dbclass.GetOrderNumberDetail(PrintOrderNumber);

            DataTable itemList = dbclass.getSaleData(PrintOrderNumber);

            string tablenumber = OrderDetail.Rows[0][1].ToString();
            string Orderamount = OrderDetail.Rows[0][2].ToString();

            DateTime date = Convert.ToDateTime(OrderDetail.Rows[0][3]);
            date = date.Date;

            e.Graphics.DrawString("TIRUPATI", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 90, 50);
            e.Graphics.DrawString("VAISHNO DHABA", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, 70, 75);

            Pen dotted = new Pen(System.Drawing.Color.Black);
            dotted.DashStyle = DashStyle.DashDot;
            e.Graphics.DrawLine(dotted, new Point(20, 100), new Point(265, 100));
            dotted.Dispose();

            e.Graphics.DrawString("Jawalaji Road, P.W.D Rest House,", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 35, 110);
            e.Graphics.DrawString("Nadaun Distt. Hamirpur, H.P.", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 50, 130);
            e.Graphics.DrawString("Contact: 01972-313228", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 62, 150);

            Pen dotted2 = new Pen(Color.Black);
            dotted2.DashStyle = DashStyle.DashDot;
            e.Graphics.DrawLine(dotted2, new Point(20, 170), new Point(265, 170));
            dotted2.Dispose();


            e.Graphics.DrawString("Order no.: " + PrintOrderNumber, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 20, 180);
            e.Graphics.DrawString("Table no.: " + tablenumber, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 170, 180);

            e.Graphics.DrawString("Order date: " + date.ToString("dd-MM-yyyy"), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 200);

            Pen dotted3 = new Pen(Color.Black);
            dotted3.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(dotted3, new Point(20, 217), new Point(265, 217));
            dotted3.Dispose();

            e.Graphics.DrawString("Particulars", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 220);
            e.Graphics.DrawString("Qty", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 170, 220);
            e.Graphics.DrawString("Price", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 230, 220);

            Pen dotted4 = new Pen(Color.Black);
            dotted4.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(dotted4, new Point(20, 237), new Point(265, 237));
            dotted4.Dispose();

            y = 240;
            x = 20;

            foreach (DataRow row in itemList.Rows)
            {
                string itemname = row["Particulars"].ToString();
                int qty = Convert.ToInt32(row["Qty"]);
                int price = Convert.ToInt32(row["Item Amount"]);

                e.Graphics.DrawString(itemname, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, x, y);
                x = x + 150;
                e.Graphics.DrawString(qty.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, x, y);
                x = x + 60;
                e.Graphics.DrawString(price.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, x, y);

                y = y + 15;
                x = 20;
            }
            Pen dotted5 = new Pen(Color.Black);
            dotted5.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(dotted5, new Point(20, y + 5), new Point(265, y + 5));
            dotted5.Dispose();

            e.Graphics.DrawString("Total : ₹" + Orderamount + "/-", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 165, y + 15);

            Pen dotted6 = new Pen(Color.Black);
            dotted6.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(dotted6, new Point(20, y + 35), new Point(265, y + 35));
            dotted6.Dispose();

            e.Graphics.DrawString("THANK YOU!", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 100, y + 40);
        }

        #region Table 9
        private void Table9Linkcombobox()
        {
            Table9Combobox.DataSource = dbclass.getData();
            Table9Combobox.DisplayMember = "Particulars";
            Table9Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table9Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table9TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table9Datagrid.Rows)
            {
                if (row.Cells["Table9Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table9Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table9Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table9TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table9TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table9Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table9Datagrid.Rows[e.RowIndex + i].Cells["Table9Sno"].Value = snoValue;
            }
            Table9RemoveButton.Enabled = true;
            Table9SaveButton.Enabled = true;
            Table9TextBoxValue();
        }

        private void Table9RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table9Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table9Datagrid.Rows.RemoveAt(index);
                    Table9TextBoxValue();
                }
                if (Table9Datagrid.Rows.Count == 0)
                {
                    Table9TotalTextBox.Text = string.Empty;
                    Table9RemoveButton.Enabled = false;
                    Table9SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table9HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table9Combobox.SelectedItem;

            table9itemID = Convert.ToInt32(selectedrow["S.No."]);
            table9Itemname = selectedrow["Particulars"].ToString();
            table9hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table9Itemname = table9Itemname + " (Half)";

            int qty = Convert.ToInt32(Table9QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table9Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table9Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table9ItemPrice"].Value.ToString());

                if (ItemIDExist == table9itemID && itempriceexist == table9hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table9Quantity"].Value.ToString());
                    row.Cells["Table9Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table9hprice;
                    row.Cells["Table9Amount"].Value = amount;

                    Table9TextBoxValue();
                    Table9QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table9hprice;
                Table9Datagrid.Rows.Add("", table9itemID, table9Itemname, qty, table9hprice, amount);
                Table9QuantityTextbox.Value = 1;
            }
        }

        private void Table9FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table9Combobox.SelectedItem;

            table9itemID = Convert.ToInt32(selectedrow["S.No."]);
            table9Itemname = selectedrow["Particulars"].ToString();
            table9fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table9QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table9Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table9Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table9ItemPrice"].Value.ToString());
                if (ItemIDExist == table9itemID && itempriceexist == table9fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table9Quantity"].Value.ToString());
                    row.Cells["Table9Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table9fprice;
                    row.Cells["Table9Amount"].Value = amount;

                    Table9TextBoxValue();
                    Table9QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table9fprice;

                Table9Datagrid.Rows.Add("", table9itemID, table9Itemname, qty, table9fprice, amount);
                Table9QuantityTextbox.Value = 1;
            }
        }

        private void Table9ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table9Linkcombobox();
            Table9Datagrid.Rows.Clear();
            Table9TotalTextBox.Text = "";
            Table9QuantityTextbox.Value = 1;
        }

        private void Table9TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table9TotalTextBox.Text))
            {
                Table9SaveButton.Enabled = false;
            }
        }

        private void Table9SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "9";
            int amount = Convert.ToInt32(Table9TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0) // ordernumber, amount, datetime, tablenumber, datagridview
                {
                    foreach (DataGridViewRow row in Table9Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table9Id"].Value.ToString());
                            string rowname = row.Cells["Table9name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table9Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table9ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table9Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);
                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table9ClearRefreshButton_Click(sender, e);
        }
        private void Table9Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table9Combobox.SelectedItem;

            table9itemID = Convert.ToInt32(selectedrow["S.No."]);
            table9Itemname = selectedrow["Particulars"].ToString();
            table9hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table9fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table9FullPlatePriceButton.Text = "Full " + table9fprice;
                Table9HalfPlatePriceButton.Text = "Half " + table9hprice;

                if (table9hprice == 0)
                {
                    Table9HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table9HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        #endregion

        #region Table 10
        private void Table10Linkcombobox()
        {
            Table10Combobox.DataSource = dbclass.getData();
            Table10Combobox.DisplayMember = "Particulars";
            Table10Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table10Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table10TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table10Datagrid.Rows)
            {
                if (row.Cells["Table10Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table10Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table10Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table10TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table10TotalTextBox.Text = string.Empty;
                }
            }
        }
        private void Table10Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table10Datagrid.Rows[e.RowIndex + i].Cells["Table10Sno"].Value = snoValue;
            }
            Table10RemoveButton.Enabled = true;
            Table10SaveButton.Enabled = true;
            Table10TextBoxValue();
        }

        private void Table10HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table10Combobox.SelectedItem;

            table10itemID = Convert.ToInt32(selectedrow["S.No."]);
            table10Itemname = selectedrow["Particulars"].ToString();
            table10hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table10Itemname = table10Itemname + " (Half)";

            int qty = Convert.ToInt32(Table10QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table10Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table10Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table10ItemPrice"].Value.ToString());

                if (ItemIDExist == table10itemID && itempriceexist == table10hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table10Quantity"].Value.ToString());
                    row.Cells["Table10Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table10hprice;
                    row.Cells["Table10Amount"].Value = amount;

                    Table10TextBoxValue();
                    Table10QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table10hprice;
                Table10Datagrid.Rows.Add("", table10itemID, table10Itemname, qty, table10hprice, amount);
                Table10QuantityTextbox.Value = 1;
            }
        }

        private void Table10ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table10Linkcombobox();
            Table10Datagrid.Rows.Clear();
            Table10TotalTextBox.Text = "";
            Table10QuantityTextbox.Value = 1;
        }

        private void Table10TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table10TotalTextBox.Text))
            {
                Table10SaveButton.Enabled = false;
            }
        }

        private void Table10SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "10";
            int amount = Convert.ToInt32(Table10TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0) // ordernumber, amount, datetime, tablenumber, datagridview
                {
                    foreach (DataGridViewRow row in Table10Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table10Id"].Value.ToString());
                            string rowname = row.Cells["Table10name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table10Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table10ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table10Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);
                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table10ClearRefreshButton_Click(sender, e);
        }

        private void Table10Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table10Combobox.SelectedItem;

            table10itemID = Convert.ToInt32(selectedrow["S.No."]);   
            table10Itemname = selectedrow["Particulars"].ToString();
            table10hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table10fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table10FullPlatePriceButton.Text = "Full " + table10fprice;
                Table10HalfPlatePriceButton.Text = "Half " + table10hprice;

                if (table10hprice == 0)
                {
                    Table10HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table10HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table10FullPlatePriceButton_Click_1(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table10Combobox.SelectedItem;

            table10itemID = Convert.ToInt32(selectedrow["S.No."]);
            table10Itemname = selectedrow["Particulars"].ToString();
            table10fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table10QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table10Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table10Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table10ItemPrice"].Value.ToString());
                if (ItemIDExist == table10itemID && itempriceexist == table10fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table10Quantity"].Value.ToString());
                    row.Cells["Table10Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table10fprice;
                    row.Cells["Table10Amount"].Value = amount;

                    Table10TextBoxValue();
                    Table10QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table10fprice;

                Table10Datagrid.Rows.Add("", table10itemID, table10Itemname, qty, table10fprice, amount);
                Table10QuantityTextbox.Value = 1;
            }
        }

        private void Table10RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table10Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table10Datagrid.Rows.RemoveAt(index);
                    Table10TextBoxValue();
                }
                if (Table10Datagrid.Rows.Count == 0)
                {
                    Table10TotalTextBox.Text = string.Empty;
                    Table10RemoveButton.Enabled = false;
                    Table10SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        #endregion

        #region Table 11
        private void Table11Linkcombobox()
        {
            Table11Combobox.DataSource = dbclass.getData();
            Table11Combobox.DisplayMember = "Particulars";
            Table11Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table11Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table11TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table11Datagrid.Rows)
            {
                if (row.Cells["Table11Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table11Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table11Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table11TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table11TotalTextBox.Text = string.Empty;
                }
            }
        }
        private void Table11Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table11Combobox.SelectedItem;

            table11itemID = Convert.ToInt32(selectedrow["S.No."]);
            table11Itemname = selectedrow["Particulars"].ToString();
            table11hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table11fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table11FullPlatePriceButton.Text = "Full " + table11fprice;
                Table11HalfPlatePriceButton.Text = "Half " + table11hprice;

                if (table11hprice == 0)
                {
                    Table11HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table11HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table11HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table11Combobox.SelectedItem;

            table11itemID = Convert.ToInt32(selectedrow["S.No."]);
            table11Itemname = selectedrow["Particulars"].ToString();
            table11hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table11Itemname = table11Itemname + " (Half)";

            int qty = Convert.ToInt32(Table11QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table11Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table11Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table11ItemPrice"].Value.ToString());

                if (ItemIDExist == table11itemID && itempriceexist == table11hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table11Quantity"].Value.ToString());
                    row.Cells["Table11Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table11hprice;
                    row.Cells["Table11Amount"].Value = amount;

                    Table11TextBoxValue();
                    Table11QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table11hprice;
                Table11Datagrid.Rows.Add("", table11itemID, table11Itemname, qty, table11hprice, amount);
                Table11QuantityTextbox.Value = 1;
            }
        }

        private void Table11FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table11Combobox.SelectedItem;

            table11itemID = Convert.ToInt32(selectedrow["S.No."]);
            table11Itemname = selectedrow["Particulars"].ToString();
            table11fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table11QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table11Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table11Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table11ItemPrice"].Value.ToString());
                if (ItemIDExist == table11itemID && itempriceexist == table11fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table11Quantity"].Value.ToString());
                    row.Cells["Table11Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table11fprice;
                    row.Cells["Table11Amount"].Value = amount;

                    Table11TextBoxValue();
                    Table11QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table11fprice;

                Table11Datagrid.Rows.Add("", table11itemID, table11Itemname, qty, table11fprice, amount);
                Table11QuantityTextbox.Value = 1;
            }
        }

        private void Table11Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table11Datagrid.Rows[e.RowIndex + i].Cells["Table11Sno"].Value = snoValue;
            }
            Table11RemoveButton.Enabled = true;
            Table11SaveButton.Enabled = true;
            Table11TextBoxValue();
        }

        private void Table11ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table11Linkcombobox();
            Table11Datagrid.Rows.Clear();
            Table11TotalTextBox.Text = "";
            Table11QuantityTextbox.Value = 1;
        }

        private void Table11RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table11Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table11Datagrid.Rows.RemoveAt(index);
                    Table11TextBoxValue();
                }
                if (Table11Datagrid.Rows.Count == 0)
                {
                    Table11TotalTextBox.Text = string.Empty;
                    Table11RemoveButton.Enabled = false;
                    Table11SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table11TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table11TotalTextBox.Text))
            {
                Table11SaveButton.Enabled = false;
            }
        }
        private void Table11SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "11";
            int amount = Convert.ToInt32(Table11TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0) // ordernumber, amount, datetime, tablenumber, datagridview
                {
                    foreach (DataGridViewRow row in Table11Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table11Id"].Value.ToString());
                            string rowname = row.Cells["Table11name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table11Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table11ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table11Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);
                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table11ClearRefreshButton_Click(sender, e);
        }

        #endregion

        #region Table 12

        private void Table12Linkcombobox()
        {
            Table12Combobox.DataSource = dbclass.getData();
            Table12Combobox.DisplayMember = "Particulars";
            Table12Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table12Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table12TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table12Datagrid.Rows)
            {
                if (row.Cells["Table12Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table12Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table12Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table12TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table12TotalTextBox.Text = string.Empty;
                }
            }
        }
        private void Table12Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table12Combobox.SelectedItem;

            table12itemID = Convert.ToInt32(selectedrow["S.No."]);
            table12Itemname = selectedrow["Particulars"].ToString();
            table12hprice = Convert.ToInt32(selectedrow["Half P price"]);
            table12fprice = Convert.ToInt32(selectedrow["Full P price"]);
            if (selectedrow != null)
            {
                Table12FullPlatePriceButton.Text = "Full " + table12fprice;
                Table12HalfPlatePriceButton.Text = "Half " + table12hprice;

                if (table12hprice == 0)
                {
                    Table12HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table12HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table12HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table12Combobox.SelectedItem;

            table12itemID = Convert.ToInt32(selectedrow["S.No."]);
            table12Itemname =selectedrow["Particulars"].ToString();
            table12hprice = Convert.ToInt32(selectedrow["Half P price"]);

            table12Itemname = table12Itemname + " (Half)";

            int qty = Convert.ToInt32(Table12QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table12Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table12Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table12ItemPrice"].Value.ToString());

                if (ItemIDExist == table12itemID && itempriceexist == table12hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table12Quantity"].Value.ToString());
                    row.Cells["Table12Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table12hprice;
                    row.Cells["Table12Amount"].Value = amount;

                    Table12TextBoxValue();
                    Table12QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table12hprice;
                Table12Datagrid.Rows.Add("", table12itemID, table12Itemname, qty, table12hprice, amount);
                Table12QuantityTextbox.Value = 1;
            }
        }

        private void Table12FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table12Combobox.SelectedItem;

            table12itemID = Convert.ToInt32(selectedrow["S.No."]);
            table12Itemname = selectedrow["Particulars"].ToString();
            table12fprice = Convert.ToInt32(selectedrow["Full P price"]);

            int qty = Convert.ToInt32(Table12QuantityTextbox.Value);

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table12Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table12Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table12ItemPrice"].Value.ToString());
                if (ItemIDExist == table12itemID && itempriceexist == table12fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table12Quantity"].Value.ToString());
                    row.Cells["Table12Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table12fprice;
                    row.Cells["Table12Amount"].Value = amount;

                    Table12TextBoxValue();
                    Table12QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table12fprice;

                Table12Datagrid.Rows.Add("", table12itemID, table12Itemname, qty, table12fprice, amount);
                Table12QuantityTextbox.Value = 1;
            }
        }

        private void Table12Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table12Datagrid.Rows[e.RowIndex + i].Cells["Table12Sno"].Value = snoValue;
            }
            Table12RemoveButton.Enabled = true;
            Table12SaveButton.Enabled = true;
            Table12TextBoxValue();
        }

        private void Table12ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table12Linkcombobox();
            Table12Datagrid.Rows.Clear();
            Table12TotalTextBox.Text = "";
            Table12QuantityTextbox.Value = 1;
        }

        private void Table12RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table12Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table12Datagrid.Rows.RemoveAt(index);
                    Table12TextBoxValue();
                }
                if (Table12Datagrid.Rows.Count == 0)
                {
                    Table12TotalTextBox.Text = string.Empty;
                    Table12RemoveButton.Enabled = false;
                    Table12SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table12TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table12TotalTextBox.Text))
            {
                Table12SaveButton.Enabled = false;
            }
        }

        private void Billing_Load(object sender, EventArgs e)
        {

            dbclass = new dbclass();
            dbclass.CreateDatabaseAndFolder();
            GetDefaultPrinterName();

            Linkcombobox();
            Table2Linkcombobox();
            Table3Linkcombobox();
            Table4Linkcombobox();
            Table5Linkcombobox();
            Table6Linkcombobox();
            Table7Linkcombobox();
            Table8Linkcombobox();
            Table9Linkcombobox();
            Table10Linkcombobox();
            Table11Linkcombobox();
            Table12Linkcombobox();


            TotalTextBox.Enabled = false;
            Table2TotalTextBox.Enabled = false;
            Table3TotalTextBox.Enabled = false;
            Table4TotalTextBox.Enabled = false;
            Table5TotalTextBox.Enabled = false;
            Table6TotalTextBox.Enabled = false;
            Table7TotalTextBox.Enabled = false;
            Table8TotalTextBox.Enabled = false;
            Table9TotalTextBox.Enabled = false;
            Table10TotalTextBox.Enabled = false;
            Table11TotalTextBox.Enabled = false;
            Table12TotalTextBox.Enabled = false;

            RemoveItembutton.Enabled = false;
            Table2RemoveButton.Enabled = false;
            Table3RemoveButton.Enabled = false;
            Table4RemoveButton.Enabled = false;
            Table5RemoveButton.Enabled = false;
            Table6RemoveButton.Enabled = false;
            Table7RemoveButton.Enabled = false;
            Table8RemoveButton.Enabled = false;
            Table9RemoveButton.Enabled = false;
            Table10RemoveButton.Enabled = false;
            Table11RemoveButton.Enabled = false;
            Table12RemoveButton.Enabled = false;

            SavePrintButton.Enabled = false;
            Table2Savebutton.Enabled = false;
            Table3SaveButton.Enabled = false;
            Table4SaveButton.Enabled = false;
            Table5SaveButton.Enabled = false;
            Table6SaveButton.Enabled = false;
            Table7SaveButton.Enabled = false;
            Table8SaveButton.Enabled = false;
            Table9SaveButton.Enabled = false;
            Table10SaveButton.Enabled = false;
            Table11SaveButton.Enabled = false;
            Table12SaveButton.Enabled = false;

            EnablePrint.Checked = true;

            checkifdatatableemprtyornot();
        }

        private void Table12SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            int day = currentdate.Day;
            int month = currentdate.Month;
            int year = currentdate.Year;
            string tablenumber = "12";
            int amount = Convert.ToInt32(Table12TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate, day, month, year);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0) // ordernumber, amount, datetime, tablenumber, datagridview
                {
                    foreach (DataGridViewRow row in Table12Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table12Id"].Value.ToString());
                            string rowname = row.Cells["Table12name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table12Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table12ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table12Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);
                        }
                    }
                    PrintPdf();
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table12ClearRefreshButton_Click(sender, e);
        }
        #endregion
    }
}
